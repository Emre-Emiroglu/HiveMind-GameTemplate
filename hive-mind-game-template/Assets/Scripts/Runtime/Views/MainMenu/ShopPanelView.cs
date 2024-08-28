using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Data.ValueObjects.UI;
using HiveMindGameTemplate.Runtime.Interfaces.UI;
using UnityEngine;
using UnityEngine.UI;

namespace HiveMindGameTemplate.Runtime.Views.MainMenu
{
    [RequireComponent(typeof(CanvasGroup))]
    public class ShopPanelView : View, IUIPanel
    {
        #region Fields
        [Header("Shop Panel View Fields")]
        [SerializeField] private UIPanelVo _uiPanelVo;
        [SerializeField] private Button _homeButton;
        #endregion

        #region Getters
        public UIPanelVo UIPanelVo => _uiPanelVo;
        public Button HomeButton => _homeButton;
        #endregion
    }
}
