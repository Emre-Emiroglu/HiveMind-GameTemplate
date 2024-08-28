using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace HiveMindGameTemplate.Runtime.Data.ScriptableObjects.CrossScene
{
    [CreateAssetMenu(fileName = "AudioSettings", menuName = " HiveMindGameTemplate/Runtime/Data/ScriptableObjects/CrossScene/AudioSettings")]
    public class AudioSettings : SerializedScriptableObject
    {
        #region Fields
        [Header("Audio Settings Fields")]
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private Dictionary<MusicTypes, AudioClip> _musics;
        [SerializeField] private Dictionary<SoundTypes, AudioClip> _sounds;
        #endregion

        #region Getters
        public AudioMixer AudioMixer => _audioMixer;
        public Dictionary<MusicTypes, AudioClip> Musics => _musics;
        public Dictionary<SoundTypes, AudioClip> Sounds => _sounds;
        #endregion
    }
}
