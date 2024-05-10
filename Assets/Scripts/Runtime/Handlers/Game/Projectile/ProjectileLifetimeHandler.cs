using Cysharp.Threading.Tasks;
using HiveMind.Core.CharacterSystem.Runtime.Handlers;
using System;
using System.Threading;

namespace HiveMindGameTemplate.Runtime.Handlers.Game.Projectile
{
    public sealed class ProjectileLifetimeHandler : Handler<float, Action>
    {
        #region Fields
        private CancellationTokenSource cancellationTokenSource;
        #endregion

        #region Constructor
        public ProjectileLifetimeHandler() : base() { }
        #endregion

        #region Dispose
        public override void Dispose()
        {
            base.Dispose();

            cancellationTokenSource?.Cancel();
        }
        #endregion

        #region Set
        public override void SetEnableStatus(bool isEnable) => base.SetEnableStatus(isEnable);
        #endregion

        #region Executes
        public override void Execute(float lifeTime, Action deadAction) => base.Execute(lifeTime, deadAction);
        protected override void ExecuteProcess(float lifeTime, Action deadAction) => LifeTime(lifeTime, deadAction).Forget();
        private async UniTask LifeTime(float lifeTime, Action deadAction)
        {
            cancellationTokenSource = new();

            int delay = (int)(lifeTime * 1000);

            await UniTask.Delay(delay, cancellationToken: cancellationTokenSource.Token);

            deadAction?.Invoke();
        }
        #endregion
    }
}
