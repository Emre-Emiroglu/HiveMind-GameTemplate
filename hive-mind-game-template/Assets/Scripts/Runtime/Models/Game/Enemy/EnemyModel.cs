using HiveMind.Core.MVC.Attributes;
using HiveMind.Core.MVC.Models;
using HiveMindGameTemplate.Runtime.Datas.ScriptableObjects.Game.Enemy;
using HiveMindGameTemplate.Runtime.Enums.Game.Enemy;
using System.Linq;

namespace HiveMindGameTemplate.Runtime.Models.Game.Enemy
{
    [Model("Game")]
    public sealed class EnemyModel : Model<EnemySettings>
    {
        #region Constants
        private const string resourcePath = "Datas/EnemySettings";
        #endregion

        #region Gettters
        public Datas.ScriptableObjects.Game.Enemy.Enemy GetEnemy(EnemyTypes enemyType) => settings.Enemies.First(x => x.EnemyType == enemyType);
        #endregion

        #region Constructor
        public EnemyModel() : base(resourcePath) { }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion
    }
}
