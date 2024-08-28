using HiveMindGameTemplate.Runtime.Controllers.MainMenu;
using HiveMindGameTemplate.Runtime.Signals.MainMenu;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.MainMenu
{
    public class MainMenuSignalInstaller : Installer
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.DeclareSignal<InitializeMainMenuSignal>();
            Container.DeclareSignal<ReturnToStartPanelSignal>();
            Container.DeclareSignal<OpenShopPanelSignal>();
            Container.DeclareSignal<StartPanelPlayButtonClickedSignal>();

            Container.BindInterfacesAndSelfTo<InitializeMainMenuCommand>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ReturnToStartPanelCommand>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<OpenShopPanelCommand>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StartPanelPlayButtonClickedCommand>().AsSingle().NonLazy();

            Container.BindSignal<InitializeMainMenuSignal>().ToMethod<InitializeMainMenuCommand>((x, s) => x.Execute(s)).FromResolve();
            Container.BindSignal<ReturnToStartPanelSignal>().ToMethod<ReturnToStartPanelCommand>((x, s) => x.Execute(s)).FromResolve();
            Container.BindSignal<OpenShopPanelSignal>().ToMethod<OpenShopPanelCommand>((x, s) => x.Execute(s)).FromResolve();
            Container.BindSignal<StartPanelPlayButtonClickedSignal>().ToMethod<StartPanelPlayButtonClickedCommand>((x, s) => x.Execute(s)).FromResolve();
        }
        #endregion
    }
}
