using HiveMind.Core.MVC.Runtime.Model;
using HiveMindGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;

namespace HiveMindGameTemplate.Runtime.Models.CrossScene
{
    public class CrossSceneModel : Model<CrossSceneSettings>
    {
        #region Constants
        private const string ResourcePath = "Data/CrossScene/CrossSceneSettings";
        #endregion

        #region Constructor
        public CrossSceneModel() : base(ResourcePath) { }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion
    }
}
