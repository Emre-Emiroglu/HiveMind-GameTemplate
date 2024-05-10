using HiveMind.Core.MVC.Attributes;
using HiveMind.Core.MVC.Views;
using HiveMindGameTemplate.Runtime.Models.Game.Player;
using HiveMindGameTemplate.Runtime.Signals.Game;
using System;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Views.UI
{
    [Mediator("Game")]
    public sealed class HudPanelMediator : Mediator<HudPanelView>, IDisposable
    {
        #region Injects
        [Inject] private readonly SignalBus signalBus;
        [Inject] private readonly PlayerModel playerModel;
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
            }
            else
            {
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
        }
        private void OnWaveWinSignal(WaveWinSignal waveWinSignal)
        {
            SetInGameSubscriptions(false);
        }
        private void OnGameOverSignal(GameOverSignal gameOverSignal)
        {
            SetInGameSubscriptions(false);
        }
        #endregion
    }
}
