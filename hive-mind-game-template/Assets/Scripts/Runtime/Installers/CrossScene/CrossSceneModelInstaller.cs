using HiveMindGameTemplate.Runtime.Models.CrossScene;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.CrossScene
{
    public class CrossSceneModelInstaller: Installer
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CrossSceneModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<AudioModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CurrencyModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HapticModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LevelModel>().AsSingle().NonLazy();
        }
        #endregion
    }
}