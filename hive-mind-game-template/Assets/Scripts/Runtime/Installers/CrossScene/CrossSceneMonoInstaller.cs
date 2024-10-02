using HiveMindGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using HiveMindGameTemplate.Runtime.Factories;
using HiveMindGameTemplate.Runtime.Handler.CrossScene;
using HiveMindGameTemplate.Runtime.Views.CrossScene;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.CrossScene
{
    public class CrossSceneMonoInstaller : MonoInstaller
    {
        #region Fields
        [Header("Factories Fields")]
        [SerializeField] private Transform currencyTrailParent;
        [SerializeField] private GameObject currencyTrailPrefab;
        #endregion

        #region Bindings
        public override void InstallBindings()
        {
            Container.Install<CrossSceneModelInstaller>();
            Container.Install<CrossScenePanelInstaller>();
            Container.Install<CrossSceneSignalInstaller>();

            Container.BindInterfacesAndSelfTo<CurrencyTrailSpawnHandler>().AsSingle().NonLazy();

            Container.BindFactory<CurrencyTrailData, CurrencyTrailMediator, CurrencyTrailFactory>()
              .FromPoolableMemoryPool<CurrencyTrailData, CurrencyTrailMediator, CurrencyTrailPool>
              (poolBinder => poolBinder
                  .WithInitialSize(5)
                  .FromSubContainerResolve()
                  .ByNewPrefabInstaller<CurrencyTrailInstaller>(currencyTrailPrefab)
                  .UnderTransform(currencyTrailParent)
              );
        }
        #endregion
    }
}
