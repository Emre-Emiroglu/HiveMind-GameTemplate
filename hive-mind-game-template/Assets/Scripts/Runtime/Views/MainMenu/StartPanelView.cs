using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Data.ValueObjects.UI;
using HiveMindGameTemplate.Runtime.Interfaces.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HiveMindGameTemplate.Runtime.Views.MainMenu
{
    [RequireComponent(typeof(CanvasGroup))]
    public class StartPanelView: View, IUIPanel
    {
        #region Fields
        [Header("Main Scene Panel View Fields")]
        [SerializeField] private UIPanelVo _uiPanelVo;
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private Button _playButton;
        #endregion

        #region Getters
        public UIPanelVo UIPanelVo => _uiPanelVo;
        public TextMeshProUGUI LevelText => _levelText;
        public Button PlayButton => _playButton;
        #endregion
    }
}
