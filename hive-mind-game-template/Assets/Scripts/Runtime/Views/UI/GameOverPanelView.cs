using HiveMind.Core.MVC.Runtime.Views;
using HiveMindGameTemplate.Runtime.Datas.ValueObjects.UI;
using HiveMindGameTemplate.Runtime.Interfaces.UI;
using UnityEngine;
using UnityEngine.Events;

namespace HiveMindGameTemplate.Runtime.Views.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GameOverPanelView : View, IUIPanel
    {
        #region Events
        public UnityAction HomeButtonClicked;
        #endregion

        #region Fields
        [Header("Game Over Panel View Fields")]
        [SerializeField] private UIPanel_VO uiPanel_VO;
        #endregion

        #region Getters
        public UIPanel_VO UIPanel_VO => uiPanel_VO;
        #endregion

        #region Core
        public void Show() => SetCanvasGroup(true);
        public void Hide() => SetCanvasGroup(false);
        private void SetCanvasGroup(bool isActive)
        {
            float alpha = isActive ? 1f : 0f;
            bool interactable = isActive;
            bool blocksRaycasts = isActive;

            uiPanel_VO.CanvasGroup.alpha = alpha;
            uiPanel_VO.CanvasGroup.interactable = interactable;
            uiPanel_VO.CanvasGroup.blocksRaycasts = blocksRaycasts;
        }
        #endregion

        #region ButtonReceivers
        public void OnHomeButtonClicked() => HomeButtonClicked?.Invoke();
        #endregion
    }
}
