using System;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Handler
{
    public abstract class SpawnHandler<TModel, TFactory> : IDisposable
         where TModel : class
         where TFactory : IPlaceholderFactory
    {
        #region ReadonlyFields
        protected readonly SignalBus SignalBus;
        protected readonly TModel Model;
        protected readonly TFactory Factory;
        #endregion

        #region Constructor
        public SpawnHandler(SignalBus signalBus, TModel model, TFactory factory)
        {
            this.SignalBus = signalBus;
            this.Model = model;
            this.Factory = factory;
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
