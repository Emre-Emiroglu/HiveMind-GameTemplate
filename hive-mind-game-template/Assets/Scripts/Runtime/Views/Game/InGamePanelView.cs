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
        [SerializeField] private UIPanelVo uiPanelVo;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private Transform currencyTrailStartTransform;
        [SerializeField] private Transform currencyTrailTargetTransform;
        [SerializeField] private Button winButton;
        [SerializeField] private Button failButton;
        [SerializeField] private Button addCurrencyButton;
        #endregion

        #region Getters
        public UIPanelVo UIPanelVo => uiPanelVo;
        public TextMeshProUGUI LevelText => levelText;
        public Transform CurrencyTrailStartTransform => currencyTrailStartTransform;
        public Transform CurrencyTrailTargetTransform => currencyTrailTargetTransform;
        public Button WinButton => winButton;
        public Button FailButton => failButton;
        public Button AddCurrencyButton => addCurrencyButton;
        #endregion
    }
}
