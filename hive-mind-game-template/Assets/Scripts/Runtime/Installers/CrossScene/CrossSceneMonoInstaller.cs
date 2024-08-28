using HiveMindGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using HiveMindGameTemplate.Runtime.Factories;
using HiveMindGameTemplate.Runtime.Views.CrossScene;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.CrossScene
{
    public class CrossSceneMonoInstaller : MonoInstaller
    {
        #region Fields
        [Header("Factories Fields")]
        [SerializeField] private Transform _currencyTrailParent;
        [SerializeField] private GameObject _currencyTrailPrefab;
        #endregion

        #region Bindings
        public override void InstallBindings()
        {
            Container.Install<CrossSceneModelInstaller>();
            Container.Install<CrossScenePanelInstaller>();
            Container.Install<CrossSceneSignalInstaller>();

            Container.BindFactory<CurrencyTrailData, CurrencyTrailMediator, CurrencyTrailFactory>()
              .FromPoolableMemoryPool<CurrencyTrailData, CurrencyTrailMediator, CurrencyTrailPool>
              (poolBinder => poolBinder
                  .WithInitialSize(5)
                  .FromSubContainerResolve()
                  .ByNewPrefabInstaller<CurrencyTrailInstaller>(_currencyTrailPrefab)
                  .UnderTransform(_currencyTrailParent)
              );
        }
        #endregion
    }
}
