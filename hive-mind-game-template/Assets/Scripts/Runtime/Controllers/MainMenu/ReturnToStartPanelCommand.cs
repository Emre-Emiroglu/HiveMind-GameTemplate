using HiveMind.Core.MVC.Runtime.Controller;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.MainMenu;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Controllers.MainMenu
{
    public class ReturnToStartPanelCommand : Command<ReturnToStartPanelSignal>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion

        #region Constructor
        public ReturnToStartPanelCommand(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        #endregion

        #region Executes
        public override void Execute(ReturnToStartPanelSignal signal)
        {
            _signalBus.Fire<ChangeUIPanelSignal>(new(UIPanelTypes.StartPanel));
        }
        #endregion
    }
}
