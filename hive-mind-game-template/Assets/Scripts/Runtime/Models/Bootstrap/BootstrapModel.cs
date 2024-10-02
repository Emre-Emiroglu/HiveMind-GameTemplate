using HiveMind.Core.MVC.Runtime.Model;
using HiveMindGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap;

namespace HiveMindGameTemplate.Runtime.Models.Bootstrap
{
    public class BootstrapModel : Model<BootstrapSettings>
    {
        #region Constants
        private const string ResourcePath = "Data/Bootstrap/BootstrapSettings";
        #endregion

        #region Constructor
        public BootstrapModel() : base(ResourcePath) { }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion
    }
}
