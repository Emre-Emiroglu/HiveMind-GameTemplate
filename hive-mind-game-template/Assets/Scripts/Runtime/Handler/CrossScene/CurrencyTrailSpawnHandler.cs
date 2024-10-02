using HiveMindGameTemplate.Runtime.Factories;
using HiveMindGameTemplate.Runtime.Models.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Handler.CrossScene
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
        protected sealed override void SetSubscriptions(bool isSub)
        {
            if (isSub)
                SignalBus.Subscribe<SpawnCurrencyTrailSignal>(OnSpawnCurrencyTrailSignal);
            else
                SignalBus.Unsubscribe<SpawnCurrencyTrailSignal>(OnSpawnCurrencyTrailSignal);
        }
        #endregion

        #region SignalReceivers
        private void OnSpawnCurrencyTrailSignal(SpawnCurrencyTrailSignal signal) => SpawnCurrencyTrailProcess(signal);
        #endregion

        #region Executes
        private void SpawnCurrencyTrailProcess(SpawnCurrencyTrailSignal signal)
        {
            Factory.Create(signal.CurrencyTrailData);
        }
        #endregion
    }
}