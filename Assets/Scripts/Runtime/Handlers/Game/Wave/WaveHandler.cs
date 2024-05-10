using Cysharp.Threading.Tasks;
using HiveMindGameTemplate.Runtime.Datas.ScriptableObjects.Game.Wave;
using HiveMindGameTemplate.Runtime.Enums.Game.Enemy;
using HiveMindGameTemplate.Runtime.Models.Game.Wave;
using HiveMindGameTemplate.Runtime.Signals.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Handlers.Game.Wave
{
    public sealed class WaveHandler : IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus signalBus;
        private readonly WaveModel waveModel;
        #endregion

        #region Fields
        private Dictionary<EnemyTypes, int> currentSpawnCount;
        private Dictionary<EnemyTypes, int> targetSpawnCount;
        private float spawnDelay;
        private int targetEnemyIndex;
        private bool isTimerEnd;
        private int deadEnemyCount;
        #endregion

        #region Getters
        private Datas.ScriptableObjects.Game.Wave.Wave CurrentWave => waveModel.Settings.Waves[waveModel.WavePersisentData.CurrentWaveIndex];
        private EnemyTypes TargetEnemyType => CurrentWave.Enemies.Keys.ToList()[targetEnemyIndex];
        private bool ReachedToTargetCount => currentSpawnCount[TargetEnemyType] == targetSpawnCount[TargetEnemyType];
        private int TotalEnemyCount => CurrentWave.Enemies.Values.ToList().Sum();
        private Vector2 GetRandomSpawnPosition()
        {
            WaveSettings waveSettings = waveModel.Settings;
            Vector2 minimumSpawnPosition = waveSettings.MinimumSpawnPosition;
            Vector2 maximumSpawnPosition = waveSettings.MaximumSpawnPosition;
            float posX = UnityEngine.Random.Range(minimumSpawnPosition.x, maximumSpawnPosition.x);
            float posY = UnityEngine.Random.Range(minimumSpawnPosition.y, maximumSpawnPosition.y);
            return new(posX, posY);
        }
        #endregion

        #region Constructor
        public WaveHandler(SignalBus signalBus, WaveModel waveModel)
        {
            this.signalBus = signalBus;
            this.waveModel = waveModel;

            SetCycleSubscriptions(true);
        }
        #endregion

        #region Dispose
        public void Dispose() => SetCycleSubscriptions(false);
        #endregion

        #region Subscriptions
        private void SetCycleSubscriptions(bool isSub)
        {
            if (isSub)
            {
                signalBus.Subscribe<StartGameSignal>(OnStartGameSignal);
                signalBus.Subscribe<GameOverSignal>(OnGameOverSignal);
            }
            else
            {
                signalBus.Unsubscribe<StartGameSignal>(OnStartGameSignal);
                signalBus.Unsubscribe<GameOverSignal>(OnGameOverSignal);
            }
        }
        private void SetInGameSubscriptions(bool isSub)
        {
            if (isSub)
            {
                signalBus.Subscribe<EnemyDeadSignal>(OnEnemyDeadSignal);
            }
            else
            {
                signalBus.Unsubscribe<EnemyDeadSignal>(OnEnemyDeadSignal);
            }
        }
        #endregion

        #region SignalReceivers
        private void OnStartGameSignal(StartGameSignal startGameSignal)
        {
            SetInGameSubscriptions(true);
            
            ExecuteCurrentWave();
        }
        private void OnGameOverSignal(GameOverSignal gameOverSignal)
        {
            SetInGameSubscriptions(false);
        }
        private void OnEnemyDeadSignal(EnemyDeadSignal enemyDeadSignal)
        {
            WaveWinCheck();
        }
        #endregion

        #region Executes
        private void ExecuteCurrentWave()
        {
            SetupWaveSyncVariables();
            SetupCheckVariables();
            Timer().Forget();
        }
        private void SetupWaveSyncVariables()
        {
            currentSpawnCount = new();
            targetSpawnCount = new();
            foreach (var item in CurrentWave.Enemies)
            {
                currentSpawnCount.Add(item.Key, 0);
                targetSpawnCount.Add(item.Key, item.Value);
            }
            spawnDelay = CurrentWave.SpawnDelay;
        }
        private void SetupCheckVariables()
        {
            targetEnemyIndex = 0;
            isTimerEnd = false;
            deadEnemyCount = 0;
        }
        private void CheckTimerProgress()
        {
            isTimerEnd = targetEnemyIndex == (currentSpawnCount.Count - 1);
            targetEnemyIndex += !isTimerEnd ? 1 : 0;
        }
        private async UniTask Timer()
        {
            int delay = (int)(spawnDelay * 1000);
            double time = 0f;
            while (!isTimerEnd)
            {
                await UniTask.Delay(delay);
                time += spawnDelay;

                currentSpawnCount[TargetEnemyType]++;

                signalBus.Fire(new SpawnEnemySignal(TargetEnemyType, GetRandomSpawnPosition()));

                if (ReachedToTargetCount)
                    CheckTimerProgress();
            }
        }
        private void WaveWinCheck()
        {
            deadEnemyCount++;
            if (isTimerEnd && (deadEnemyCount == TotalEnemyCount))
            {
                SetInGameSubscriptions(false);

                signalBus.Fire<WaveWinSignal>(new());
            }
        }
        #endregion
    }
}
