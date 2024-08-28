using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HiveMindGameTemplate.Runtime.Views.CrossScene
{
    public class CurrencyTrailView : MonoBehaviour
    {
        #region Fields
        [Header("Currency Trail View Fields")]
        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI amountText;
        #endregion

        #region Getters
        public Image IconImage => iconImage;
        public TextMeshProUGUI AmountText => amountText;
        #endregion
    }
}