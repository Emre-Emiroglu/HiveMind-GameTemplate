using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using PrimeTween;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Data.ValueObjects.CrossScene
{
    public struct CurrencyTrailData
    {
        #region ReadonlyFields
        private readonly CurrencyTypes _currencyType;
        private readonly int _amount;
        private readonly float _duration;
        private readonly Ease _ease;
        private readonly Transform _startPoint;
        private readonly Transform _targetPoint;
        #endregion

        #region Getters
        public CurrencyTypes CurrencyType => _currencyType;
        public int Amount => _amount;
        public float Duration => _duration;
        public Ease Ease => _ease;
        public Transform StartPoint => _startPoint;
        public Transform TargetPoint => _targetPoint;
        #endregion

        #region Constructor
        public CurrencyTrailData(CurrencyTypes currencyType, int amount, float duration, Ease ease, Transform startPoint, Transform targetPoint)
        {
            _currencyType = currencyType;
            _amount = amount;
            _duration = duration;
            _ease = ease;
            _startPoint = startPoint;
            _targetPoint = targetPoint;
        }
        #endregion
    }
}