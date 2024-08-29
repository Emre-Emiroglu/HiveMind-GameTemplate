using HiveMindGameTemplate.Runtime.Factories;
using HiveMindGameTemplate.Runtime.Models.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Handlers.CrossScene
{
    public class CurrencyTrailSpawnHandler : SpawnHandler<CurrencyModel, CurrencyTrailFactory>
    {
        #region Constructor
        public CurrencyTrailSpawnHandler(SignalBus signalBus, CurrencyModel model, CurrencyTrailFactory factory) : base(signalBus, model, factory) => SetSubscriptions(true);
        #endregion

        #region Dispose
        public override void Dispose() => SetSubscriptions(false);
        #endregion

        #region Subscriptions
        protected override void SetSubscriptions(bool isSub)
        {
            if (isSub)
                signalBus.Subscribe<SpawnCurrencyTrailSignal>(OnSpawnCurrencyTrailSignal);
            else
                signalBus.Unsubscribe<SpawnCurrencyTrailSignal>(OnSpawnCurrencyTrailSignal);
        }
        #endregion

        #region SignalReceivers
        private void OnSpawnCurrencyTrailSignal(SpawnCurrencyTrailSignal signal) => SpawnCurrencyTrailProcess(signal);
        #endregion

        #region Executes
        private void SpawnCurrencyTrailProcess(SpawnCurrencyTrailSignal signal)
        {
            factory.Create(signal.CurrencyTrailData);
        }
        #endregion
    }
}