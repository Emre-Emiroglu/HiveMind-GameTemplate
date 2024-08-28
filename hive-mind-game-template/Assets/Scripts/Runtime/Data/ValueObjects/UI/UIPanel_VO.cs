using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using System;
using UnityEngine;
using UnityEngine.Playables;

namespace HiveMindGameTemplate.Runtime.Data.ValueObjects.UI
{
    [Serializable]
    public struct UIPanelVo
    {
        #region Fields
        [Header("UI Panel VO Fields")]
        [SerializeField] private UIPanelTypes _uiPanelType;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private PlayableDirector playableDirector;
        #endregion

        #region Getters
        public readonly UIPanelTypes UIPanelType => _uiPanelType;
        public readonly CanvasGroup CanvasGroup => canvasGroup;
        public readonly PlayableDirector PlayableDirector => playableDirector;
        #endregion
    }
}
