using HiveMind.Core.MVC.Runtime.Attributes;
using HiveMind.Core.MVC.Runtime.Views;
using HiveMindGameTemplate.Runtime.Enums.UI;
using HiveMindGameTemplate.Runtime.Signals.Game;
using System;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Views.UI
{
    [Mediator("Game")]
    public class MainMenuPanelMediator : Mediator<MainMenuPanelView>, IDisposable
    {
        #region Injects
        [Inject] private readonly SignalBus signalBus;
        #endregion

        #region Constructor
        public MainMenuPanelMediator(MainMenuPanelView view) : base(view) { }
        #endregion

        #region PostConstruct
        public override void PostConstruct()
        {
            signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

            view.PlayButtonClicked += OnPlayButtonClicked;
            view.SettingsButtonClicked += OnSettingsButtonClicked;
            view.ExitButtonClicked += OnExitButtonClicked;
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

            view.PlayButtonClicked -= OnPlayButtonClicked;
            view.SettingsButtonClicked -= OnSettingsButtonClicked;
            view.ExitButtonClicked -= OnExitButtonClicked;
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
        private void OnPlayButtonClicked() => signalBus.Fire<StartGameSignal>(new());
        private void OnSettingsButtonClicked() => signalBus.Fire<ChangeUIPanelSignal>(new(UIPanelTypes.SettingsPanel));
        private void OnExitButtonClicked() => signalBus.Fire<GameExitSignal>(new());
        #endregion
    }
}
