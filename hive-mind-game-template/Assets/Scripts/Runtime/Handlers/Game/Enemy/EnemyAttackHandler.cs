using HiveMind.Core.CharacterSystem.Runtime.Handlers;
using HiveMindGameTemplate.Runtime.Enums.Game.Enemy;
using HiveMindGameTemplate.Runtime.Enums.Game.Projectile;
using System;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Handlers.Game.Enemy
{
    public class EnemyAttackHandler : Handler<Action<int>, Action<ProjectileTypes, Vector2, Quaternion, int>>
    {
        #region Fields
        private Transform transform;
        private Datas.ScriptableObjects.Game.Enemy.Enemy enemy;
        private bool canAttack;
        private float attackTime;
        #endregion

        #region Constructor
        public EnemyAttackHandler() : base() { }
        #endregion

        #region Dispose
        public override void Dispose() => base.Dispose();
        #endregion

        #region Set
        public override void SetEnableStatus(bool isEnable) => base.SetEnableStatus(isEnable);
        public void SetAttackValues(Transform transform, Datas.ScriptableObjects.Game.Enemy.Enemy enemy)
        {
            this.transform = transform;
            this.enemy = enemy;

            canAttack = false;
            attackTime = 0f;
        }
        #endregion

        #region Executes
        public override void Execute(Action<int> meleAttackAction, Action<ProjectileTypes, Vector2, Quaternion, int> spawnProjectileAction) => base.Execute(meleAttackAction, spawnProjectileAction);
        protected override void ExecuteProcess(Action<int> meleAttackAction, Action<ProjectileTypes, Vector2, Quaternion, int> spawnProjectileAction)
        {
            switch (enemy.AttackType)
            {
                case EnemyAttackTypes.Mele:
                    MeleAttack(ref canAttack, meleAttackAction);
                    break;
                case EnemyAttackTypes.Range:
                    RangeAttack(ref canAttack, spawnProjectileAction);
                    break;
            }

            CheckAttackable(ref canAttack, ref attackTime, enemy.RateOfAttack);
        }
        private void MeleAttack(ref bool condition, Action<int> meleAttackAction)
        {
            if (condition)
            {
                meleAttackAction?.Invoke(enemy.AttackValue);
                condition = false;
            }
        }
        private void RangeAttack(ref bool condition, Action<ProjectileTypes, Vector2, Quaternion, int> spawnProjectileAction)
        {
            if (condition)
            {
                spawnProjectileAction?.Invoke(enemy.ProjectileType, transform.position, transform.rotation, enemy.AttackValue);
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
