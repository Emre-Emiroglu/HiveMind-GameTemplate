using HiveMind.Core.CharacterSystem.Runtime.Datas.ValueObjects;
using HiveMind.Core.CharacterSystem.Runtime.Enums;
using HiveMind.Core.CharacterSystem.Runtime.Handlers.Movement;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Handlers.Game.Enemy
{
    public class EnemyMovementHandler : TransformMovementHandler
    {
        #region Constructor
        public EnemyMovementHandler() : base(null, new MovementData()) { }
        #endregion

        #region Dispose
        public override void Dispose() => base.Dispose();
        #endregion

        #region Set
        public override void SetEnableStatus(bool isEnable) => base.SetEnableStatus(isEnable);
        public void SetMovementValues(Transform transform, MovementData movementData)
        {
            this.transform = transform;
            this.movementData = movementData;
        }
        #endregion

        #region Executes
        public override void Execute(Vector2 inputValue, MovementStatus movementStatus) => base.Execute(inputValue, movementStatus);
        protected override void ExecuteProcess(Vector2 inputValue, MovementStatus movementStatus) => base.ExecuteProcess(inputValue, movementStatus);
        #endregion
    }
}
