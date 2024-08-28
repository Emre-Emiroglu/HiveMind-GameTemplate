using HiveMind.Core.MVC.Runtime.Controller;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.Game;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Controllers.Game
{
    public class PlayGameCommand : Command<PlayGameSignal>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion

        #region Constructor
        public PlayGameCommand(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        #endregion

        #region Executes
        public override void Execute(PlayGameSignal signal)
        {
            _signalBus.Fire<ChangeUIPanelSignal>(new(UIPanelTypes.InGamePanel));
        }
        #endregion
    }
}
