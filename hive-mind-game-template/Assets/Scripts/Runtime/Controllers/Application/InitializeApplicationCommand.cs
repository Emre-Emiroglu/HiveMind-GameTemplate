using HiveMind.Core.MVC.Runtime.Controller;
using HiveMindGameTemplate.Runtime.Models.Application;
using HiveMindGameTemplate.Runtime.Signals.Application;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Controllers.Application
{
    public class InitializeApplicationCommand : Command<InitializeApplicationSignal>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly ApplicationModel _applicationModel;
        #endregion

        #region Constructor
        public InitializeApplicationCommand(SignalBus signalBus, ApplicationModel applicationModel)
        {
            _signalBus = signalBus;
            _applicationModel = applicationModel;
        }
        #endregion

        #region Executes
        public override void Execute(InitializeApplicationSignal signal)
        {
            UnityEngine.Application.targetFrameRate = _applicationModel.Settings.TargetFrameRate;
            UnityEngine.Application.runInBackground = _applicationModel.Settings.RunInBackground;
        }
        #endregion
    }
}
