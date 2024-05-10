using HiveMind.Core.CharacterSystem.Runtime.Handlers;
using HiveMindGameTemplate.Runtime.Enums.Game.Player;
using HiveMindGameTemplate.Runtime.Models.Game.Player;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Handlers.Game.Player
{
    public sealed class PlayerDashHandler : Handler<ActionStatus, Vector2, Rigidbody2D>
    {
        #region ReadonlyFields
        private readonly PlayerModel playerModel;
        #endregion

        #region Fields
        private bool canDash;
        private float dashTime;
        #endregion

        #region Constructor
        public PlayerDashHandler(PlayerModel playerModel) : base()
        {
            this.playerModel = playerModel;
        }
        #endregion

        #region Dispose
        public override void Dispose() => base.Dispose();
        #endregion

        #region Set
        public override void SetEnableStatus(bool isEnable) => base.SetEnableStatus(isEnable);
        #endregion

        #region Executes
        public override void Execute(ActionStatus actionStatus, Vector2 movementDirection, Rigidbody2D rigidbody2D) => base.Execute(actionStatus, movementDirection, rigidbody2D);
        protected override void ExecuteProcess(ActionStatus actionStatus, Vector2 movementDirection, Rigidbody2D rigidbody2D)
        {
            if (actionStatus == ActionStatus.DashKey)
                Dash(ref canDash, movementDirection, playerModel.Settings.DashSpeed, rigidbody2D);

            CheckDashable(ref canDash, ref dashTime, playerModel.Settings.DashRate);
        }
        private void Dash(ref bool condition, Vector2 movementDirection, float speed, Rigidbody2D rigidbody2D)
        {
            if (condition)
            {
                rigidbody2D.AddForce(movementDirection * speed, ForceMode2D.Impulse);
                condition = false;
            }
        }
        private void CheckDashable(ref bool condition, ref float time, float delay)
        {
            if (!condition)
            {
                time -= Time.deltaTime;
                condition = time < 0f;
                if (condition)
                    time = delay;
            }
        }
        #endregion
    }
}
