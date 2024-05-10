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
        public override void Execute(int amount, bool isSet, Action<int, int, bool> healthChangedAction) => base.Execute(amount, isSet, healthChangedAction);
        protected override void ExecuteProcess(int amount, bool isSet, Action<int, int, bool> healthChangedAction) => base.ExecuteProcess(amount, isSet, healthChangedAction);
        #endregion
    }
}
