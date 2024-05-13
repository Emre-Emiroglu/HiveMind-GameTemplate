using HiveMind.Core.CharacterSystem.Runtime.Enums;
using HiveMindGameTemplate.Runtime.Enums.Game.Enemy;
using HiveMindGameTemplate.Runtime.Enums.Game.Projectile;
using HiveMindGameTemplate.Runtime.Handlers.Game.Enemy;
using HiveMindGameTemplate.Runtime.Signals.Game;
using HiveMindGameTemplate.Runtime.Views.Game.Player;
using System;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Views.Game.Enemy
{
    public sealed class EnemyEntityMediator : MonoBehaviour, IPoolable<Datas.ScriptableObjects.Game.Enemy.Enemy, Vector2, Quaternion, IMemoryPool>, IDisposable, ITickable
    {
        #region Injects
        private SignalBus signalBus;
        private EnemyEntityView view;
        private PlayerView playerView;
        private EnemyHealthHandler healthHandler;
        private EnemyMovementHandler movementHandler;
        private EnemyRotationHandler rotationHandler;
        private EnemyAttackHandler attackHandler;
        #endregion

        #region Fields
        private GameObject healthBar;
        private Datas.ScriptableObjects.Game.Enemy.Enemy enemy;
        private IMemoryPool memoryPool;
        #endregion

        #region Getters
        private Vector3 GetDirection()
        {
            Vector3 dir = playerView.Player_VO.Transform.position - view.EnemyEntity_VO.Transform.position;
            dir.z = 0f;

            return dir;
        }
        #endregion

        #region PostConstruct
        [Inject]
        private void PostConstruct(SignalBus signalBus, EnemyEntityView view, PlayerView playerView, EnemyHealthHandler healthHandler, EnemyMovementHandler movementHandler, EnemyRotationHandler rotationHandler, EnemyAttackHandler attackHandler)
        {
            this.signalBus = signalBus;
            this.view = view;
            this.playerView = playerView;
            this.healthHandler = healthHandler;
            this.movementHandler = movementHandler;
            this.rotationHandler = rotationHandler;
            this.attackHandler = attackHandler;
        }
        #endregion

        #region Pool
        public void OnSpawned(Datas.ScriptableObjects.Game.Enemy.Enemy enemy, Vector2 spawnPosition, Quaternion spawnRotation, IMemoryPool memoryPool)
        {
            signalBus.Subscribe<ProjectileHitSignal>(OnProjectileHitSignal);
            signalBus.Subscribe<GameOverSignal>(OnGameOverSignal);

            SetupVisualize(enemy.EnemyType);
            SetupTransform(spawnPosition, spawnRotation);
            SetHandlersEnableStatus(true);
            SetHealthBar(1, 1);

            healthHandler?.SetHealthValues(enemy.MaxHealth, enemy.MaxHealth);
            movementHandler?.SetMovementValues(view.EnemyEntity_VO.Transform, enemy.MovementData);
            rotationHandler?.SetRotationValues(view.EnemyEntity_VO.Transform, enemy.RotationData);
            attackHandler?.SetAttackValues(view.EnemyEntity_VO.Transform, enemy);

            this.enemy = enemy;
            this.memoryPool = memoryPool;
        }
        public void OnDespawned()
        {
            signalBus.Unsubscribe<ProjectileHitSignal>(OnProjectileHitSignal);
            signalBus.Unsubscribe<GameOverSignal>(OnGameOverSignal);

            SetupTransform(Vector2.zero, Quaternion.identity);
            SetHandlersEnableStatus(false);

            enemy = null;
            memoryPool = null;
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            healthHandler?.Dispose();
            movementHandler?.Dispose();
            rotationHandler?.Dispose();
            attackHandler?.Dispose();
            memoryPool?.Despawn(this);
        }
        #endregion

        #region HandlerReceivers
        private void OnHealthChangedAction(int currentHealth, int maxHealth, bool isDead)
        {
            SetHealthBar(currentHealth, maxHealth);

            if (isDead)
            {
                signalBus.Fire<EnemyDeadSignal>(new());
                Dispose();
            }
        }
        private void OnMeleAttackAction(int attackValue) => signalBus.Fire<EnemyMeleAttackSignal>(new(attackValue));
        private void OnSpawnProjectileAction(ProjectileTypes projectileType, Vector2 spawnPosition, Quaternion spawnRotation, int value) => signalBus.Fire<SpawnProjectileSignal>(new(projectileType, spawnPosition, spawnRotation, value));
        #endregion

        #region SignalReceivers
        private void OnProjectileHitSignal(ProjectileHitSignal projectileHitSignal)
        {
            bool hit = view.EnemyEntity_VO.Transform.gameObject == projectileHitSignal.HittedObject;
            if (projectileHitSignal.OwnerType == ProjectileOwnerTypes.Player && hit)
                healthHandler?.Execute(-projectileHitSignal.Value, false, OnHealthChangedAction);
        }
        private void OnGameOverSignal(GameOverSignal gameOverSignal) => Dispose();
        #endregion

        #region Executes
        private void SetupVisualize(EnemyTypes enemyType)
        {
            foreach (var item in view.EnemyEntity_VO.Types)
            {
                bool isActive = item.Key == enemyType;
                item.Value.SetActive(isActive);
            }

            healthBar = view.EnemyEntity_VO.HealthBars[enemyType];
        }
        public void SetupTransform(Vector2 spawnPosition, Quaternion spawnRotation)
        {
            view.EnemyEntity_VO.Transform.SetPositionAndRotation(spawnPosition, spawnRotation);
        }
        private void SetHandlersEnableStatus(bool isEnable)
        {
            healthHandler?.SetEnableStatus(isEnable);
            movementHandler?.SetEnableStatus(isEnable);
            rotationHandler?.SetEnableStatus(isEnable);
            attackHandler?.SetEnableStatus(isEnable);
        }
        private void SetHealthBar(float currentHealth, float maxHealth)
        {
            float amount = currentHealth / maxHealth;
            Vector3 orginalScale = healthBar.transform.localScale;
            healthBar.transform.localScale = new(orginalScale.x, .5f * amount, orginalScale.z);
        }
        #endregion

        #region Ticks
        public void Tick()
        {
            if (!view.EnemyEntity_VO.Transform.gameObject.activeInHierarchy)
                return;

            Vector3 dir = GetDirection();
            Vector3 dirNormal = dir.normalized;
            float dirMagnitude = dir.magnitude;

            bool inAttackZone = dirMagnitude <= enemy.ClosingDistance;

            if (inAttackZone)
            {
                attackHandler?.Execute(OnMeleAttackAction, OnSpawnProjectileAction);
            }
            else
            {
                movementHandler?.Execute(dirNormal, MovementStatus.Walk);
                rotationHandler?.Execute(dir);
            }
        }
        #endregion
    }
}
