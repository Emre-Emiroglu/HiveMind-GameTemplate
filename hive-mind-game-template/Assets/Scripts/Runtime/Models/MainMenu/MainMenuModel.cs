using HiveMind.Core.MVC.Runtime.Model;
using HiveMindGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;

namespace HiveMindGameTemplate.Runtime.Models.MainMenu
{
    public class MainMenuModel : Model<MainMenuSettings>
    {
        #region Constants
        private const string RESOURCE_PATH = "Data/MainMenu/MainMenuSettings";
        #endregion

        #region Constructor
        public MainMenuModel() : base(RESOURCE_PATH) { }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion
    }
}
