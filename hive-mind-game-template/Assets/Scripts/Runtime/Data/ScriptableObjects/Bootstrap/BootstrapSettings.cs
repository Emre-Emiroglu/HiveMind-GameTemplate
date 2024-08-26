using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap
{
    [CreateAssetMenu(fileName = "BootstrapSettings", menuName = " HiveMindGameTemplate/Runtime/Data/ScriptableObjects/Bootstrap/BootstrapSettings")]
    public class BootstrapSettings : ScriptableObject
    {
        #region Fields
        [Header("Bootstrap Settings Fields")]
        [SerializeField] private Sprite _logoSprite;
        [SerializeField] private float _sceneActivationDuration;
        #endregion

        #region Getters
        public Sprite LogoSprite => _logoSprite;
        public float SceneActivationDuration => _sceneActivationDuration;
        #endregion
    }
}
