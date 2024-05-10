using HiveMind.Core.CharacterSystem.Runtime.Enums;
using HiveMind.Core.CharacterSystem.Runtime.Handlers.Movement;
using HiveMindGameTemplate.Runtime.Models.Game.Player;
using HiveMindGameTemplate.Runtime.Views.Game.Player;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Handlers.Game.Player
{
    public sealed class PlayerMovementHandler : TransformMovementHandler
    {
        #region Constructor
        public PlayerMovementHandler(PlayerModel playerModel, PlayerView playerView) : base(playerView.Player_VO.Transform, playerModel.Settings.CharacterSettings.MovementData) { }
        #endregion

        #region Dispose
        public override void Dispose() => base.Dispose();
        #endregion

        #region Set
        public override void SetEnableStatus(bool isEnable) => base.SetEnableStatus(isEnable);
        #endregion

        #region Executes
        public override void Execute(Vector2 inputValue, MovementStatus movementStatus) => base.Execute(inputValue, movementStatus);
        protected override void ExecuteProcess(Vector2 inputValue, MovementStatus movementStatus) => base.ExecuteProcess(inputValue, movementStatus);
        #endregion
    }
}
