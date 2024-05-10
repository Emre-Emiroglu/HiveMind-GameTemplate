using Sirenix.OdinInspector;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Datas.ScriptableObjects.Game.Enemy
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "HiveMindGameTemplate/Datas/ScriptableObjects/Game/Enemy/EnemySettings")]
    public sealed class EnemySettings : SerializedScriptableObject
    {
        #region Fields
        [Header("Enemy Settings Fields")]
        [SerializeField] private Enemy[] enemies;
        #endregion

        #region Getters
        public Enemy[] Enemies => enemies;
        #endregion
    }
}
