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

            Container.BindInterfacesAndSelfTo<LoadSceneCommand>().AsSingle().NonLazy();

            Container.BindSignal<LoadSceneSignal>().ToMethod<LoadSceneCommand>((x, s) => x.Execute(s)).FromResolve();
        }
        #endregion
    }
}