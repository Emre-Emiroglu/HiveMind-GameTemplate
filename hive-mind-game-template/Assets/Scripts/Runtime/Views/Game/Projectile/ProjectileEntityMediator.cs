using HiveMindGameTemplate.Runtime.Enums.Game.Projectile;
using HiveMindGameTemplate.Runtime.Handlers.Game.Projectile;
using HiveMindGameTemplate.Runtime.Signals.Game;
using System;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Views.Game.Projectile
{
    public sealed class ProjectileEntityMediator : MonoBehaviour, IPoolable<Datas.ScriptableObjects.Game.Projectile.Projectile, Vector2, Quaternion, IMemoryPool>, IDisposable
    {
        #region Constants
        private const string PLAYER_TAG = "Player";
        private const string ENEMY_TAG = "Enemy";
        #endregion

        #region Fields
        private SignalBus signalBus;
        private ProjectileEntityView view;
        private ProjectileMobilityHandler projectileMobilityHandler;
        private ProjectileLifetimeHandler projectileLifetimeHandler;
        private Datas.ScriptableObjects.Game.Projectile.Projectile projectile;
        private IMemoryPool memoryPool;
        #endregion

        #region Getters
        private bool CanDead(Collider2D collider2D)
        {
            bool canDead = true;
            switch (projectile.OwnerType)
            {
                case ProjectileOwnerTypes.Player:
                    canDead = !collider2D.gameObject.CompareTag(PLAYER_TAG);
                    break;
                case ProjectileOwnerTypes.Enemy:
                    canDead = !collider2D.gameObject.CompareTag(ENEMY_TAG);
                    break;
            }

            return canDead;
        }
        #endregion

        #region PostConstruct
        [Inject]
        private void PostConstruct(SignalBus signalBus, ProjectileEntityView view, ProjectileMobilityHandler projectileMobilityHandler, ProjectileLifetimeHandler projectileLifetimeHandler)
        {
            this.signalBus = signalBus;
            this.view = view;
            this.projectileMobilityHandler = projectileMobilityHandler;
            this.projectileLifetimeHandler = projectileLifetimeHandler;
        }
        #endregion

        #region Pool
        public void OnSpawned(Datas.ScriptableObjects.Game.Projectile.Projectile projectile, Vector2 spawnPosition, Quaternion spawnRotation, IMemoryPool memoryPool)
        {
            SetupVisualize(projectile.ProjectileType);
            SetupTransform(spawnPosition, spawnRotation);
            SetupRigidbody(true);
            SetHandlersEnableStatus(true);

            projectileMobilityHandler?.Execute(view.ProjectileEntity_VO.Rigidbody, view.ProjectileEntity_VO.Transform, projectile.Speed);
            projectileLifetimeHandler?.Execute(projectile.LifeTime, OnDeadAction);

            this.projectile = projectile;
            this.memoryPool = memoryPool;
        }
        public void OnDespawned()
        {
            SetupTransform(Vector2.zero, Quaternion.identity);
            SetupRigidbody(false);
            SetHandlersEnableStatus(false);

            memoryPool = null;
            projectile = null;
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            projectileMobilityHandler?.Dispose();
            projectileLifetimeHandler?.Dispose();
            memoryPool?.Despawn(this);
        }
        #endregion

        #region Executes
        private void SetupVisualize(ProjectileTypes projectileType)
        {
            foreach (var item in view.ProjectileEntity_VO.Types)
            {
                bool isActive = item.Key == projectileType;
                item.Value.SetActive(isActive);
            }
        }
        private void SetupTransform(Vector2 spawnPosition, Quaternion spawnRotation)
        {
            view.ProjectileEntity_VO.Transform.SetPositionAndRotation(spawnPosition, spawnRotation);
        }
        private void SetupRigidbody(bool isActive)
        {
            view.ProjectileEntity_VO.Rigidbody.bodyType = isActive ? RigidbodyType2D.Dynamic : RigidbodyType2D.Kinematic;
            view.ProjectileEntity_VO.Rigidbody.velocity = Vector2.zero;
            view.ProjectileEntity_VO.Rigidbody.angularVelocity = 0f;
        }
        private void SetHandlersEnableStatus(bool isEnable)
        {
            projectileMobilityHandler?.SetEnableStatus(isEnable);
            projectileLifetimeHandler?.SetEnableStatus(isEnable);
        }
        #endregion

        #region HandlerReceivers
        private void OnDeadAction() => Dispose();
        #endregion

        #region PhysicReceivers
        public void OnEnterCallback(Collision collision = null, Collision2D collision2D = null, Collider collider = null, Collider2D collider2D = null)
        {
            if (collider2D == null)
                return;

            if (collider2D.attachedRigidbody.gameObject == null)
                return;

            signalBus.Fire<ProjectileHitSignal>(new(collider2D.attachedRigidbody.gameObject, projectile.OwnerType, projectile.Value));

            if (CanDead(collider2D))
                OnDeadAction();
        }
        #endregion
    }
}
