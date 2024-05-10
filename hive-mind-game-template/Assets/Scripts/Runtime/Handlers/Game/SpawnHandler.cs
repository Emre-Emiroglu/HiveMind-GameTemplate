using System;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Handlers.Game
{
    public abstract class SpawnHandler<TModel, TFactory> : IDisposable
        where TModel : class
        where TFactory : IPlaceholderFactory
    {
        #region ReadonlyFields
        protected readonly SignalBus signalBus;
        protected readonly TModel model;
        protected readonly TFactory factory;
        #endregion

        #region Constructor
        public SpawnHandler(SignalBus signalBus, TModel model, TFactory factory)
        {
            this.signalBus = signalBus;
            this.model = model;
            this.factory = factory;
        }
        #endregion

        #region Dispose
        public abstract void Dispose();
        #endregion

        #region Subscriptions
        protected abstract void SetSubscriptions(bool isSub);
        #endregion
    }
}
