using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using HiveMindGameTemplate.Runtime.Models.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using Lofelt.NiceVibrations;
using System.Collections.Generic;
using UnityEngine.UI;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Views.CrossScene
{
    public class SettingsButtonMediator : Mediator<SettingsButtonView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly AudioModel _audioModel;
        private readonly HapticModel _hapticModel;
        #endregion

        #region Fields
        private bool _isVerticalGroupActive;
        #endregion

        #region Constructor
        public SettingsButtonMediator(SettingsButtonView view, SignalBus signalBus, AudioModel audioModel, HapticModel hapticModel) : base(view)
        {
            _signalBus = signalBus;
            _audioModel = audioModel;
            _hapticModel = hapticModel;
        }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion

        #region Core
        public override void Initialize()
        {
            _signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);
            _signalBus.Subscribe<SettingsButtonRefreshSignal>(OnSettingsButtonRefreshSignal);

            _view.Button.onClick.AddListener(ButtonClicked);
            _view.ExitButton.onClick.AddListener(ExitButtonClicked);

            foreach (KeyValuePair<SettingsTypes, Button> item in _view.SettingsButtons)
            {
                SetupVisual(item.Key);

                item.Value.onClick.AddListener(() => SettingsButtonClicked(item.Key));
            }
        }
        public override void Dispose()
        {
            _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);
            _signalBus.Unsubscribe<SettingsButtonRefreshSignal>(OnSettingsButtonRefreshSignal);

            _view.Button.onClick.RemoveListener(ButtonClicked);
            _view.ExitButton.onClick.RemoveListener(ExitButtonClicked);

            foreach (KeyValuePair<SettingsTypes, Button> item in _view.SettingsButtons)
                item.Value.onClick.RemoveListener(() => SettingsButtonClicked(item.Key));
        }
        #endregion

        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal)
        {
            SetVericalGroupActivation(false);
        }
        private void OnSettingsButtonRefreshSignal(SettingsButtonRefreshSignal signal)
        {
            SetupVisual(signal.SettingsType);
        }
        #endregion

        #region ButtonReceivers
        private void ButtonClicked()
        {
            SetVericalGroupActivation(!_isVerticalGroupActive);

            _signalBus.Fire<PlayAudioSignal>(new(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
            _signalBus.Fire<PlayHapticSignal>(new(HapticPatterns.PresetType.LightImpact));
        }
        private void ExitButtonClicked()
        {
            if (_view.InGameElement)
                _signalBus.Fire<GameOverSignal>(new(false, true));
            else
                _signalBus.Fire<GameExitSignal>(new());
        }
        private void SettingsButtonClicked(SettingsTypes settingsType)
        {
            _signalBus.Fire<SettingsButtonPressedSignal>(new(settingsType));

            _signalBus.Fire<PlayAudioSignal>(new(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
            _signalBus.Fire<PlayHapticSignal>(new(HapticPatterns.PresetType.LightImpact));
        }
        #endregion

        #region Executes
        private void SetupVisual(SettingsTypes settingsType)
        {
            bool isActive = false;

            switch (settingsType)
            {
                case SettingsTypes.Music:
                    isActive = !_audioModel.IsMusicMuted;
                    break;
                case SettingsTypes.Sound:
                    isActive = !_audioModel.IsSoundMuted;
                    break;
                case SettingsTypes.Haptic:
                    isActive = !_hapticModel.IsHapticMuted;
                    break;
            }

            _view.SettingsOnImages[settingsType].SetActive(isActive);
            _view.SettingsOffImages[settingsType].SetActive(!isActive);
        }
        private void SetVericalGroupActivation(bool isActive)
        {
            _isVerticalGroupActive = isActive;
            _view.VerticalGroup.SetActive(_isVerticalGroupActive);
        }
        #endregion
    }
}
