using HiveMind.Core.MVC.Runtime.Model;
using HiveMindGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap;

namespace HiveMindGameTemplate.Runtime.Models.Bootstrap
{
    public class BootstrapModel : Model<BootstrapSettings>
    {
        #region Constants
        private const string RESOURCE_PATH = "Data/Bootstrap/BootstrapSettings";
        #endregion

        #region Constructor
        public BootstrapModel() : base(RESOURCE_PATH) { }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion
    }
}
