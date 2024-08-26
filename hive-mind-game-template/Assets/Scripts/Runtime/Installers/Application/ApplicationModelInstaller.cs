using HiveMindGameTemplate.Runtime.Models.Application;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.Application
{
    public class ApplicationModelInstaller : Installer
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ApplicationModel>().AsSingle().NonLazy();
        }
        #endregion
    }
}
