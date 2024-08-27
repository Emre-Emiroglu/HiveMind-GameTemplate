using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Signals.CrossScene
{
    public readonly struct ChangeLoadingScreenActivationSignal
    {
        #region ReadonlyFields
        private readonly bool _isActive;
        private readonly AsyncOperation _asyncOperation;
        #endregion

        #region Getters
        public bool IsActive => _isActive;
        public AsyncOperation AsyncOperation => _asyncOperation;
        #endregion

        #region Constructor
        public ChangeLoadingScreenActivationSignal(bool isActive, AsyncOperation asyncOperation)
        {
            _isActive = isActive;
            _asyncOperation = asyncOperation;
        }
        #endregion
    }
    public readonly struct LoadSceneSignal
    {
        #region ReadonlyFields
        private readonly SceneID _sceneIDID;
        #endregion

        #region Getters
        public SceneID SceneIdid => _sceneIDID;
        #endregion

        #region Constructor
        public LoadSceneSignal(SceneID sceneIDID)
        {
            _sceneIDID = sceneIDID;
        }
        #endregion
    }
}
