using HiveMindGameTemplate.Runtime.Models.Game.Player;
using System;

namespace HiveMindGameTemplate.Runtime.Handlers.Game.Player
{
    public sealed class PlayerHealthHandler : HealthHandler
    {
        #region Constructor
        public PlayerHealthHandler(PlayerModel playerModel) : base(playerModel.Settings.MaxHealth, playerModel.Settings.MaxHealth) { }
        #endregion

        #region Dispose
        public override void Dispose() => base.Dispose();
        #endregion

        #region Set
        public override void SetEnableStatus(bool isEnable) => base.SetEnableStatus(isEnable);
        #endregion

        #region Executes
        public override void Execute(int amount, bool isSet, Action deadAction) => base.Execute(amount, isSet, deadAction);
        protected override void ExecuteProcess(int amount, bool isSet, Action deadAction) => base.ExecuteProcess(amount, isSet, deadAction);
        #endregion
    }
}
