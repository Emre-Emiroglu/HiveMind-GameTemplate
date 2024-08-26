using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Data.ValueObjects.UI;
using HiveMindGameTemplate.Runtime.Interfaces.UI;
using UnityEngine;
using UnityEngine.UI;

namespace HiveMindGameTemplate.Runtime
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LogoHolderPanelView : View, IUIPanel
    {
        #region Fields
        [Header("Logo Holder Panel View Fields")]
        [SerializeField] private Image _logoImage;
        [SerializeField] private UIPanelVo _uiPanelVo;
        #endregion

        #region Getters
        public Image LogoImage => _logoImage;

        public UIPanelVo UIPanelVo => _uiPanelVo;
        #endregion
    }
}
