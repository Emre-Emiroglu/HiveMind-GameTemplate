using HiveMind.Core.MVC.Runtime.Controller;
using HiveMindGameTemplate.Runtime.Models.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Controllers.CrossScene
{
    public class ChangeCurrencyCommand : Command<ChangeCurrencySignal>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly CurrencyModel _currencyModel;
        #endregion

        #region Constructor
        public ChangeCurrencyCommand(SignalBus signalBus, CurrencyModel currencyModel)
        {
            _signalBus = signalBus;
            _currencyModel = currencyModel;
        }
        #endregion

        #region Executes
        public override void Execute(ChangeCurrencySignal signal)
        {
            _currencyModel.ChangeCurrencyValue(signal.CurrencyType, signal.Amount, signal.IsSet);

            _signalBus.Fire<RefreshCurrencyVisualSignal>(new(signal.CurrencyType));
        }
        #endregion
    }
}
