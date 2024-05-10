using Sirenix.OdinInspector;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Datas.ScriptableObjects.Game.Projectile
{
    [CreateAssetMenu(fileName = "ProjectileSettings", menuName = "HiveMindGameTemplate/Datas/ScriptableObjects/Game/Projectile/ProjectileSettings")]
    public sealed class ProjectileSettings : SerializedScriptableObject
    {
        #region Fields
        [Header("Projectile Settings Fields")]
        [SerializeField] private Projectile[] projectiles;
        #endregion

        #region Getters
        public Projectile[] Projectiles => projectiles;
        #endregion
    }
}
