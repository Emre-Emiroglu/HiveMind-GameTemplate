using HiveMind.Core.CharacterSystem.Runtime.Enums;
using HiveMind.Core.CharacterSystem.Runtime.Handlers.Input;
using HiveMindGameTemplate.Runtime.Enums.Game.Player;
using HiveMindGameTemplate.Runtime.Models.Game.Player;
using UnityEngine.InputSystem;

namespace HiveMindGameTemplate.Runtime.Handlers.Game.Player
{
    public sealed class PlayerInputHandler : InputHandler
    {
        #region ReadonlyFields
        private readonly InputAction attackKeyAction;
        private readonly InputAction dashKeyAction;
        #endregion

        #region Fields
        private ActionStatus actionStatus;
        #endregion

        #region Getters
        public ActionStatus ActionStatus => actionStatus;
        #endregion

        #region Constructor
        public PlayerInputHandler(PlayerModel playerModel) : base(playerModel.Settings.CharacterSettings.InputData)
        {
            attackKeyAction = actionMap.FindAction(inputData.InputActionNames[InputActionNameTypes.AttackKey]);
            dashKeyAction = actionMap.FindAction(inputData.InputActionNames[InputActionNameTypes.DashKey]);

            SetSubscriptionStatus(attackKeyAction, OnAttackKeyActionStarted, OnAttackKeyActionPerformed, OnAttackKeyActionCanceled, true);
            SetSubscriptionStatus(dashKeyAction, OnDashKeyKeyActionStarted, OnDashKeyKeyActionPerformed, OnDashKeyKeyActionCanceled, true);
        }
        #endregion

        #region Dispose
        public override void Dispose()
        {
            base.Dispose();

            SetSubscriptionStatus(attackKeyAction, OnAttackKeyActionStarted, OnAttackKeyActionPerformed, OnAttackKeyActionCanceled, false);
            SetSubscriptionStatus(dashKeyAction, OnDashKeyKeyActionStarted, OnDashKeyKeyActionPerformed, OnDashKeyKeyActionCanceled, false);
        }
        #endregion

        #region Set
        public override void SetEnableStatus(bool isEnable) => base.SetEnableStatus(isEnable);
        #endregion

        #region Executes
        public override void Execute() => base.Execute();
        protected override void ExecuteProcess() => base.ExecuteProcess();
        #endregion

        #region Receivers
        private void OnAttackKeyActionStarted(InputAction.CallbackContext context)
        {
            if (actionStatus == ActionStatus.None)
                actionStatus = ActionStatus.AttackKey;
        }
        private void OnAttackKeyActionPerformed(InputAction.CallbackContext context)
        {
            if (actionStatus == ActionStatus.None)
                actionStatus = ActionStatus.AttackKey;
        }
        private void OnAttackKeyActionCanceled(InputAction.CallbackContext context)
        {
            if (actionStatus == ActionStatus.AttackKey)
                actionStatus = ActionStatus.None;
        }
        private void OnDashKeyKeyActionStarted(InputAction.CallbackContext context)
        {
            if (actionStatus == ActionStatus.None)
                actionStatus = ActionStatus.DashKey;
        }
        private void OnDashKeyKeyActionPerformed(InputAction.CallbackContext context)
        {
            if (actionStatus == ActionStatus.None)
                actionStatus = ActionStatus.DashKey;
        }
        private void OnDashKeyKeyActionCanceled(InputAction.CallbackContext context)
        {
            if (actionStatus == ActionStatus.DashKey)
                actionStatus = ActionStatus.None;
        }
        #endregion
    }
}
