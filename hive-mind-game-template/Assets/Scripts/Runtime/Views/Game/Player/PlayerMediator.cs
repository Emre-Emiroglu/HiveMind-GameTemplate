using HiveMind.Core.MVC.Attributes;
using HiveMind.Core.MVC.Views;
using HiveMindGameTemplate.Runtime.Enums.Game.Projectile;
using HiveMindGameTemplate.Runtime.Handlers.Game.Player;
using HiveMindGameTemplate.Runtime.Models.Game.Player;
using HiveMindGameTemplate.Runtime.Signals.Game;
using System;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Views.Game.Player
{
    [Mediator("Game")]
    public sealed class PlayerMediator : Mediator<PlayerView>, ITickable, IDisposable
    {
        #region Injects
        [Inject] private readonly SignalBus signalBus;
        [Inject] private readonly PlayerModel playerModel;
        [Inject] private readonly PlayerInputHandler inputHandler;
        [Inject] private readonly PlayerMovementHandler movementHandler;
        [Inject] private readonly PlayerRotationHandler rotationHandler;
        [Inject] private readonly PlayerAttackHandler attackHandler;
        [Inject] private readonly PlayerDashHandler dashHandler;
        [Inject] private readonly PlayerHealthHandler healthHandler;
        #endregion

        #region Constructor
        public PlayerMediator(PlayerView view) : base(view) { }
        #endregion

        #region PostConstruct
        public override void PostConstruct()
        {
            SetCycleSubscriptions(true);
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            SetCycleSubscriptions(false);
        }
        #endregion

        #region Subscriptions
        private void SetCycleSubscriptions(bool isSub)
        {
            if (isSub)
            {
                signalBus.Subscribe<StartGameSignal>(OnStartGameSignal);
                signalBus.Subscribe<WaveWinSignal>(OnWaveWinSignal);
                signalBus.Subscribe<GameOverSignal>(OnGameOverSignal);
            }
            else
            {
                signalBus.Unsubscribe<StartGameSignal>(OnStartGameSignal);
                signalBus.Unsubscribe<WaveWinSignal>(OnWaveWinSignal);
                signalBus.Unsubscribe<GameOverSignal>(OnGameOverSignal);
            }
        }
        private void SetInGameSubscriptions(bool isSub)
        {
            if (isSub)
            {
                signalBus.Subscribe<ProjectileHitSignal>(OnProjectileHitSignal);
                signalBus.Subscribe<EnemyMeleAttackSignal>(OnEnemyMeleAttackSignal);
            }
            else
            {
                signalBus.Unsubscribe<ProjectileHitSignal>(OnProjectileHitSignal);
                signalBus.Unsubscribe<EnemyMeleAttackSignal>(OnEnemyMeleAttackSignal);
            }
        }
        #endregion

        #region SetHandlersEnableStatus
        private void SetHandlersEnableStatus(bool enable, bool withInput = true, bool withMovement = true, bool withRotation = true, bool withAttack = true, bool withDash = true, bool withHealth = true)
        {
            if (withInput)
                inputHandler?.SetEnableStatus(enable);
            if (withMovement)
                movementHandler?.SetEnableStatus(enable);
            if (withRotation)
                rotationHandler?.SetEnableStatus(enable);
            if (withAttack)
                attackHandler?.SetEnableStatus(enable);
            if (withDash)
                dashHandler?.SetEnableStatus(enable);
            if (withHealth)
                healthHandler?.SetEnableStatus(enable);
        }
        #endregion

        #region HandlerReceivers
        private void OnSpawnProjectieAction(ProjectileTypes projectileType, Vector2 spawnPosition, Quaternion spawnRotation, int value) => signalBus.Fire<SpawnProjectileSignal>(new(projectileType, spawnPosition, spawnRotation, value));
        private void OnHealthChangedAction(int currentHealth, int maxHealth, bool isDead)
        {
            signalBus.Fire<PlayerHealthChangedSignal>(new(currentHealth, maxHealth));

            if (isDead)
                signalBus.Fire<GameOverSignal>(new());
        }
        #endregion

        #region SignalReceivers
        private void OnStartGameSignal(StartGameSignal startGameSignal)
        {
            SetInGameSubscriptions(true);
            SetHandlersEnableStatus(true);

            healthHandler?.Execute(playerModel.Settings.MaxHealth, true, OnHealthChangedAction);
        }
        private void OnWaveWinSignal(WaveWinSignal waveWinSignal)
        {
            SetInGameSubscriptions(false);
            SetHandlersEnableStatus(false);
        }
        private void OnGameOverSignal(GameOverSignal gameOverSignal)
        {
            SetInGameSubscriptions(false);
            SetHandlersEnableStatus(false);
        }
        private void OnProjectileHitSignal(ProjectileHitSignal projectileHitSignal)
        {
            switch (projectileHitSignal.OwnerType)
            {
                case ProjectileOwnerTypes.Player:
                    break;
                case ProjectileOwnerTypes.Enemy:
                    healthHandler?.Execute(-projectileHitSignal.Value, false, OnHealthChangedAction);
                    break;
            }
        }
        private void OnEnemyMeleAttackSignal(EnemyMeleAttackSignal enemyMeleAttackSignal)
        {
            healthHandler?.Execute(-enemyMeleAttackSignal.AttackValue, false, OnHealthChangedAction);
        }
        #endregion

        #region Ticks
        public void Tick()
        {
            movementHandler?.Execute(inputHandler.MovementInputValue, inputHandler.MovementStatus);
            rotationHandler?.Execute(inputHandler.RotationInputValue(HiveMind.Core.CharacterSystem.Runtime.Enums.RotationTypes.TopDown));
            attackHandler?.Execute(inputHandler.ActionStatus, view.Player_VO.Transform, OnSpawnProjectieAction);
            dashHandler?.Execute(inputHandler.ActionStatus, inputHandler.MovementInputValue, view.Player_VO.Rigidbody2D);
        }
        #endregion
    }
}
