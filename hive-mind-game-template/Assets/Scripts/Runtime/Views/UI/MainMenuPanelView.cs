using HiveMind.Core.MVC.Runtime.Views;
using HiveMindGameTemplate.Runtime.Datas.ValueObjects.UI;
using HiveMindGameTemplate.Runtime.Interfaces.UI;
using UnityEngine;
using UnityEngine.Events;

namespace HiveMindGameTemplate.Runtime.Views.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class MainMenuPanelView : View, IUIPanel
    {
        #region Events
        public UnityAction PlayButtonClicked;
        public UnityAction SettingsButtonClicked;
        public UnityAction ExitButtonClicked;
        #endregion

        #region Fields
        [Header("Main Scene Panel View Fields")]
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
        public void OnPlayButtonClicked() => PlayButtonClicked?.Invoke();
        public void OnSettingsButtonClicked() => SettingsButtonClicked?.Invoke();
        public void OnExitButtonClicked() => ExitButtonClicked?.Invoke();
        #endregion
    }
}
