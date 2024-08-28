using HiveMind.Core.MVC.Runtime.Controller;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using Zenject;
using HiveMindGameTemplate.Runtime.Models.CrossScene;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HiveMindGameTemplate.Runtime.Controllers.CrossScene
{
    public class GameExitCommand : Command<GameExitSignal>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly LevelModel _levelModel;
        #endregion

        #region Constructor
        public GameExitCommand(SignalBus signalBus, LevelModel levelModel)
        {
            _signalBus = signalBus;
            _levelModel = levelModel;
        }
        #endregion

        #region Executes
        public override void Execute(GameExitSignal signal)
        {
            _levelModel.Save();

#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            UnityEngine.Application.Quit();
#endif
        }
        #endregion
    }
}
