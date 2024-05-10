using HiveMindGameTemplate.Runtime.Datas.ValueObjects.Game.Enemy;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Views.Game.Enemy
{
    public sealed class EnemyEntityView : MonoBehaviour
    {
        #region Fields
        [Header("Enemy Entity View Fields")]
        [SerializeField] private EnemyEntity_VO enemyEntity_VO;
        #endregion

        #region Getters
        public EnemyEntity_VO EnemyEntity_VO => enemyEntity_VO;
        #endregion
    }
}
