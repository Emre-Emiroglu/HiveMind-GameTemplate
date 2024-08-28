using HiveMindGameTemplate.Runtime.Models.Game;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.Game
{
    public class GameModelInstaller : Installer
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<TutorialModel>().AsSingle().NonLazy();
        }
        #endregion
    }
}
