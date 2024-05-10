using HiveMind.Core.Utilities.SerializedDictionary;
using HiveMindGameTemplate.Runtime.Enums.Game.Enemy;
using System;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Datas.ValueObjects.Game.Enemy
{
    [Serializable]
    public struct EnemyEntity_VO
    {
        #region Fields
        [Header("Ability Entity VO Fields")]
        [SerializeField] private Transform transform;
        [SerializeField] private Rigidbody2D rigidbody2D;
        [SerializeField] private EnemyTypesDictionary types;
        #endregion

        #region Getters
        public readonly Transform Transform => transform;
        public readonly Rigidbody2D Rigidbody2D => rigidbody2D;
        public readonly EnemyTypesDictionary Types => types;
        #endregion
    }

    [Serializable]
    public sealed class EnemyTypesDictionary : SerializedDictionary<EnemyTypes, GameObject> { }
}
