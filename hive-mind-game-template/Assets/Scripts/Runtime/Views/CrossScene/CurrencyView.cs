using System.Collections.Generic;
using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HiveMindGameTemplate.Runtime.Views.CrossScene
{
    public class CurrencyView : View
    {
        #region Fields
        [SerializeField] private Dictionary<CurrencyTypes, TextMeshProUGUI> _currencyTexts;
        [SerializeField] private Dictionary<CurrencyTypes, Button> _currencyButtons;
        #endregion

        #region Getters
        public Dictionary<CurrencyTypes, TextMeshProUGUI> CurrencyTexts => _currencyTexts;
        public Dictionary<CurrencyTypes, Button> CurrencyButtons => _currencyButtons;
        #endregion
    }
}