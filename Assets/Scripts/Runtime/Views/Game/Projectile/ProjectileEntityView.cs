using HiveMindGameTemplate.Runtime.Datas.ValueObjects.Game.Projectile;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Views.Game.Projectile
{
    public sealed class ProjectileEntityView : MonoBehaviour
    {
        #region Fields
        [Header("Projectile Entity View Fields")]
        [SerializeField] private ProjectileEntity_VO projectileEntity_VO;
        #endregion

        #region Getters
        public ProjectileEntity_VO ProjectileEntity_VO => projectileEntity_VO;
        #endregion
    }
}
