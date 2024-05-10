using HiveMindGameTemplate.Runtime.Handlers.Game.Projectile;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.Game.Projectile
{
    public sealed class ProjectileInstaller : Installer<ProjectileInstaller>
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ProjectileMobilityHandler>().AsTransient();
            Container.BindInterfacesAndSelfTo<ProjectileLifetimeHandler>().AsTransient();
        }
        #endregion
    }
}
