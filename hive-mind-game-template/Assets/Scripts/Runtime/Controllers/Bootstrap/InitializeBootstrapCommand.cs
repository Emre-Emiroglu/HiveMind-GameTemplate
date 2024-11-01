using Cysharp.Threading.Tasks;
using HiveMind.Core.MVC.Runtime.Controller;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using HiveMindGameTemplate.Runtime.Models.Bootstrap;
using HiveMindGameTemplate.Runtime.Signals.Bootstrap;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Controllers.Bootstrap
{
    public class InitializeBootstrapCommand : Command<InitializeBootstrapSignal>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly BootstrapModel _bootstrapModel;
        #endregion

        #region Constructor
        public InitializeBootstrapCommand(SignalBus signalBus, BootstrapModel bootstrapModel)
        {
            _signalBus = signalBus;
            _bootstrapModel = bootstrapModel;
        }
        #endregion

        #region Executes
        public async override void Execute(InitializeBootstrapSignal signal)
        {
            int milisecondsDelay = (int)(_bootstrapModel.Settings.SceneActivationDuration * 1000f);
            
            await UniTask.Delay(milisecondsDelay);

            _signalBus.Fire<LoadSceneSignal>(new(SceneID.MainMenu));
        }
        #endregion
    }
}
