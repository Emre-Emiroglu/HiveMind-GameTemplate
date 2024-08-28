using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HiveMindGameTemplate.Runtime.Views.CrossScene
{
    public class SettingsButtonView: View
    {
        #region Fields
        [SerializeField] private bool _inGameElement;
        [SerializeField] private GameObject _verticalGroup;
        [SerializeField] private Button _button;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Dictionary<SettingsTypes, Button> _settingsButtons;
        [SerializeField] private Dictionary<SettingsTypes, GameObject> _settingsOnImages;
        [SerializeField] private Dictionary<SettingsTypes, GameObject> _settingsOffImages;
        #endregion

        #region Getters
        public bool InGameElement => _inGameElement;
        public GameObject VerticalGroup => _verticalGroup;
        public Button Button => _button;
        public Button ExitButton => _exitButton;
        public Dictionary<SettingsTypes, Button> SettingsButtons => _settingsButtons;
        public Dictionary<SettingsTypes, GameObject> SettingsOnImages => _settingsOnImages;
        public Dictionary<SettingsTypes, GameObject> SettingsOffImages => _settingsOffImages;
        #endregion
    }
}
