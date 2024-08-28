using HiveMindGameTemplate.Runtime.Signals.Game;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.Game
{
    public class GameMonoInstaller : MonoInstaller
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.Install<GameModelInstaller>();
            Container.Install<GamePanelInstaller>();
            Container.Install<GameSignalInstaller>();
        }
        #endregion

        #region Cycle
        public override void Start()
        {
            Container.Resolve<SignalBus>().Fire<InitializeGameSignal>(new());
        }
        #endregion
    }
}
