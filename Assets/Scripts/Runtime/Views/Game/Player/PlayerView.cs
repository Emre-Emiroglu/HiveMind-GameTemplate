using HiveMind.Core.MVC.Views;
using HiveMindGameTemplate.Runtime.Datas.ValueObjects.Game.Player;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Views.Game.Player
{
    public sealed class PlayerView : View
    {
        #region Fields
        [Header("Player View Fields")]
        [SerializeField] private Player_VO player_VO;
        #endregion

        #region Getters
        public Player_VO Player_VO => player_VO;
        #endregion
    }
}
