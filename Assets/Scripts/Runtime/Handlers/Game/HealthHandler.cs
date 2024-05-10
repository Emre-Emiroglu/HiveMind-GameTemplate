using HiveMind.Core.CharacterSystem.Runtime.Handlers;
using System;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Handlers.Game
{
    public abstract class HealthHandler : Handler<int, bool, Action>
    {
        #region Fields
        protected int currentHealth;
        protected int maxHealth;
        #endregion

        #region Constructor
        public HealthHandler(int currentHealth, int maxHealth) : base()
        {
            this.currentHealth = currentHealth;
            this.maxHealth = maxHealth;
        }
        #endregion

        #region Dispose
        public override void Dispose() => base.Dispose();
        #endregion

        #region Set
        public override void SetEnableStatus(bool isEnable) => base.SetEnableStatus(isEnable);
        #endregion

        #region Executes
        public override void Execute(int amount, bool isSet, Action deadAction) => base.Execute(amount, isSet, deadAction);
        protected override void ExecuteProcess(int amount, bool isSet, Action deadAction) => UpdateHealthValue(amount, isSet, deadAction);
        private void UpdateHealthValue(int amount, bool isSet, Action deadAction = null)
        {
            currentHealth = isSet ? amount : currentHealth + amount;
            currentHealth = Mathf.Min(currentHealth, maxHealth);
            if (currentHealth <= 0)
                deadAction?.Invoke();
        }
        #endregion
    }
}
