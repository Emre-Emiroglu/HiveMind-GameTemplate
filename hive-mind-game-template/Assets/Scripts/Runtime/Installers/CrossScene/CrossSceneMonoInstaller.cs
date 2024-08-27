using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.CrossScene
{
    public class CrossSceneMonoInstaller : MonoInstaller
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.Install<CrossSceneModelInstaller>();
            Container.Install<CrossScenePanelInstaller>();
            Container.Install<CrossSceneSignalInstaller>();
        }
        #endregion
    }
}
