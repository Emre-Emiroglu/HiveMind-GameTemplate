using HiveMind.Core.MVC.Runtime.Model;
using HiveMindGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;

namespace HiveMindGameTemplate.Runtime.Models.CrossScene
{
    public class HapticModel : Model<HapticSettings>
    {
        #region Constants
        private const string ResourcePath = "Data/CrossScene/HapticSettings";
        private const string HapticPath = "HAPTIC_PATH";
        #endregion

        #region Fields
        private bool _isHapticMuted;
        #endregion

        #region Getters
        public bool IsHapticMuted => _isHapticMuted;
        #endregion

        #region Constructor
        public HapticModel() : base(ResourcePath)
        {
            _isHapticMuted = ES3.Load(nameof(_isHapticMuted), HapticPath, false);

            SetHaptic(_isHapticMuted);
        }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion

        #region Executes
        public void SetHaptic(bool isActive)
        {
            _isHapticMuted = isActive;
            
            Save();
        }
        public void Save()
        {
            ES3.Save(nameof(_isHapticMuted), _isHapticMuted, HapticPath);
        }
        #endregion
    }
}
