using HiveMind.Core.MVC.Runtime.Controller;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Controllers.CrossScene
{
    public class LoadSceneCommand : Command<LoadSceneSignal>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion

        #region Constructor
        public LoadSceneCommand(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        #endregion

        #region Executes
        public override void Execute(LoadSceneSignal signal)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)signal.SceneId);

            _signalBus.Fire<ChangeLoadingScreenActivationSignal>(new(true, asyncOperation));
        }
        #endregion
    }
}
