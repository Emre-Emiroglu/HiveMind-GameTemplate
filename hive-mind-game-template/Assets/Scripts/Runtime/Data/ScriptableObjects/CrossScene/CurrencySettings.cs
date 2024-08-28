using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Data.ScriptableObjects.CrossScene
{
    [CreateAssetMenu(fileName = "CurrencySettings", menuName = " HiveMindGameTemplate/Runtime/Data/ScriptableObjects/CrossScene/CurrencySettings")]
    public class CurrencySettings : SerializedScriptableObject
    {
        #region Fields
        [Header("Currency Settings Fields")]
        [SerializeField] private Dictionary<CurrencyTypes, int> _defaultCurrencyValues;
        [SerializeField] private Dictionary<CurrencyTypes, Sprite> _currencyIcons;
        #endregion

        #region Getters
        public Dictionary<CurrencyTypes, int> DefaultCurrencyValues => _defaultCurrencyValues;
        public Dictionary<CurrencyTypes, Sprite> CurrencyIcons => _currencyIcons;
        #endregion
    }
}
