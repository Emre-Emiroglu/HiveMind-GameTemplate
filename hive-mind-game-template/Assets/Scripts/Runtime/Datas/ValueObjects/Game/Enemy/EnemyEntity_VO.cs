using HiveMind.Core.Utilities.Runtime.SerializedDictionary;
using HiveMindGameTemplate.Runtime.Enums.Game.Enemy;
using System;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Datas.ValueObjects.Game.Enemy
{
    [Serializable]
    public struct EnemyEntity_VO
    {
        #region Fields
        [Header("Enemy Entity VO Fields")]
        [SerializeField] private Transform transform;
        [SerializeField] private Rigidbody2D rigidbody2D;
        [SerializeField] private EnemyTypesDictionary types;
        [SerializeField] private EnemyHealthBarsDictionary healthBars;
        #endregion

        #region Getters
        public readonly Transform Transform => transform;
        public readonly Rigidbody2D Rigidbody2D => rigidbody2D;
        public readonly EnemyTypesDictionary Types => types;
        public readonly EnemyHealthBarsDictionary HealthBars => healthBars;
        #endregion
    }

    [Serializable]
    public sealed class EnemyTypesDictionary : SerializedDictionary<EnemyTypes, GameObject> { }
    [Serializable]
    public sealed class EnemyHealthBarsDictionary : SerializedDictionary<EnemyTypes, GameObject> { }
}
