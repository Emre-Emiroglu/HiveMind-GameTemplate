using HiveMind.Core.MVC.Runtime.View;
using HiveMind.Core.Utilities.Runtime.SerializedDictionary;
using HiveMindGameTemplate.Runtime.Data.ValueObjects.UI;
using HiveMindGameTemplate.Runtime.Interfaces.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace HiveMindGameTemplate.Runtime.Views.Game
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GameOverPanelView : View, IUIPanel
    {

        #region Fields
        [Header("Game Over Panel View Fields")]
        [SerializeField] private UIPanelVo uiPanelVo;
        [SerializeField] private GameOverPanels gameOverPanels;
        [SerializeField] private Button failHomeButton;
        [SerializeField] private Button successHomeButton;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button nextButton;
        #endregion

        #region Getters
        public UIPanelVo UIPanelVo => uiPanelVo;
        public GameOverPanels GameOverPanels => gameOverPanels;
        public Button FailHomeButton => failHomeButton;
        public Button SuccessHomeButton => successHomeButton;
        public Button RestartButton => restartButton;
        public Button NextButton => nextButton;
        #endregion
    }

    [Serializable]
    public class GameOverPanels : SerializedDictionary<bool, GameObject> { }
}
