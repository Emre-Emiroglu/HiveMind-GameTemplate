using HiveMind.Core.CharacterSystem.Runtime.Handlers;
using HiveMindGameTemplate.Runtime.Enums.Game.Player;
using HiveMindGameTemplate.Runtime.Enums.Game.Projectile;
using HiveMindGameTemplate.Runtime.Models.Game.Player;
using System;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Handlers.Game.Player
{
    public sealed class PlayerAttackHandler : Handler<ActionStatus, Transform, Action<ProjectileTypes, Vector2, Quaternion, int>>
    {
        #region ReadonlyFields
        private readonly PlayerModel playerModel;
        #endregion

        #region Fields
        private bool canAttack;
        private float attackTime;
        #endregion

        #region Constructor
        public PlayerAttackHandler(PlayerModel playerModel) : base()
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
        public override void Execute(ActionStatus actionStatus, Transform playerTransform, Action<ProjectileTypes, Vector2, Quaternion, int> spawnProjectileAction) => base.Execute(actionStatus, playerTransform, spawnProjectileAction);
        protected override void ExecuteProcess(ActionStatus actionStatus, Transform playerTransform, Action<ProjectileTypes, Vector2, Quaternion, int> spawnProjectileAction)
        {
            if (actionStatus == ActionStatus.AttackKey)
                Attack(ref canAttack, playerTransform, spawnProjectileAction);

            CheckAttackable(ref canAttack, ref attackTime, playerModel.Settings.AttackFireRate);
        }
        private void Attack(ref bool condition, Transform playerTransform, Action<ProjectileTypes, Vector2, Quaternion, int> spawnProjectileAction)
        {
            if (condition)
            {
                spawnProjectileAction?.Invoke(playerModel.Settings.AttackProjectileType, playerTransform.position, playerTransform.rotation, playerModel.Settings.AttackProjectileValue);
                condition = false;
            }
        }
        private void CheckAttackable(ref bool condition, ref float time, float delay)
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
