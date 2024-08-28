using HiveMind.Core.MVC.Runtime.Controller;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.MainMenu;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Controllers.MainMenu
{
    public class StartPanelPlayButtonClickedCommand : Command<StartPanelPlayButtonClickedSignal>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion

        #region Constructor
        public StartPanelPlayButtonClickedCommand(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        #endregion

        #region Executes
        public override void Execute(StartPanelPlayButtonClickedSignal signal)
        {
            _signalBus.Fire<LoadSceneSignal>(new(SceneID.Game));
        }
        #endregion
    }
}
