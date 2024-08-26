using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Data.ScriptableObjects.Application
{
    [CreateAssetMenu(fileName = "ApplicationSettings", menuName = " HiveMindGameTemplate/Runtime/Data/ScriptableObjects/Application/ApplicationSettings")]
    public class ApplicationSettings : ScriptableObject
    {
        #region Fields
        [Header("Application Settings Fields")]
        [Range(30, 240)][SerializeField] private int _targetFrameRate;
        [SerializeField] private bool _runInBackground;
        #endregion

        #region Getters
        public int TargetFrameRate => _targetFrameRate;
        public bool RunInBackground => _runInBackground;
        #endregion
    }
}
