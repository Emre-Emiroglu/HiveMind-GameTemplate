using HiveMind.Core.MVC.Attributes;
using HiveMind.Core.MVC.Models;
using HiveMindGameTemplate.Runtime.Datas.ScriptableObjects.Game.Projectile;
using HiveMindGameTemplate.Runtime.Enums.Game.Projectile;
using System.Linq;

namespace HiveMindGameTemplate.Runtime.Models.Game.Projectile
{
    [Model("Game")]
    public sealed class ProjectileModel : Model<ProjectileSettings>
    {
        #region Constants
        private const string resourcePath = "Datas/ProjectileSettings";
        #endregion

        #region Getters
        public Datas.ScriptableObjects.Game.Projectile.Projectile GetProjectile(ProjectileTypes projectileType) => settings.Projectiles.First(x => x.ProjectileType == projectileType);
        #endregion

        #region Constructor
        public ProjectileModel() : base(resourcePath) { }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion
    }
}
