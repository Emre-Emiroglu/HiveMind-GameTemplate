using HiveMind.Core.CharacterSystem.Runtime.Handlers;
using System;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Handlers.Game
{
    public abstract class HealthHandler : Handler<int, bool, Action<int, int, bool>>
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
        public override void Execute(int amount, bool isSet, Action<int, int, bool> healthChangedAction) => base.Execute(amount, isSet, healthChangedAction);
        protected override void ExecuteProcess(int amount, bool isSet, Action<int, int, bool> healthChangedAction) => UpdateHealthValue(amount, isSet, healthChangedAction);
        private void UpdateHealthValue(int amount, bool isSet, Action<int, int, bool> healthChangedAction = null)
        {
            currentHealth = isSet ? amount : currentHealth + amount;
            currentHealth = Mathf.Min(currentHealth, maxHealth);
            
            bool isDead = currentHealth <= 0;

            healthChangedAction?.Invoke(currentHealth, maxHealth, isDead);
        }
        #endregion
    }
}
