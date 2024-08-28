using HiveMind.Core.MVC.Runtime.Model;
using HiveMindGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using UnityEngine.Audio;

namespace HiveMindGameTemplate.Runtime.Models.CrossScene
{
    public class AudioModel : Model<AudioSettings>
    {
        #region Constants
        private const string ResourcePath = "Data/CrossScene/AudioSettings";
        private const string AUDIO_PATH = "AUDIO_PATH";
        private const string MUSIC_PARAM = "MUSIC_PARAM";
        private const string SOUND_PARAM = "SOUND_PARAM";
        #endregion

        #region Fields
        private bool _isSoundMuted;
        private bool _isMusicMuted;
        #endregion

        #region Getters
        private AudioMixer _audioMixer;
        public bool IsSoundMuted => _isSoundMuted;
        public bool IsMusicMuted => _isMusicMuted;
        #endregion

        #region Constructor
        public AudioModel() : base(ResourcePath)
        {
            _audioMixer = _settings.AudioMixer;

            _isMusicMuted = ES3.Load(nameof(_isMusicMuted), AUDIO_PATH, false);
            _isSoundMuted = ES3.Load(nameof(_isSoundMuted), AUDIO_PATH, false);

            SetMusic(_isMusicMuted);
            SetSound(_isSoundMuted);
        }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion

        #region Executes
        public void SetMusic(bool isActive)
        {
            _isMusicMuted = isActive;
            _audioMixer.SetFloat(MUSIC_PARAM, _isMusicMuted ? -80 : -20);

            Save();
        }
        public void SetSound(bool isActive)
        {
            _isSoundMuted = isActive;
            _audioMixer.SetFloat(SOUND_PARAM, _isSoundMuted ? -80 : -10);

            Save();
        }
        public void Save()
        {
            ES3.Save(nameof(_isSoundMuted), _isSoundMuted, AUDIO_PATH);
        }
        #endregion
    }
}
