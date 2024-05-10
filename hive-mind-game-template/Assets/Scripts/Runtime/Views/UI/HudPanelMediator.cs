using HiveMind.Core.MVC.Attributes;
using HiveMind.Core.MVC.Views;
using HiveMindGameTemplate.Runtime.Models.Game.Wave;
using HiveMindGameTemplate.Runtime.Signals.Game;
using System;
using System.Linq;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Views.UI
{
    [Mediator("Game")]
    public sealed class HudPanelMediator : Mediator<HudPanelView>, IDisposable
    {
        #region Injects
        [Inject] private readonly SignalBus signalBus;
        [Inject] private readonly WaveModel waveModel;
        #endregion

        #region Fields
        private int deadEnemyCount;
        private int totalEnemyCount;
        #endregion

        #region Constructor
        public HudPanelMediator(HudPanelView view) : base(view) { }
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
                signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                signalBus.Subscribe<StartGameSignal>(OnStartGameSignal);
                signalBus.Subscribe<WaveWinSignal>(OnWaveWinSignal);
                signalBus.Subscribe<GameOverSignal>(OnGameOverSignal);
            }
            else
            {
                signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                signalBus.Unsubscribe<StartGameSignal>(OnStartGameSignal);
                signalBus.Unsubscribe<WaveWinSignal>(OnWaveWinSignal);
                signalBus.Unsubscribe<GameOverSignal>(OnGameOverSignal);
            }
        }
        private void SetInGameSubscriptions(bool isSub)
        {
            if (isSub)
            {
                signalBus.Subscribe<EnemyDeadSignal>(OnEnemyDeadSignal);
                signalBus.Subscribe<PlayerHealthChangedSignal>(OnPlayerHealthChangedSignal);
            }
            else
            {
                signalBus.Unsubscribe<EnemyDeadSignal>(OnEnemyDeadSignal);
                signalBus.Unsubscribe<PlayerHealthChangedSignal>(OnPlayerHealthChangedSignal);
            }
        }
        #endregion

        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal)
        {
            bool isShow = signal.UIPanelType == view.UIPanel_VO.UIPanelType;
            if (isShow)
                view.Show();
            else
                view.Hide();
        }
        private void OnStartGameSignal(StartGameSignal startGameSignal)
        {
            SetInGameSubscriptions(true);

            SetWaveText();

            SetEnemyCountText(true);

            SetPlayerHealthFillImage(1, 1);
        }
        private void OnWaveWinSignal(WaveWinSignal waveWinSignal)
        {
            SetInGameSubscriptions(false);
        }
        private void OnGameOverSignal(GameOverSignal gameOverSignal)
        {
            SetInGameSubscriptions(false);
        }
        private void OnEnemyDeadSignal(EnemyDeadSignal enemyDeadSignal)
        {
            SetEnemyCountText(false);
        }
        private void OnPlayerHealthChangedSignal(PlayerHealthChangedSignal playerHealthChangedSignal)
        {
            SetPlayerHealthFillImage(playerHealthChangedSignal.CurrentHealth, playerHealthChangedSignal.MaxHealth);
        }
        #endregion

        #region Executes
        private void SetWaveText()
        {
            int waveNumber = waveModel.WavePersisentData.CurrentWaveIndex + 1;
            view.WaveText.SetText($"Wave {waveNumber}");
        }
        private void SetEnemyCountText(bool reset)
        {
            deadEnemyCount = reset ? 0 : deadEnemyCount + 1;
            totalEnemyCount = reset ? waveModel.CurrentWave.Enemies.Values.ToList().Sum() : totalEnemyCount;

            view.EnemyCountText.SetText($"{deadEnemyCount}/{totalEnemyCount}");
        }
        private void SetPlayerHealthFillImage(float currentHealth, float maxHealth)
        {
            float amount =  currentHealth / maxHealth;
            view.PlayerHealthFillImage.fillAmount = amount;
        }
        #endregion
    }
}
