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
        [SerializeField] private UIPanelVo _uiPanelVo;
        [SerializeField] private GameOverPanels _gameOverPanels;
        [SerializeField] private Button _failHomeButton;
        [SerializeField] private Button _successHomeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _nextButton;
        #endregion

        #region Getters
        public UIPanelVo UIPanelVo => _uiPanelVo;
        public GameOverPanels GameOverPanels => _gameOverPanels;
        public Button FailHomeButton => _failHomeButton;
        public Button SuccessHomeButton => _successHomeButton;
        public Button RestartButton => _restartButton;
        public Button NextButton => _nextButton;
        #endregion
    }

    [Serializable]
    public class GameOverPanels : SerializedDictionary<bool, GameObject> { }
}
