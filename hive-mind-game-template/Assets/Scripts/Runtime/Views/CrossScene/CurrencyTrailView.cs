using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HiveMindGameTemplate.Runtime.Views.CrossScene
{
    public class CurrencyTrailView : MonoBehaviour
    {
        #region Fields
        [Header("Currency Trail View Fields")]
        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _amountText;
        #endregion

        #region Getters
        public Image IconImage => _iconImage;
        public TextMeshProUGUI AmountText => _amountText;
        #endregion
    }
}