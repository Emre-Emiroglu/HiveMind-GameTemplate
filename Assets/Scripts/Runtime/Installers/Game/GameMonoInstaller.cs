using HiveMindGameTemplate.Runtime.Factories.Game.Enemy;
using HiveMindGameTemplate.Runtime.Factories.Game.Projectile;
using HiveMindGameTemplate.Runtime.Installers.Game.Enemy;
using HiveMindGameTemplate.Runtime.Installers.Game.Projectile;
using HiveMindGameTemplate.Runtime.Signals.Game;
using HiveMindGameTemplate.Runtime.Views.Game.Enemy;
using HiveMindGameTemplate.Runtime.Views.Game.Projectile;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.Game
{
    public sealed class GameMonoInstaller : MonoInstaller<GameMonoInstaller>
    {
        #region Constants
        private const string projectilesGroupName = "---World---/Projectiles";
        private const string enemiesGroupName = "---World---/Enemies";
        #endregion

        #region Fields
        [Header("Factories Prefabs")]
        [SerializeField] private GameObject projectileEntityPrefab;
        [SerializeField] private GameObject enemyEntityPrefab;
        #endregion

        #region Bindings
        public override void InstallBindings()
        {
            SignalBindings();
            MVCInstallerBindings();
            FactoryBindings();
        }
        private void SignalBindings()
        {
            SignalBusInstaller.Install(Container);
        }
        private void MVCInstallerBindings()
        {
            GameInstaller.Install(Container, new(Container, "Game", "HiveMindGameTemplate.Runtime"));
        }
        private void FactoryBindings()
        {
            Container.BindFactory<Datas.ScriptableObjects.Game.Projectile.Projectile, Vector2, Quaternion, ProjectileEntityMediator, ProjectileEntityFactory>()
               .FromPoolableMemoryPool<Datas.ScriptableObjects.Game.Projectile.Projectile, Vector2, Quaternion, ProjectileEntityMediator, ProjectileEntityPool>
               (poolBinder => poolBinder
               .WithInitialSize(5)
               .FromSubContainerResolve()
               .ByNewPrefabInstaller<ProjectileInstaller>(projectileEntityPrefab)
               .UnderTransformGroup(projectilesGroupName)
               );

            Container.BindFactory<Datas.ScriptableObjects.Game.Enemy.Enemy, Vector2, Quaternion, EnemyEntityMediator, EnemyEntityFactory>()
             .FromPoolableMemoryPool<Datas.ScriptableObjects.Game.Enemy.Enemy, Vector2, Quaternion, EnemyEntityMediator, EnemyEntityPool>
             (poolBinder => poolBinder
             .WithInitialSize(5)
             .FromSubContainerResolve()
             .ByNewPrefabInstaller<EnemyInstaller>(enemyEntityPrefab)
             .UnderTransformGroup(enemiesGroupName)
             );
        }
        #endregion

        #region Cycle
        public override void Start()
        {
            Container.Resolve<SignalBus>().Fire<InitializeGameSignal>(new());
        }
        #endregion
    }
}
