using HiveMindGameTemplate.Runtime.Enums.Game.Enemy;
using HiveMindGameTemplate.Runtime.Enums.Game.Wave;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Datas.ScriptableObjects.Game.Wave
{
    [CreateAssetMenu(fileName = "Wave", menuName = "HiveMindGameTemplate/Datas/ScriptableObjects/Game/Wave/Wave")]
    public sealed class Wave : SerializedScriptableObject
    {
        #region Fields
        [Header("Wave Settings")]
        [SerializeField] private WaveTypes waveType;
        [SerializeField] private Dictionary<EnemyTypes, int> enemies;
        [SerializeField] private float spawnDelay = .1f;
        #endregion

        #region Getters
        public WaveTypes WaveType => waveType;
        public Dictionary<EnemyTypes, int> Enemies => enemies;
        public float SpawnDelay => spawnDelay;
        #endregion
    }
}
