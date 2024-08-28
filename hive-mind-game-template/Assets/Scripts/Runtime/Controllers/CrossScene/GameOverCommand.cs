using Cysharp.Threading.Tasks;
using HiveMind.Core.MVC.Runtime.Controller;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using HiveMindGameTemplate.Runtime.Models.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Controllers.CrossScene
{
    public class GameOverCommand : Command<GameOverSignal>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly LevelModel _levelModel;
        //private readonly GameModel _gameModel;
        #endregion

        #region Constructor
        public GameOverCommand(SignalBus signalBus, LevelModel levelModel)
        {
            _signalBus = signalBus;
            _levelModel = levelModel;
            //_gameModel = gameModel;
        }
        #endregion

        #region Executes
        public async override void Execute(GameOverSignal signal)
        {
            if (signal.QuickExit)
                _signalBus.Fire<LoadSceneSignal>(new(SceneID.MainMenu));
            else
            {
                _signalBus.Fire<PlayAudioSignal>(new(AudioTypes.Sound, MusicTypes.BackgroundMusic, signal.IsSuccess ? SoundTypes.GameWin : SoundTypes.GameFail));

                //int millisecondsDelay = (int)(_gameModel.Settings.GameOverDelayDuration * 1000);

                //await UniTask.Delay(millisecondsDelay);

                //_signalBus.Fire<ChangeUIPanelSignal>(new(UIPanelTypes.GameOverPanel));
                //_signalBus.Fire<SetupGameOverPanelSignal>(new(signal.IsSuccess));

                //_levelModel.UpdateCurrentLevelIndex(false, signal.IsSuccess ? 1 : 0);
            }
        }
        #endregion
    }
}
