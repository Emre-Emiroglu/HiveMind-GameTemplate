using HiveMindGameTemplate.Runtime.Enums.UI;
using System;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Datas.ValueObjects.UI
{
    [Serializable]
    public struct UIPanel_VO
    {
        #region Fields
        [Header("UI Panel VO Fields")]
        [SerializeField] private UIPanelTypes uiPanelType;
        [SerializeField] private CanvasGroup canvasGroup;
        #endregion

        #region Getters
        public readonly UIPanelTypes UIPanelType => uiPanelType;
        public readonly CanvasGroup CanvasGroup => canvasGroup;
        #endregion
    }
}
