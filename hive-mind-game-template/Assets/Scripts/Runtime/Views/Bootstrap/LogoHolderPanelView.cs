using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Data.ValueObjects.UI;
using HiveMindGameTemplate.Runtime.Interfaces.UI;
using UnityEngine;
using UnityEngine.UI;

namespace HiveMindGameTemplate.Runtime.Views.Bootstrap
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LogoHolderPanelView : View, IUIPanel
    {
        #region Fields
        [Header("Logo Holder Panel View Fields")]
        [SerializeField] private UIPanelVo _uiPanelVo;
        [SerializeField] private Image _logoImage;
        #endregion

        #region Getters
        public UIPanelVo UIPanelVo => _uiPanelVo;
        public Image LogoImage => _logoImage;
        #endregion
    }
}
