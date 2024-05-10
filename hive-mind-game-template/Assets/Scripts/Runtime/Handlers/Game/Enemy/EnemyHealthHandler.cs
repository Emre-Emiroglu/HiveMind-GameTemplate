using System;

namespace HiveMindGameTemplate.Runtime.Handlers.Game.Enemy
{
    public class EnemyHealthHandler : HealthHandler
    {
        #region Constructor
        public EnemyHealthHandler() : base(100, 100) { }
        #endregion

        #region Dispose
        public override void Dispose() => base.Dispose();
        #endregion

        #region Set
        public override void SetEnableStatus(bool isEnable) => base.SetEnableStatus(isEnable);
        public void SetHealthValues(int currentHealth, int maxHealth)
        {
            this.currentHealth = currentHealth;
            this.maxHealth = maxHealth;
        }
        #endregion

        #region Executes
        public override void Execute(int amount, bool isSet, Action<int, int, bool> healthChangedAction) => base.Execute(amount, isSet, healthChangedAction);
        protected override void ExecuteProcess(int amount, bool isSet, Action<int, int, bool> healthChangedAction) => base.ExecuteProcess(amount, isSet, healthChangedAction);
        #endregion
    }
}
