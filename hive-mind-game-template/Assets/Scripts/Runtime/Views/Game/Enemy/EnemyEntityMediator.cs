using HiveMindGameTemplate.Runtime.Enums.Game.Enemy;
using HiveMindGameTemplate.Runtime.Enums.Game.Projectile;
using HiveMindGameTemplate.Runtime.Handlers.Game.Enemy;
using HiveMindGameTemplate.Runtime.Signals.Game;
using System;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Views.Game.Enemy
{
    public sealed class EnemyEntityMediator : MonoBehaviour, IPoolable<Datas.ScriptableObjects.Game.Enemy.Enemy, Vector2, Quaternion, IMemoryPool>, IDisposable
    {
        #region Fields
        private SignalBus signalBus;
        private EnemyEntityView view;
        private EnemyHealthHandler healthHandler;
        private GameObject healthBar;
        private Datas.ScriptableObjects.Game.Enemy.Enemy enemy;
        private IMemoryPool memoryPool;
        #endregion

        #region PostConstruct
        [Inject]
        private void PostConstruct(SignalBus signalBus, EnemyEntityView view, EnemyHealthHandler healthHandler)
        {
            this.signalBus = signalBus;
            this.view = view;
            this.healthHandler = healthHandler;
        }
        #endregion

        #region Pool
        public void OnSpawned(Datas.ScriptableObjects.Game.Enemy.Enemy enemy, Vector2 spawnPosition, Quaternion spawnRotation, IMemoryPool memoryPool)
        {
            signalBus.Subscribe<ProjectileHitSignal>(OnProjectileHitSignal);

            SetupVisualize(enemy.EnemyType);
            SetupTransform(spawnPosition, spawnRotation);
            SetHandlersEnableStatus(true);
            SetHealthBar(1, 1);

            healthHandler?.SetHealthValues(enemy.MaxHealth, enemy.MaxHealth);

            this.enemy = enemy;
            this.memoryPool = memoryPool;
        }
        public void OnDespawned()
        {
            signalBus.Unsubscribe<ProjectileHitSignal>(OnProjectileHitSignal);
         
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
            memoryPool.Despawn(this);
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
        #endregion

        #region SignalReceivers
        private void OnProjectileHitSignal(ProjectileHitSignal projectileHitSignal)
        {
            bool hit = view.EnemyEntity_VO.Transform.gameObject == projectileHitSignal.HittedObject;
            if (projectileHitSignal.OwnerType == ProjectileOwnerTypes.Player && hit)
                healthHandler?.Execute(-projectileHitSignal.Value, false, OnHealthChangedAction);
        }
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
        }
        private void SetHealthBar(float currentHealth, float maxHealth)
        {
            float amount = currentHealth / maxHealth;
            Vector3 orginalScale = healthBar.transform.localScale;
            healthBar.transform.localScale = new(orginalScale.x, .5f * amount, orginalScale.z);
        }
        #endregion
    }
}
