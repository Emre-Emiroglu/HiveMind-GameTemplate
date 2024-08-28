using Zenject;
using Lofelt.NiceVibrations;
using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using HiveMindGameTemplate.Runtime.Models.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.MainMenu;
using HiveMindGameTemplate.Runtime.Utilities.Extensions;

namespace HiveMindGameTemplate.Runtime.Views.MainMenu
{
    public class StartPanelMediator: Mediator<StartPanelView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly LevelModel _levelModel;
        #endregion

        #region Constructor
        public StartPanelMediator(StartPanelView view, SignalBus signalBus, LevelModel levelModel) : base(view)
        {
            _signalBus = signalBus;
            _levelModel = levelModel;
        }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion

        #region Core
        public override void Initialize() => SetCycleSubscriptions(true);
        public override void Dispose() => SetCycleSubscriptions(false);
        #endregion

        #region Subscriptions
        private void SetCycleSubscriptions(bool isSub)
        {
            if (isSub)
            {
                _signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                _view.PlayButton.onClick.AddListener(OnPlayButtonClicked);
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                _view.PlayButton.onClick.RemoveListener(OnPlayButtonClicked);
            }
        }
        #endregion
        
        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal)
        {
            bool isShow = signal.UIPanelType == _view.UIPanelVo.UIPanelType;

            _view.PlayButton.interactable = isShow;

            _view.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(isShow);
            _view.UIPanelVo.PlayableDirector.ChangeUIPanelTimelineActivation(isShow);
            
            if (isShow)
                SetLevelText();
        }
        #endregion

        #region ButtonReceivers
        private void OnPlayButtonClicked()
        {
            _signalBus.Fire<StartPanelPlayButtonClickedSignal>(new());
            _signalBus.Fire<PlayAudioSignal>(new(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
            _signalBus.Fire<PlayHapticSignal>(new(HapticPatterns.PresetType.LightImpact));
        }
        #endregion

        #region Executes
        private void SetLevelText()
        {
            int levelNumber = _levelModel.LevelPersistentData.CurrentLevelIndex + 1;
            _view.LevelText.SetText($"Level {levelNumber}");
        }
        #endregion
    }
}
