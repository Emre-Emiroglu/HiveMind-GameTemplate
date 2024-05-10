using HiveMind.Core.CharacterSystem.Runtime.Datas.ScriptableObjects;
using HiveMindGameTemplate.Runtime.Enums.Game.Projectile;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Datas.ScriptableObjects.Game.Player
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "HiveMindGameTemplate/Datas/ScriptableObjects/Game/Player/PlayerSettings")]
    public sealed class PlayerSettings : SerializedScriptableObject
    {
        #region Fields
        [Header("Player Settings Fields")]
        [SerializeField] private CharacterSettings characterSettings;
        [Header("Attack Settings")]
        [SerializeField] private ProjectileTypes attackProjectileType;
        [SerializeField] private int attackProjectileValue;
        [SerializeField] private float attackFireRate;
        [Header("Dash Settings")]
        [SerializeField] private int dashSpeed;
        [SerializeField] private float dashRate;
        [Header("Health Settings")]
        [SerializeField] private int maxHealth;
        #endregion

        #region Getters
        public CharacterSettings CharacterSettings => characterSettings;
        public ProjectileTypes AttackProjectileType => attackProjectileType;
        public int AttackProjectileValue => attackProjectileValue;
        public float AttackFireRate => attackFireRate;
        public int DashSpeed => dashSpeed;
        public float DashRate => dashRate;
        public int MaxHealth => maxHealth;
        #endregion
    }
}
