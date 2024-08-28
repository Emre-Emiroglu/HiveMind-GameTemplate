using HiveMindGameTemplate.Runtime.Views.Bootstrap;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.Bootstrap
{
    public class BootstrapPanelInstaller : Installer
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.Bind<LogoHolderPanelView>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LogoHolderPanelMediator>().AsSingle().NonLazy();
        }
        #endregion
    }
}
