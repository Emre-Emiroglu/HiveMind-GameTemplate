using Sirenix.OdinInspector;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Datas.ScriptableObjects.Game.Wave
{
    [CreateAssetMenu(fileName = "WaveSettings", menuName = "HiveMindGameTemplate/Datas/ScriptableObjects/Game/Wave/WaveSettings")]
    public sealed class WaveSettings : SerializedScriptableObject
    {
        #region Fields
        [Header("Wave Settings Fields")]
        [SerializeField] private Wave[] waves;
        [SerializeField] private Vector2 minimumSpawnPosition;
        [SerializeField] private Vector2 maximumSpawnPosition;
        #endregion

        #region Getters
        public Wave[] Waves => waves;
        public Vector2 MinimumSpawnPosition => minimumSpawnPosition;
        public Vector2 MaximumSpawnPosition => maximumSpawnPosition;
        #endregion
    }
}
