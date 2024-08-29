using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.Game;
using HiveMindGameTemplate.Runtime.Utilities.Extensions;
using Lofelt.NiceVibrations;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Views.Game
{
    public class GameOverPanelMediator : Mediator<GameOverPanelView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion

        #region Constructor
        public GameOverPanelMediator(GameOverPanelView view, SignalBus signalBus) : base(view)
        {
            _signalBus = signalBus;
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
                _signalBus.Subscribe<SetupGameOverPanelSignal>(OnSetupGameOverPanelSignal);

                _view.FailHomeButton.onClick.AddListener(OnHomeButtonClicked);
                _view.SuccessHomeButton.onClick.AddListener(OnHomeButtonClicked);
                _view.RestartButton.onClick.AddListener(OnRestartButtonClicked);
                _view.NextButton.onClick.AddListener(OnNextButtonClicked);
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);
                _signalBus.Unsubscribe<SetupGameOverPanelSignal>(OnSetupGameOverPanelSignal);

                _view.FailHomeButton.onClick.RemoveListener(OnHomeButtonClicked);
                _view.SuccessHomeButton.onClick.RemoveListener(OnHomeButtonClicked);
                _view.RestartButton.onClick.RemoveListener(OnRestartButtonClicked);
                _view.NextButton.onClick.RemoveListener(OnNextButtonClicked);
            }
        }
        #endregion

        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal)
        {
            bool isShow = signal.UIPanelType == _view.UIPanelVo.UIPanelType;
            _view.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(isShow);
            _view.UIPanelVo.PlayableDirector.ChangeUIPanelTimelineActivation(isShow);
        }
        private void OnSetupGameOverPanelSignal(SetupGameOverPanelSignal signal)
        {
            foreach (var item in _view.GameOverPanels)
            {
                bool isActive = item.Key == signal.IsSuccess;
                item.Value.SetActive(isActive);
            }
        }
        #endregion

        #region ButtonReceivers
        private void OnHomeButtonClicked()
        {
            _signalBus.Fire<GameExitSignal>(new());
            _signalBus.Fire<PlayAudioSignal>(new(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
            _signalBus.Fire<PlayHapticSignal>(new(HapticPatterns.PresetType.LightImpact));
        }
        private void OnRestartButtonClicked()
        {
            _signalBus.Fire<PlayGameSignal>(new());
            _signalBus.Fire<PlayAudioSignal>(new(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
            _signalBus.Fire<PlayHapticSignal>(new(HapticPatterns.PresetType.LightImpact));
        }
        private void OnNextButtonClicked()
        {
            _signalBus.Fire<PlayGameSignal>(new());
            _signalBus.Fire<PlayAudioSignal>(new(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
            _signalBus.Fire<PlayHapticSignal>(new(HapticPatterns.PresetType.LightImpact));
        }
        #endregion
    }
}
