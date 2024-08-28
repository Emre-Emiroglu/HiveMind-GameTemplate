using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Data.ValueObjects.UI;
using HiveMindGameTemplate.Runtime.Interfaces.UI;
using UnityEngine;
using UnityEngine.UI;

namespace HiveMindGameTemplate.Runtime.Views.Game
{
    [RequireComponent(typeof(CanvasGroup))]
    public class TutorialPanelView : View, IUIPanel
    {
        #region Fields
        [Header("Shop Panel View Fields")]
        [SerializeField] private UIPanelVo _uiPanelVo;
        [SerializeField] private Button _closeButton;
        #endregion

        #region Getters
        public UIPanelVo UIPanelVo => _uiPanelVo;
        public Button CloseButton => _closeButton;
        #endregion
    }
}
