using HiveMind.Core.MVC.Runtime.Controller;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using HiveMindGameTemplate.Runtime.Models.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.Game;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Controllers.Game
{
    public class GameOverCommand : Command<GameOverSignal>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly LevelModel _levelModel;
        #endregion

        #region Constructor
        public GameOverCommand(SignalBus signalBus, LevelModel levelModel)
        {
            _signalBus = signalBus;
            _levelModel = levelModel;
        }
        #endregion

        #region Executes
        public override void Execute(GameOverSignal signal)
        {
            _signalBus.Fire<PlayAudioSignal>(new(AudioTypes.Sound, MusicTypes.BackgroundMusic, signal.IsSuccess ? SoundTypes.GameWin : SoundTypes.GameFail));

            _signalBus.Fire<ChangeUIPanelSignal>(new(UIPanelTypes.GameOverPanel));
            _signalBus.Fire<SetupGameOverPanelSignal>(new(signal.IsSuccess));

            _levelModel.UpdateCurrentLevelIndex(false, signal.IsSuccess ? 1 : 0);
        }
        #endregion
    }
}
