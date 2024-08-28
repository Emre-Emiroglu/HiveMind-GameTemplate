using HiveMind.Core.MVC.Runtime.Controller;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.MainMenu;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Controllers.MainMenu
{
    public class InitializeMainMenuCommand : Command<InitializeMainMenuSignal>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion

        #region Constructor
        public InitializeMainMenuCommand(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        #endregion

        #region Executes
        public override void Execute(InitializeMainMenuSignal signal)
        {
            _signalBus.Fire<ChangeLoadingScreenActivationSignal>(new(false, null));
            _signalBus.Fire<ChangeUIPanelSignal>(new(UIPanelTypes.StartPanel));
        }
        #endregion
    }
}
