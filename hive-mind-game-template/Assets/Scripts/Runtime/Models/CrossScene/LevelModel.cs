using HiveMind.Core.MVC.Runtime.Model;
using HiveMindGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using HiveMindGameTemplate.Runtime.Data.ValueObjects.CrossScene;

namespace HiveMindGameTemplate.Runtime.Models.CrossScene
{
    public class LevelModel : Model<LevelSettings>
    {
        #region Constants
        private const string ResourcePath = "Data/CrossScene/LevelSettings";
        private const string LEVEL_PERSISTENT_DATA_PATH = "LEVEL_PERSISTENT_DATA_PATH";
        #endregion

        #region Fields
        private LevelPersistentData _levelPersistentData;
        #endregion

        #region Getters
        public LevelPersistentData LevelPersistentData => _levelPersistentData;
        #endregion

        #region Constructor
        public LevelModel() : base(ResourcePath)
        {
            _levelPersistentData = ES3.Load(nameof(_levelPersistentData), LEVEL_PERSISTENT_DATA_PATH, new LevelPersistentData(0));

            Save();
        }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion

        #region DataExecutes
        public void ResetLevelPersistentData()
        {
            _levelPersistentData = new(0);

            Save();
        }
        public void UpdateCurrentLevelIndex(bool isSet, int value)
        {
            _levelPersistentData.CurrentLevelIndex = isSet ? value : _levelPersistentData.CurrentLevelIndex + value;

            Save();
        }
        public void Save()
        {
            ES3.Save(nameof(_levelPersistentData), _levelPersistentData, LEVEL_PERSISTENT_DATA_PATH);
        }
        #endregion
    }
}
