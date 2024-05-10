using HiveMindGameTemplate.Runtime.Enums.Game.Projectile;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Datas.ScriptableObjects.Game.Projectile
{
    [CreateAssetMenu(fileName = "Projectile", menuName = "HiveMindGameTemplate/Datas/ScriptableObjects/Game/Projectile/Projectile")]
    public sealed class Projectile : SerializedScriptableObject
    {
        #region Fields
        [Header("Projectile Settings")]
        [SerializeField] private ProjectileTypes projectileType;
        [SerializeField] private ProjectileOwnerTypes ownerType;
        [SerializeField] private float lifeTime = 5f;
        [SerializeField] private float speed = 10f;
        #endregion

        #region Getters
        public ProjectileTypes ProjectileType => projectileType;
        public ProjectileOwnerTypes OwnerType => ownerType;
        public float LifeTime => lifeTime;
        public float Speed => speed;
        #endregion

        #region Props
        public int Value { get; set; }
        #endregion
    }
}
