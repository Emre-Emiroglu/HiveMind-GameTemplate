using HiveMind.Core.MVC.Runtime.Controller;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using HiveMindGameTemplate.Runtime.Models.Game;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.Game;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Controllers.Game
{
    public class InitializeGameCommand : Command<InitializeGameSignal>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly TutorialModel _tutorialModel;
        #endregion

        #region Constructor
        public InitializeGameCommand(SignalBus signalBus, TutorialModel tutorialModel)
        {
            _signalBus = signalBus;
            _tutorialModel = tutorialModel;
        }
        #endregion

        #region Executes
        public override void Execute(InitializeGameSignal signal)
        {
            _signalBus.Fire<ChangeLoadingScreenActivationSignal>(new(false, null));

            if (_tutorialModel.IsTutorialShowed)
                _signalBus.Fire<PlayGameSignal>(new());
            else
                _signalBus.Fire<ChangeUIPanelSignal>(new(UIPanelTypes.TutorialPanel));
        }
        #endregion
    }
}
