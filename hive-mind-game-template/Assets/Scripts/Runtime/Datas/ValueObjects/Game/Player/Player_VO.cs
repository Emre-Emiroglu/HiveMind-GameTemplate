using System;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Datas.ValueObjects.Game.Player
{
    [Serializable]
    public struct Player_VO
    {
        #region Fields
        [Header("Player VO Fields")]
        [SerializeField] private Transform transform;
        [SerializeField] private Rigidbody2D rigidbody2D;
        #endregion

        #region Getters
        public readonly Transform Transform => transform;
        public readonly Rigidbody2D Rigidbody2D => rigidbody2D;
        #endregion
    }
}
