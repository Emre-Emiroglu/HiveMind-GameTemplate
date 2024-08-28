using HiveMindGameTemplate.Runtime.Models.MainMenu;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.MainMenu
{
    public class MainMenuModelInstaller : Installer
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MainMenuModel>().AsSingle().NonLazy();
        }
        #endregion
    }
}
