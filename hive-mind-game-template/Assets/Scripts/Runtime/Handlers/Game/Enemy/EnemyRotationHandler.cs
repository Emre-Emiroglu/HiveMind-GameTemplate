using HiveMind.Core.CharacterSystem.Runtime.Datas.ValueObjects;
using HiveMind.Core.CharacterSystem.Runtime.Handlers.Rotation;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Handlers.Game.Enemy
{
    public class EnemyRotationHandler : RotationHandler
    {
        #region Constructor
        public EnemyRotationHandler() : base(null, new()) { }
        #endregion

        #region Dispose
        public override void Dispose() => base.Dispose();
        #endregion

        #region Set
        public override void SetEnableStatus(bool isEnable) => base.SetEnableStatus(isEnable);
        public void SetRotationValues(Transform transform, RotationData rotationData)
        {
            this.transform = transform;
            this.rotationData = rotationData;
        }
        #endregion

        #region Executes
        public override void Execute(Vector2 inputValue) => base.Execute(inputValue);
        protected override void ExecuteProcess(Vector2 inputValue)
        {
            base.ExecuteProcess(inputValue);

            float angle = Mathf.Atan2(-inputValue.x, inputValue.y) * Mathf.Rad2Deg;
            float speed = rotationData.RotationSpeed;
            float time = Time.deltaTime;

            Quaternion startRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Quaternion lerpRotation = Quaternion.Slerp(startRotation, targetRotation, speed * time);

            transform.rotation = lerpRotation;
        }
        #endregion
    }
}
