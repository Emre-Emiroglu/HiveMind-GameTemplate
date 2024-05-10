using HiveMindGameTemplate.Runtime.Handlers.Game.Enemy;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.Game.Enemy
{
    public sealed class EnemyInstaller : Installer<EnemyInstaller>
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemyHealthHandler>().AsTransient();
            Container.BindInterfacesAndSelfTo<EnemyMovementHandler>().AsTransient();
            Container.BindInterfacesAndSelfTo<EnemyRotationHandler>().AsTransient();
        }
        #endregion
    }
}
