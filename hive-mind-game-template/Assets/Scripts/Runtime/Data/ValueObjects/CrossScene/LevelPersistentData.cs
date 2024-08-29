namespace HiveMindGameTemplate.Runtime.Data.ValueObjects.CrossScene
{
    public struct LevelPersistentData
    {
        #region Fields
        public int CurrentLevelIndex;
        #endregion

        #region Constructor
        public LevelPersistentData(int currentLevelIndex)
        {
            CurrentLevelIndex = currentLevelIndex;
        }
        #endregion
    }
}