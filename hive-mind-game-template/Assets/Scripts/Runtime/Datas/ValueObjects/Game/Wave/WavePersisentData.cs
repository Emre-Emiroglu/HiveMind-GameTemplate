namespace HiveMindGameTemplate.Runtime.Datas.ValueObjects.Game.Player
{
    public struct WavePersisentData
    {
        #region Fields
        public int CurrentWaveIndex;
        #endregion

        #region Constructor
        public WavePersisentData(int currentWaveIndex)
        {
            CurrentWaveIndex = currentWaveIndex;
        }
        #endregion
    }
}
