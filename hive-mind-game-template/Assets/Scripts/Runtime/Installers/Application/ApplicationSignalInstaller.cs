using HiveMindGameTemplate.Runtime.Controllers.Application;
using HiveMindGameTemplate.Runtime.Signals.Application;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.Application
{
    public class ApplicationSignalInstaller : Installer
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.DeclareSignal<InitializeApplicationSignal>();

            Container.BindInterfacesAndSelfTo<InitializeApplicationCommand>().AsSingle().NonLazy();

            Container.BindSignal<InitializeApplicationSignal>().ToMethod<InitializeApplicationCommand>((x, s) => x.Execute(s)).FromResolve();
        }
        #endregion
    }
}
