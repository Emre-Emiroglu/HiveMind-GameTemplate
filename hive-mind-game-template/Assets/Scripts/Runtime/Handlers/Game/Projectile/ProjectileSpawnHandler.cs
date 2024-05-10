using HiveMind.Core.ProDebug.Colorize;
using HiveMind.Core.ProDebug.TextFormat;
using HiveMindGameTemplate.Runtime.Factories.Game.Projectile;
using HiveMindGameTemplate.Runtime.Models.Game.Projectile;
using HiveMindGameTemplate.Runtime.Signals.Game;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Handlers.Game.Projectile
{
    public sealed class ProjectileSpawnHandler : SpawnHandler<ProjectileModel, ProjectileEntityFactory>
    {
        #region Constructor
        public ProjectileSpawnHandler(SignalBus signalBus, ProjectileModel model, ProjectileEntityFactory factory) : base(signalBus, model, factory) => SetSubscriptions(true);
        #endregion

        #region Dispose
        public override void Dispose() => SetSubscriptions(false);
        #endregion

        #region Subscriptions
        protected override void SetSubscriptions(bool isSub)
        {
            if (isSub)
                signalBus.Subscribe<SpawnProjectileSignal>(OnSpawnProjectileSignal);
            else
                signalBus.Unsubscribe<SpawnProjectileSignal>(OnSpawnProjectileSignal);
        }
        #endregion

        #region SignalReceivers
        private void OnSpawnProjectileSignal(SpawnProjectileSignal spawnProjectileSignal) => SpawnProjectileProcess(spawnProjectileSignal);
        #endregion

        #region Executes
        private void SpawnProjectileProcess(SpawnProjectileSignal spawnProjectileSignal)
        {
            var projectile = model.GetProjectile(spawnProjectileSignal.ProjectileType);
            projectile.Value = spawnProjectileSignal.Value;
            factory?.Create(projectile, spawnProjectileSignal.SpawnPosition, spawnProjectileSignal.SpawnRotation);

            Debug.Log($"Projectile {projectile.name} spawned!" % Colorize.Blue % TextFormat.Italic);
        }
        #endregion
    }
}
