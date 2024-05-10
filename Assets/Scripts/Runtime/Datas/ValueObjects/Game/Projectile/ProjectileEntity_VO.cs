using HiveMind.Core.Utilities.SerializedDictionary;
using HiveMindGameTemplate.Runtime.Enums.Game.Projectile;
using System;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Datas.ValueObjects.Game.Projectile
{
    [Serializable]
    public struct ProjectileEntity_VO
    {
        #region Fields
        [Header("Projectile Entity VO Fields")]
        [SerializeField] private Transform transform;
        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private ProjectileTypesDictionary types;
        #endregion

        #region Getters
        public readonly Transform Transform => transform;
        public readonly Rigidbody2D Rigidbody => rigidbody;
        public readonly ProjectileTypesDictionary Types => types;
        #endregion
    }

    [Serializable]
    public sealed class ProjectileTypesDictionary : SerializedDictionary<ProjectileTypes, GameObject> { }
}
