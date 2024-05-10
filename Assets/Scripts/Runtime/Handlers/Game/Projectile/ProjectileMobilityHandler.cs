using HiveMind.Core.CharacterSystem.Runtime.Handlers;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Handlers.Game.Projectile
{
    public sealed class ProjectileMobilityHandler : Handler<Rigidbody2D, Transform, float>
    {
        #region Constructor
        public ProjectileMobilityHandler() : base() { }
        #endregion

        #region Dispose
        public override void Dispose() => base.Dispose();
        #endregion

        #region Set
        public override void SetEnableStatus(bool isEnable) => base.SetEnableStatus(isEnable);
        #endregion

        #region Executes
        public override void Execute(Rigidbody2D rigidbody, Transform transform, float speed) => base.Execute(rigidbody, transform, speed);
        protected override void ExecuteProcess(Rigidbody2D rigidbody, Transform transform, float speed)
        {
            rigidbody.AddRelativeForce(transform.up * speed, ForceMode2D.Impulse);
        }
        #endregion
    }
}
