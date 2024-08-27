using HiveMindGameTemplate.Runtime.Views.CrossScene.LoadingScreen;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.CrossScene
{
    public class CrossScenePanelInstaller: Installer
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.Bind<LoadingScreenPanelView>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LoadingScreenPanelMediator>().AsSingle().NonLazy();
        }
        #endregion
    }
}