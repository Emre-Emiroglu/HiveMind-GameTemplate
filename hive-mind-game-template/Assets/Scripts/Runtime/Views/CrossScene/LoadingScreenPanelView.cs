using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Data.ValueObjects.UI;
using HiveMindGameTemplate.Runtime.Interfaces.UI;
using UnityEngine;
using UnityEngine.UI;

namespace HiveMindGameTemplate.Runtime.Views.CrossScene
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LoadingScreenPanelView : View, IUIPanel
    {
        #region Fields
        [Header("Logo Holder Panel View Fields")]
        [SerializeField] private UIPanelVo uiPanelVo;
        [SerializeField] private Image fillImage;
        #endregion

        #region Getters
        public UIPanelVo UIPanelVo => uiPanelVo;
        public Image FillImage => fillImage;
        #endregion
    }
}
