using HiveMindGameTemplate.Runtime.Models.Bootstrap;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.Bootstrap
{
    public class BootstrapModelInstaller : Installer
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BootstrapModel>().AsSingle().NonLazy();
        }
        #endregion
    }
}
