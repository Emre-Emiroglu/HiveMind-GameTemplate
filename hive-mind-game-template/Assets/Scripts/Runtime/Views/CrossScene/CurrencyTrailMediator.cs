using HiveMindGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using HiveMindGameTemplate.Runtime.Models.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using PrimeTween;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Views.CrossScene
{
    public class CurrencyTrailMediator : MonoBehaviour, IPoolable<CurrencyTrailData, IMemoryPool>
    {
        #region Injects
        private SignalBus _signalBus;
        private CurrencyModel _currencyModel;
        private CurrencyTrailView _view;
        #endregion

        #region Fields
        private IMemoryPool _memoryPool;
        #endregion

        #region PostConstruct
        [Inject]
        private void PostConstruct(SignalBus signalBus, CurrencyModel currencyModel, CurrencyTrailView view)
        {
            _signalBus = signalBus;
            _currencyModel = currencyModel;
            _view = view;
        }
        #endregion

        #region Pool
        public void OnSpawned(CurrencyTrailData data, IMemoryPool memoryPool)
        {
            _memoryPool = memoryPool;
            
            SetVisual(data);
            PlayTween(data);
        }
        public void OnDespawned()
        {
            _memoryPool = null;
        }
        #endregion

        #region Executes
        private void SetVisual(CurrencyTrailData data)
        {
            transform.position = data.StartPosition;
            
            _view.IconImage.sprite = _currencyModel.Settings.CurrencyIcons[data.CurrencyType];
            _view.IconImage.preserveAspect = true;
            
            _view.AmountText.SetText($"{data.Amount}x");
        }
        private void PlayTween(CurrencyTrailData data)
        {
            Tween.Position(transform, data.TargetPosition, data.Duration, data.Ease)
                .OnComplete(() => TweenCompleteCallback(data));
        }
        private void TweenCompleteCallback(CurrencyTrailData data)
        {
            _signalBus.Fire(new ChangeCurrencySignal(data.CurrencyType, data.Amount, false));
            
            _memoryPool.Despawn(this);
        }
        #endregion
    }
}