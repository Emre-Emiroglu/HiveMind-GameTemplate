using HiveMind.Core.MVC.Runtime.Views;
using HiveMindGameTemplate.Runtime.Datas.ValueObjects.UI;
using HiveMindGameTemplate.Runtime.Interfaces.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HiveMindGameTemplate.Runtime.Views.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class HudPanelView : View, IUIPanel
    {
        #region Fields
        [Header("Hud Panel View Fields")]
        [SerializeField] private UIPanel_VO uiPanel_VO;
        [SerializeField] private TextMeshProUGUI waveText;
        [SerializeField] private TextMeshProUGUI enemyCountText;
        [SerializeField] private Image playerHealthFillImage;
        #endregion

        #region Getters
        public UIPanel_VO UIPanel_VO => uiPanel_VO;
        public TextMeshProUGUI WaveText => waveText;
        public TextMeshProUGUI EnemyCountText => enemyCountText;
        public Image PlayerHealthFillImage => playerHealthFillImage;
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
    }
}
