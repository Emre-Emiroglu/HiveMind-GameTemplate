using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap
{
    [CreateAssetMenu(fileName = "BootstrapSettings", menuName = " HiveMindGameTemplate/Runtime/Data/ScriptableObjects/Bootstrap/BootstrapSettings")]
    public class BootstrapSettings : ScriptableObject
    {
        #region Fields
        [Header("Bootstrap Settings Fields")]
        [SerializeField] private Sprite logoSprite;
        [SerializeField] private float sceneActivationDuration;
        #endregion

        #region Getters
        public Sprite LogoSprite => logoSprite;
        public float SceneActivationDuration => sceneActivationDuration;
        #endregion
    }
}
