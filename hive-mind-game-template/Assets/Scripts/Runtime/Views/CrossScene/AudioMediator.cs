using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using HiveMindGameTemplate.Runtime.Models.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Views.CrossScene
{
    public class AudioMediator : Mediator<AudioView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly AudioModel _audioModel;
        #endregion

        #region Constructor
        public AudioMediator(AudioView view, SignalBus signalBus, AudioModel audioModel) : base(view)
        {
            _signalBus = signalBus;
            _audioModel = audioModel;
        }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion

        #region Core
        public override void Initialize()
        {
            _signalBus.Subscribe<PlayAudioSignal>(OnPlayAudio);
        }
        public override void Dispose()
        {
            _signalBus.Unsubscribe<PlayAudioSignal>(OnPlayAudio);
        }
        #endregion

        #region SignalReceivers
        private void OnPlayAudio(PlayAudioSignal signal) => PlayAudioProcess(signal.AudioType, signal.MusicType, signal.SoundType);
        #endregion

        #region Executes
        private void PlayAudioProcess(AudioTypes audioType, MusicTypes musicType, SoundTypes soundType)
        {
            switch (audioType)
            {
                case AudioTypes.Music:
                    _view.AudioSources[audioType].clip = _audioModel.Settings.Musics[musicType];
                    _view.AudioSources[audioType].loop = true;
                    _view.AudioSources[audioType].Play();
                    break;
                case AudioTypes.Sound:
                    _view.AudioSources[audioType].PlayOneShot(_audioModel.Settings.Sounds[soundType]);
                    break;
            }
        }
        #endregion
    }
}