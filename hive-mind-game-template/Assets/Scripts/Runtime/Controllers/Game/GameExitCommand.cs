using HiveMind.Core.MVC.Runtime.Controller;
using Zenject;
using HiveMindGameTemplate.Runtime.Signals.Game;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;

namespace HiveMindGameTemplate.Runtime.Controllers.Game
{
    public class GameExitCommand : Command<GameExitSignal>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion

        #region Constructor
        public GameExitCommand(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        #endregion

        #region Executes
        public override void Execute(GameExitSignal signal)
        {
            _signalBus.Fire<LoadSceneSignal>(new(SceneID.MainMenu));
        }
        #endregion
    }
}
