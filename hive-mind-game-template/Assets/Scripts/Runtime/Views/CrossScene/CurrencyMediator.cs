using System.Linq;
using HiveMind.Core.MVC.Runtime.View;
using HiveMind.Core.Utilities.Runtime.TextFormatter;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using HiveMindGameTemplate.Runtime.Models.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using Lofelt.NiceVibrations;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Views.CrossScene
{
     public class CurrencyMediator : Mediator<CurrencyView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly CurrencyModel _currencyModel;
        #endregion

        #region Constructor
        public CurrencyMediator(CurrencyView view, SignalBus signalBus, CurrencyModel currencyModel) : base(view)
        {
            _signalBus = signalBus;
            _currencyModel = currencyModel;
        }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion

        #region Core
        public override void Initialize()
        {
            RefreshAllCurrencyVisual();

            _signalBus.Subscribe<RefreshCurrencyVisualSignal>(OnRefreshCurrencyVisualSignal);

            _view.CurrencyButtons.Values.ToList().ForEach(x => x.onClick.AddListener(ButtonClicked));
        }
        public override void Dispose()
        {
            _signalBus.Unsubscribe<RefreshCurrencyVisualSignal>(OnRefreshCurrencyVisualSignal);
            
            _view.CurrencyButtons.Values.ToList().ForEach(x => x.onClick.RemoveAllListeners());
        }
        #endregion

        #region SignalReceivers
        private void OnRefreshCurrencyVisualSignal(RefreshCurrencyVisualSignal signal)
        {
            RefreshCurrencyVisual(signal.CurrencyType);
        }
        #endregion

        #region ButtonReceivers
        private void ButtonClicked()
        {
            _signalBus.Fire<ChangeUIPanelSignal>(new(UIPanelTypes.ShopPanel));
            _signalBus.Fire<PlayAudioSignal>(new(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
            _signalBus.Fire<PlayHapticSignal>(new(HapticPatterns.PresetType.LightImpact));
        }
        #endregion

        #region Executes
        private void RefreshAllCurrencyVisual()
        {
            _currencyModel.CurrencyValues.Keys.ToList().ForEach(RefreshCurrencyVisual);
        }
        private void RefreshCurrencyVisual(CurrencyTypes currencyType)
        {
            int value = _currencyModel.CurrencyValues[currencyType];

            _view.CurrencyTexts[currencyType].SetText(TextFormatter.FormatNumber(value));
        }
        #endregion
    }
}