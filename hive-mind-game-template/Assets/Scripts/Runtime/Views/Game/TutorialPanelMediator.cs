using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using HiveMindGameTemplate.Runtime.Models.Game;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.Game;
using HiveMindGameTemplate.Runtime.Utilities.Extensions;
using Lofelt.NiceVibrations;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Views.Game
{
    public class TutorialPanelMediator : Mediator<TutorialPanelView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly TutorialModel _tutorialModel;
        #endregion

        #region Constructor
        public TutorialPanelMediator(TutorialPanelView view, SignalBus signalBus, TutorialModel tutorialModel) : base(view)
        {
            _signalBus = signalBus;
            _tutorialModel = tutorialModel;
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

                _view.CloseButton.onClick.AddListener(OnCloseButtonClicked);
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                _view.CloseButton.onClick.RemoveListener(OnCloseButtonClicked);
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
        #endregion

        #region ButtonReceivers
        private void OnCloseButtonClicked()
        {
            _tutorialModel.SetTutorial(true);

            _signalBus.Fire<PlayGameSignal>(new());
            _signalBus.Fire<PlayAudioSignal>(new(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
            _signalBus.Fire<PlayHapticSignal>(new(HapticPatterns.PresetType.LightImpact));
        }
        #endregion
    }
}
