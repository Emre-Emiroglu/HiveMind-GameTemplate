using HiveMind.Core.MVC.Runtime.Model;
using HiveMindGameTemplate.Runtime.Data.ScriptableObjects.Application;

namespace HiveMindGameTemplate.Runtime.Models.Application
{
    public class ApplicationModel : Model<ApplicationSettings>
    {
        #region Constants
        private const string ResourcePath = "Data/Application/ApplicationSettings";
        #endregion

        #region Constructor
        public ApplicationModel() : base(ResourcePath) { }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion
    }
}
