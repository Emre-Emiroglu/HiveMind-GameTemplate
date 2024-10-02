using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Data.ScriptableObjects.Application
{
    [CreateAssetMenu(fileName = "ApplicationSettings", menuName = " HiveMindGameTemplate/Runtime/Data/ScriptableObjects/Application/ApplicationSettings")]
    public class ApplicationSettings : ScriptableObject
    {
        #region Fields
        [Header("Application Settings Fields")]
        [Range(30, 240)][SerializeField] private int targetFrameRate;
        [SerializeField] private bool runInBackground;
        #endregion

        #region Getters
        public int TargetFrameRate => targetFrameRate;
        public bool RunInBackground => runInBackground;
        #endregion
    }
}
