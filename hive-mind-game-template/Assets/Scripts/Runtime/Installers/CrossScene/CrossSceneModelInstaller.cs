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
        }
        #endregion
    }
}