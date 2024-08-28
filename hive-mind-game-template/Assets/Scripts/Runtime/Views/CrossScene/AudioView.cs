using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using System.Collections.Generic;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Views.CrossScene
{
    public class AudioView : View
    {
        #region Fields
        [SerializeField] private Dictionary<AudioTypes, AudioSource> _audioSources;
        #endregion

        #region Getters
        public Dictionary<AudioTypes, AudioSource> AudioSources => _audioSources;
        #endregion
    }
}