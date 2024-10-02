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
        [SerializeField] private GameObject verticalGroup;
        [SerializeField] private Button button;
        [SerializeField] private Button exitButton;
        [SerializeField] private Dictionary<SettingsTypes, Button> _settingsButtons;
        [SerializeField] private Dictionary<SettingsTypes, GameObject> _settingsOnImages;
        [SerializeField] private Dictionary<SettingsTypes, GameObject> _settingsOffImages;
        #endregion

        #region Getters
        public GameObject VerticalGroup => verticalGroup;
        public Button Button => button;
        public Button ExitButton => exitButton;
        public Dictionary<SettingsTypes, Button> SettingsButtons => _settingsButtons;
        public Dictionary<SettingsTypes, GameObject> SettingsOnImages => _settingsOnImages;
        public Dictionary<SettingsTypes, GameObject> SettingsOffImages => _settingsOffImages;
        #endregion
    }
}
