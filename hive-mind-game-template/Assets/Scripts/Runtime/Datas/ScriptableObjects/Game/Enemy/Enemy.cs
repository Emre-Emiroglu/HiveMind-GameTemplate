using HiveMind.Core.CharacterSystem.Runtime.Datas.ValueObjects;
using HiveMindGameTemplate.Runtime.Enums.Game.Enemy;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Datas.ScriptableObjects.Game.Enemy
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "HiveMindGameTemplate/Datas/ScriptableObjects/Game/Enemy/Enemy")]
    public sealed class Enemy : SerializedScriptableObject
    {
        #region Fields
        [Header("Enemy Settings")]
        [SerializeField] private EnemyTypes enemyType;
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private int closingDistance = 1;
        [SerializeField] private MovementData movementData;
        [SerializeField] private RotationData rotationData;
        #endregion

        #region Getters
        public EnemyTypes EnemyType => enemyType;
        public int MaxHealth => maxHealth;
        public int ClosingDistance => closingDistance;
        public MovementData MovementData => movementData;
        public RotationData RotationData => rotationData;
        #endregion
    }
}
