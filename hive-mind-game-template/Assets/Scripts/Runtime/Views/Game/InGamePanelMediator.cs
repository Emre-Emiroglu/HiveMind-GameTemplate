using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Models.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.Game;
using HiveMindGameTemplate.Runtime.Utilities.Extensions;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Views.Game
{
    public class InGamePanelMediator : Mediator<InGamePanelView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly LevelModel _levelModel;
        #endregion

        #region Fields
        private bool _inGame;
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

                _signalBus.Subscribe<PlayGameSignal>(OnPlayGameSignal);
                _signalBus.Subscribe<GameOverSignal>(OnGameOverSignal);
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                _signalBus.Unsubscribe<PlayGameSignal>(OnPlayGameSignal);
                _signalBus.Unsubscribe<GameOverSignal>(OnGameOverSignal);
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
        private void OnPlayGameSignal(PlayGameSignal playGameSignal)
        {
            SetPanel(true);
        }
        private void OnGameOverSignal(GameOverSignal gameOverSignal)
        {
            SetPanel(false);
        }
        #endregion

        #region Executes
        private void SetPanel(bool inGame)
        {
            _inGame = inGame;

            SetLevelText();
        }
        private void SetLevelText()
        {
            int levelNumber = _levelModel.LevelPersistentData.CurrentLevelIndex + 1;
            _view.LevelText.SetText($"Level {levelNumber}");
        }
        #endregion
    }
}
