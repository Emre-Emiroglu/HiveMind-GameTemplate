using HiveMind.Core.MVC.Attributes;
using HiveMind.Core.MVC.Views;
using HiveMindGameTemplate.Runtime.Enums.UI;
using HiveMindGameTemplate.Runtime.Signals.Game;
using System;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Views.UI
{
    [Mediator("Game")]
    public class GameOverPanelMediator : Mediator<GameOverPanelView>, IDisposable
    {
        #region Injects
        [Inject] private readonly SignalBus signalBus;
        #endregion

        #region Constructor
        public GameOverPanelMediator(GameOverPanelView view) : base(view) { }
        #endregion

        #region PostConstruct
        public override void PostConstruct()
        {
            signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

            view.HomeButtonClicked += OnHomeButtonClicked;
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

            view.HomeButtonClicked -= OnHomeButtonClicked;
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
        private void OnHomeButtonClicked() => signalBus.Fire<ChangeUIPanelSignal>(new(UIPanelTypes.MainMenuPanel));
        #endregion
    }
}
