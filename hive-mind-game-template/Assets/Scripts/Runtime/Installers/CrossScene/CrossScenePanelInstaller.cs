﻿using HiveMindGameTemplate.Runtime.Views.CrossScene;
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

            Container.Bind<AudioView>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<AudioMediator>().AsSingle().NonLazy();
        }
        #endregion
    }
}