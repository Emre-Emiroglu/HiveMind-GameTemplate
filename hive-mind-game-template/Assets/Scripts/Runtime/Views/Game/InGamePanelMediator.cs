using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using HiveMindGameTemplate.Runtime.Models.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.Game;
using HiveMindGameTemplate.Runtime.Utilities.Extensions;
using Lofelt.NiceVibrations;
using PrimeTween;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Views.Game
{
    public class InGamePanelMediator : Mediator<InGamePanelView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly LevelModel _levelModel;
        #endregion

        #region Constructor
        public InGamePanelMediator(InGamePanelView view, SignalBus signalBus, LevelModel levelModel) : base(view)
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

                _view.WinButton.onClick.AddListener(OnWinButtonPressed);
                _view.FailButton.onClick.AddListener(OnFailButtonPressed);
                _view.AddCurrencyButton.onClick.AddListener(OnAddCurrencyButtonPressed);
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                _view.WinButton.onClick.RemoveListener(OnWinButtonPressed);
                _view.FailButton.onClick.RemoveListener(OnFailButtonPressed);
                _view.AddCurrencyButton.onClick.RemoveListener(OnAddCurrencyButtonPressed);
            }
        }
        #endregion

        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal)
        {
            bool isShow = signal.UIPanelType == _view.UIPanelVo.UIPanelType;
            _view.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(isShow);
            _view.UIPanelVo.PlayableDirector.ChangeUIPanelTimelineActivation(isShow);

            if (isShow)
                SetLevelText();
        }
        #endregion

        #region ButtonReceivers
        private void OnWinButtonPressed()
        {
            _signalBus.Fire<GameOverSignal>(new(true));
            _signalBus.Fire<PlayAudioSignal>(new(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
            _signalBus.Fire<PlayHapticSignal>(new(HapticPatterns.PresetType.LightImpact));
        }
        private void OnFailButtonPressed()
        {
            _signalBus.Fire<GameOverSignal>(new(false));
            _signalBus.Fire<PlayAudioSignal>(new(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
            _signalBus.Fire<PlayHapticSignal>(new(HapticPatterns.PresetType.LightImpact));
        }
        private void OnAddCurrencyButtonPressed()
        {
            _signalBus.Fire<SpawnCurrencyTrailSignal>(new(new(CurrencyTypes.Coin,
                                                              1,
                                                              .25f,
                                                              Ease.Linear,
                                                              _view.CurrencyTrailStartTransform.position,
                                                              _view.CurrencyTrailTargetTransform.position)));
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
