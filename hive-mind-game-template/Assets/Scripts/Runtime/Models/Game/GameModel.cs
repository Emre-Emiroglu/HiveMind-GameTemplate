using HiveMind.Core.MVC.Runtime.Model;
using HiveMindGameTemplate.Runtime.Data.ScriptableObjects.Game;

namespace HiveMindGameTemplate.Runtime.Models.Game
{
    public class GameModel : Model<GameSettings>
    {
        #region Constants
        private const string ResourcePath = "Data/Game/GameSettings";
        #endregion

        #region Constructor
        public GameModel() : base(ResourcePath) { }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion
    }
}
