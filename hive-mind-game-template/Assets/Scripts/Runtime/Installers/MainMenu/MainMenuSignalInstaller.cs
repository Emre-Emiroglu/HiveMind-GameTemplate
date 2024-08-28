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

            Container.BindInterfacesAndSelfTo<InitializeMainMenuCommand>().AsSingle().NonLazy();

            Container.BindSignal<InitializeMainMenuSignal>().ToMethod<InitializeMainMenuCommand>((x, s) => x.Execute(s)).FromResolve();
        }
        #endregion
    }
}
