using HiveMind.Core.MVC.Runtime.Controller;
using HiveMindGameTemplate.Runtime.Models.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.Application;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HiveMindGameTemplate.Runtime.Controllers.Application
{
    public class AppQuitCommand : Command<AppQuitSignal>
    {
        #region ReadonlyFields
        private readonly AudioModel _audioModel;
        private readonly HapticModel _hapticModel;
        private readonly CurrencyModel _currencyModel;
        private readonly LevelModel _levelModel;
        #endregion

        #region Constructor
        public AppQuitCommand(AudioModel audioModel, HapticModel hapticModel, CurrencyModel currencyModel, LevelModel levelModel)
        {
            _audioModel = audioModel;
            _hapticModel = hapticModel;
            _currencyModel = currencyModel;
            _levelModel = levelModel;
        }
        #endregion

        #region Executes
        public override void Execute(AppQuitSignal signal)
        {
            _audioModel.Save();
            _hapticModel.Save();
            _currencyModel.Save();
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
