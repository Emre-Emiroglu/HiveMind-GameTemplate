using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Data.ValueObjects.UI;
using HiveMindGameTemplate.Runtime.Interfaces.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HiveMindGameTemplate.Runtime.Views.Game
{
    [RequireComponent(typeof(CanvasGroup))]
    public class InGamePanelView : View, IUIPanel
    {
        #region Fields
        [Header("In Game Panel View Fields")]
        [SerializeField] private UIPanelVo _uiPanelVo;
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private Transform _currencyTrailStartTransform;
        [SerializeField] private Transform _currencyTrailTargetTransform;
        [SerializeField] private Button _winButton;
        [SerializeField] private Button _failButton;
        [SerializeField] private Button _addCurrencyButton;
        #endregion

        #region Getters
        public UIPanelVo UIPanelVo => _uiPanelVo;
        public TextMeshProUGUI LevelText => _levelText;
        public Transform CurrencyTrailStartTransform => _currencyTrailStartTransform;
        public Transform CurrencyTrailTargetTransform => _currencyTrailTargetTransform;
        public Button WinButton => _winButton;
        public Button FailButton => _failButton;
        public Button AddCurrencyButton => _addCurrencyButton;
        #endregion
    }
}
