using Zenject;
using Lofelt.NiceVibrations;
using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.MainMenu;
using HiveMindGameTemplate.Runtime.Utilities.Extensions;

namespace HiveMindGameTemplate.Runtime.Views.MainMenu
{
    public class ShopPanelMediator : Mediator<ShopPanelView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion

        #region Constructor
        public ShopPanelMediator(ShopPanelView view, SignalBus signalBus) : base(view)
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

                _view.HomeButton.onClick.AddListener(OnHomeButtonClicked);
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                _view.HomeButton.onClick.RemoveListener(OnHomeButtonClicked);
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
        private void OnHomeButtonClicked()
        {
            _signalBus.Fire<ReturnToStartPanelSignal>(new());
            _signalBus.Fire<PlayAudioSignal>(new(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
            _signalBus.Fire<PlayHapticSignal>(new(HapticPatterns.PresetType.LightImpact));
        }
        #endregion
    }
}
