using HiveMind.Core.MVC.Runtime.Attributes;
using HiveMind.Core.MVC.Runtime.Models;
using HiveMindGameTemplate.Runtime.Datas.ScriptableObjects.Game.Player;

namespace HiveMindGameTemplate.Runtime.Models.Game.Player
{
    [Model("Game")]
    public sealed class PlayerModel : Model<PlayerSettings>
    {
        #region Constants
        private const string resourcePath = "Datas/PlayerSettings";
        #endregion

        #region Constructor
        public PlayerModel() : base(resourcePath) { }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion
    }
}
