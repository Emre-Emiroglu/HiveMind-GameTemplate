using HiveMind.Core.MVC.Runtime.Model;
using HiveMindGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;

namespace HiveMindGameTemplate.Runtime.Models.CrossScene
{
    public class CrossSceneModel : Model<CrossSceneSettings>
    {
        #region Constants
        private const string RESOURCE_PATH = "Data/CrossScene/CrossSceneSettings";
        #endregion

        #region Constructor
        public CrossSceneModel() : base(RESOURCE_PATH) { }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion
    }
}
