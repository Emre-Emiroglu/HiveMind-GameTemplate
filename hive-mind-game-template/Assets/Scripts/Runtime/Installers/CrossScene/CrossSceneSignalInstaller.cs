﻿using HiveMindGameTemplate.Runtime.Controllers.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.CrossScene
{
    public class CrossSceneSignalInstaller: Installer
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.DeclareSignal<ChangeLoadingScreenActivationSignal>();
            Container.DeclareSignal<LoadSceneSignal>();
            Container.DeclareSignal<PlayAudioSignal>();
            Container.DeclareSignal<PlayHapticSignal>();
            Container.DeclareSignal<ChangeCurrencySignal>();
            Container.DeclareSignal<SpawnCurrencyTrailSignal>();
            Container.DeclareSignal<RefreshCurrencyVisualSignal>();
            Container.DeclareSignal<SettingsButtonPressedSignal>();
            Container.DeclareSignal<SettingsButtonRefreshSignal>();
            Container.DeclareSignal<ChangeUIPanelSignal>();

            Container.BindInterfacesAndSelfTo<ChangeCurrencyCommand>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LoadSceneCommand>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayHapticCommand>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SettingsButtonPressedCommand>().AsSingle().NonLazy();

            Container.BindSignal<ChangeCurrencySignal>().ToMethod<ChangeCurrencyCommand>((x, s) => x.Execute(s)).FromResolve();
            Container.BindSignal<LoadSceneSignal>().ToMethod<LoadSceneCommand>((x, s) => x.Execute(s)).FromResolve();
            Container.BindSignal<PlayHapticSignal>().ToMethod<PlayHapticCommand>((x, s) => x.Execute(s)).FromResolve();
            Container.BindSignal<SettingsButtonPressedSignal>().ToMethod<SettingsButtonPressedCommand>((x, s) => x.Execute(s)).FromResolve();
        }
        #endregion
    }
}