using HiveMind.Core.MVC.Runtime.Installers;
using HiveMindGameTemplate.Runtime.Views.CrossScene;
using HiveMindGameTemplate.Runtime.Views.Game;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.Game
{
    public class GamePanelInstaller : Installer
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.Bind<GameOverPanelView>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<InGamePanelView>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<TutorialPanelView>().FromComponentInHierarchy().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<GameOverPanelMediator>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InGamePanelMediator>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<TutorialPanelMediator>().AsSingle().NonLazy();

            Container.Install<ViewMediatorInstaller<CurrencyView, CurrencyMediator>>();
            Container.Install<ViewMediatorInstaller<SettingsButtonView, SettingsButtonMediator>>();
        }
        #endregion
    }
}
