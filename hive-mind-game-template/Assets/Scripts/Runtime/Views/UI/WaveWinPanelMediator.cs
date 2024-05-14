using HiveMind.Core.MVC.Runtime.Attributes;
using HiveMind.Core.MVC.Runtime.Views;
using HiveMindGameTemplate.Runtime.Signals.Game;
using System;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Views.UI
{
    [Mediator("Game")]
    public class WaveWinPanelMediator : Mediator<WaveWinPanelView>, IDisposable
    {
        #region Injects
        [Inject] private readonly SignalBus signalBus;
        #endregion

        #region Constructor
        public WaveWinPanelMediator(WaveWinPanelView view) : base(view) { }
        #endregion

        #region PostConstruct
        public override void PostConstruct()
        {
            signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

            view.NextWaveButtonClicked += OnNextWaveButtonClicked;
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

            view.NextWaveButtonClicked -= OnNextWaveButtonClicked;
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
        #endregion

        #region ButtonReceivers
        private void OnNextWaveButtonClicked() => signalBus.Fire<NextWaveSignal>(new());
        #endregion
    }
}
