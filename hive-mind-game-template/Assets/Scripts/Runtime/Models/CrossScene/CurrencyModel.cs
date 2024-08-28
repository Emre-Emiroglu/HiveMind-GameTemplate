using HiveMind.Core.MVC.Runtime.Model;
using HiveMindGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using System.Collections.Generic;

namespace HiveMindGameTemplate.Runtime.Models.CrossScene
{
    public class CurrencyModel : Model<CurrencySettings>
    {
        #region Constants
        private const string ResourcePath = "Data/CrossScene/CurrencySettings";
        private const string CurrencyPath = "CURRENCY_PATH";
        #endregion

        #region Fields
        private Dictionary<CurrencyTypes, int> _currencyValues;
        #endregion

        #region Getters
        public Dictionary<CurrencyTypes, int> CurrencyValues => _currencyValues;
        #endregion

        #region Constructor
        public CurrencyModel() : base(ResourcePath)
        {
            _currencyValues = ES3.Load(nameof(_currencyValues), CurrencyPath, new Dictionary<CurrencyTypes, int>(_settings.DefaultCurrencyValues));

            SaveCurrencyValues();
        }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion

        #region Executes
        public void ChangeCurrencyValue(CurrencyTypes currencyType, int amount, bool isSet)
        {
            int lasValue = _currencyValues[currencyType];
            _currencyValues[currencyType] = isSet ? amount : lasValue + amount;

            SaveCurrencyValues();
        }
        private void SaveCurrencyValues() => ES3.Save(nameof(_currencyValues), _currencyValues, CurrencyPath);
        #endregion
    }
}
