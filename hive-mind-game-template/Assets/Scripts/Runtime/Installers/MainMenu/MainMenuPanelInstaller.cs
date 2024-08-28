using HiveMind.Core.MVC.Runtime.Installers;
using HiveMindGameTemplate.Runtime.Views.CrossScene;
using HiveMindGameTemplate.Runtime.Views.MainMenu;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.MainMenu
{
    public class MainMenuPanelInstaller : Installer
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.Bind<StartPanelView>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<ShopPanelView>().FromComponentInHierarchy().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<StartPanelMediator>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ShopPanelMediator>().AsSingle().NonLazy();

            Container.Install<ViewMediatorInstaller<CurrencyView, CurrencyMediator>>();
            Container.Install<ViewMediatorInstaller<SettingsButtonView, SettingsButtonMediator>>();
        }
        #endregion
    }
}
