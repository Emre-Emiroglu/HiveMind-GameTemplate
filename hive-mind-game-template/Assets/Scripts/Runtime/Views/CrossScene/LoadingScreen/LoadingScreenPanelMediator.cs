using Cysharp.Threading.Tasks;
using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using HiveMindGameTemplate.Runtime.Utilities.Extensions;
using System;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Views.CrossScene.LoadingScreen
{
    public class LoadingScreenPanelMediator : Mediator<LoadingScreenPanelView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion

        #region Fields
        private AsyncOperation _loadOperation;
        private bool _loadingCompleted = false;
        #endregion

        #region Constructor
        public LoadingScreenPanelMediator(LoadingScreenPanelView view, SignalBus signalBus) : base(view)
        {
            _signalBus = signalBus;
        }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion

        #region Core
        public override void Initialize()
        {
            ChangePanelActivation(false);

            _signalBus.Subscribe<ChangeLoadingScreenActivationSignal>(OnChangeLoadingScreenActivationSignal);
        }
        public override void Dispose()
        {
            _signalBus.Unsubscribe<ChangeLoadingScreenActivationSignal>(OnChangeLoadingScreenActivationSignal);
        }
        #endregion

        #region SignalReceivers
        private async void OnChangeLoadingScreenActivationSignal(ChangeLoadingScreenActivationSignal signal)
        {
            bool isActive = signal.IsActive;

            if (isActive)
            {
                ResetProgressBar();
                _loadOperation = signal.AsyncOperation;
                ChangePanelActivation(true);
                WaitUntilSceneIsLoaded();
            }
            else
            {
                await UniTask.WaitUntil(() => _loadingCompleted);
                ChangePanelActivation(false);
            }
        }
        #endregion

        #region Executes
        public void ChangePanelActivation(bool isActive)
        {
            _view.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(isActive);
            _view.UIPanelVo.PlayableDirector.ChangeUIPanelTimelineActivation(isActive);
        }
        private void ResetProgressBar()
        {
            _view.FillImage.fillAmount = 0f;
            _loadOperation = null;
            _loadingCompleted = false;
        }
        private async void WaitUntilSceneIsLoaded()
        {
            try
            {
                while (!_loadOperation.isDone)
                {
                    float progress = _loadOperation.progress;
                    float targetProgress = _loadOperation.isDone ? 1f : progress;

                    // Lerp fill amount towards target progress
                    LerpProgressBar(targetProgress);

                    await UniTask.Yield();
                }

                //async operation finishes at 90%, lerp to full value for a while
                float time = 0.5f;
                while (time > 0)
                {
                    time -= Time.deltaTime;
                    // Lerp fill amount towards target progress
                    LerpProgressBar(1f);

                    await UniTask.Yield();
                }

                await UniTask.Yield();

                _loadingCompleted = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private void LerpProgressBar(float targetProgress)
        {
            _view.FillImage.fillAmount = Mathf.Lerp(_view.FillImage.fillAmount, targetProgress,
                Time.fixedDeltaTime * 10f);
        }
        #endregion
    }
}
