using HiveMind.Core.CharacterSystem.Runtime.Handlers.Rotation;
using HiveMindGameTemplate.Runtime.Models.Game.Player;
using HiveMindGameTemplate.Runtime.Views.Game.Player;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Handlers.Game.Player
{
    public sealed class PlayerRotationHandler : TopDownRotationHandler
    {
        #region Constructor
        public PlayerRotationHandler(PlayerModel playerModel, PlayerView playerView) : base(Camera.main, playerView.Player_VO.Transform, playerModel.Settings.CharacterSettings.RotationData) { }
        #endregion

        #region Dispose
        public override void Dispose() => base.Dispose();
        #endregion

        #region Set
        public override void SetEnableStatus(bool isEnable) => base.SetEnableStatus(isEnable);
        #endregion

        #region Executes
        public override void Execute(Vector2 inputValue) => base.Execute(inputValue);
        protected override void ExecuteProcess(Vector2 inputValue) => base.ExecuteProcess(inputValue);
        #endregion
    }
}
