using HiveMind.Core.ProDebug.Runtime.Colorize;
using HiveMind.Core.ProDebug.Runtime.TextFormat;
using HiveMindGameTemplate.Runtime.Factories.Game.Enemy;
using HiveMindGameTemplate.Runtime.Models.Game.Enemy;
using HiveMindGameTemplate.Runtime.Signals.Game;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Handlers.Game.Enemy
{
    public sealed class EnemySpawnHandler : SpawnHandler<EnemyModel, EnemyEntityFactory>
    {
        #region Constructor
        public EnemySpawnHandler(SignalBus signalBus, EnemyModel model, EnemyEntityFactory factory) : base(signalBus, model, factory) => SetSubscriptions(true);
        #endregion

        #region Dispose
        public override void Dispose() => SetSubscriptions(false);
        #endregion

        #region Subscriptions
        protected override void SetSubscriptions(bool isSub)
        {
            if (isSub)
                signalBus.Subscribe<SpawnEnemySignal>(OnSpawnEnemySignal);
            else
                signalBus.Unsubscribe<SpawnEnemySignal>(OnSpawnEnemySignal);
        }
        #endregion

        #region SignalReceivers
        private void OnSpawnEnemySignal(SpawnEnemySignal spawnEnemySignal) => SpawnEnemyProcess(spawnEnemySignal);
        #endregion

        #region Executes
        private void SpawnEnemyProcess(SpawnEnemySignal spawnEnemySignal)
        {
            var enemy = model.GetEnemy(spawnEnemySignal.EnemyType);
            factory?.Create(enemy, spawnEnemySignal.SpawnPosition, Quaternion.identity);

            Debug.Log($"Enemy {enemy.name} spawned!" % Colorize.Red % TextFormat.Italic);
        }
        #endregion
    }
}
