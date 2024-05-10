using HiveMind.Core.MVC.Attributes;
using HiveMind.Core.MVC.Models;
using HiveMindGameTemplate.Runtime.Datas.ScriptableObjects.Game.Wave;
using HiveMindGameTemplate.Runtime.Datas.ValueObjects.Game.Player;

namespace HiveMindGameTemplate.Runtime.Models.Game.Wave
{
    [Model("Game")]
    public sealed class WaveModel : Model<WaveSettings>
    {
        #region Constants
        private const string resourcePath = "Datas/WaveSettings";
        private const string wavePersisentDataPath = "wavePersisentDataPath";
        #endregion

        #region Fields
        private WavePersisentData wavePersisentData;
        #endregion

        #region Getters
        public WavePersisentData WavePersisentData => wavePersisentData;
        #endregion

        #region Constructor
        public WaveModel() : base(resourcePath)
        {
            wavePersisentData = ES3.Load(nameof(wavePersisentData), wavePersisentDataPath, new WavePersisentData(0));
        }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion

        #region DataExecutes
        public void ResetWavePersisentData()
        {
            wavePersisentData = new(0);

            Save();
        }
        public void UpdateCurrentWaveIndex(bool isSet, int value)
        {
            wavePersisentData.CurrentWaveIndex = isSet ? value : wavePersisentData.CurrentWaveIndex + value;

            Save();
        }
        public void Save()
        {
            ES3.Save(nameof(wavePersisentData), wavePersisentData, wavePersisentDataPath);
        }
        #endregion
    }
}
