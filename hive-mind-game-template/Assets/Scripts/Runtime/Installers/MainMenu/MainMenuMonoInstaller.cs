using HiveMindGameTemplate.Runtime.Signals.MainMenu;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.MainMenu
{
    public class MainMenuMonoInstaller : MonoInstaller
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.Install<MainMenuModelInstaller>();
            Container.Install<MainMenuPanelInstaller>();
            Container.Install<MainMenuSignalInstaller>();
        }
        #endregion

        #region Cycle
        public override void Start()
        {
            Container.Resolve<SignalBus>().Fire<InitializeMainMenuSignal>(new());
        }
        #endregion
    }
}
