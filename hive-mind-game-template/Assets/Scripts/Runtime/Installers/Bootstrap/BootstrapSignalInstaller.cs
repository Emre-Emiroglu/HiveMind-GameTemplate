using HiveMindGameTemplate.Runtime.Controllers.Bootstrap;
using HiveMindGameTemplate.Runtime.Signals.Bootstrap;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.Bootstrap
{
    public class BootstrapSignalInstaller : Installer
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.DeclareSignal<InitializeBootstrapSignal>();

            Container.BindInterfacesAndSelfTo<InitializeBootstrapCommand>().AsSingle().NonLazy();

            Container.BindSignal<InitializeBootstrapSignal>().ToMethod<InitializeBootstrapCommand>((x, s) => x.Execute(s)).FromResolve();
        }
        #endregion
    }
}
