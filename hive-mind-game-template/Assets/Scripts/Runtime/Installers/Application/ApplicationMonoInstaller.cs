using HiveMindGameTemplate.Runtime.Signals.Application;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.Application
{
    public class ApplicationMonoInstaller : MonoInstaller
    {
        #region Bindings
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.Install<ApplicationModelInstaller>();
            Container.Install<ApplicationSignalInstaller>();
        }
        #endregion

        #region Cycle
        public override void Start()
        {
            Container.Resolve<SignalBus>().Fire<InitializeApplicationSignal>(new());
        }
        #endregion
    }
}
