using HiveMindGameTemplate.Runtime.Signals.Bootstrap;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.Bootstrap
{
    public class BootstrapMonoInstaller : MonoInstaller
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.Install<BootstrapModelInstaller>();
            Container.Install<BootstrapPanelInstaller>();
            Container.Install<BootstrapSignalInstaller>();
        }
        #endregion

        #region Cycle
        public override void Start()
        {
            Container.Resolve<SignalBus>().Fire<InitializeBootstrapSignal>(new());
        }
        #endregion
    }
}
