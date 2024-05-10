using HiveMind.Core.MVC.Datas;
using HiveMind.Core.MVC.Installers;
using HiveMindGameTemplate.Runtime.Controllers.Game;
using HiveMindGameTemplate.Runtime.Controllers.Game.Audio;
using HiveMindGameTemplate.Runtime.Handlers.Game.Enemy;
using HiveMindGameTemplate.Runtime.Handlers.Game.Player;
using HiveMindGameTemplate.Runtime.Handlers.Game.Projectile;
using HiveMindGameTemplate.Runtime.Handlers.Game.Wave;
using HiveMindGameTemplate.Runtime.Signals.Game;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Installers.Game
{
    public sealed class GameInstaller : MVCInstaller<GameInstaller>
    {
        #region Constructor
        public GameInstaller(BinderData binderData) : base(binderData) { }
        #endregion

        #region Bindings
        public override void InstallBindings()
        {
            base.InstallBindings();

            SignalBindings();
            PlayerBindings();
            ProjectileBindings();
            EnemyBindings();
            WaveBindings();
        }
        private void SignalBindings()
        {
            commandBinder.BindSignal<InitializeGameSignal>().WithCommand<InitializeGameCommand>();
            commandBinder.BindSignal<StartGameSignal>().WithCommand<StartGameCommand>();
            commandBinder.BindSignal<WaveWinSignal>().WithCommand<WaveWinCommand>();
            commandBinder.BindSignal<NextWaveSignal>().WithCommand<NextWaveCommand>();
            commandBinder.BindSignal<GameOverSignal>().WithCommand<GameOverCommand>();
            commandBinder.BindSignal<GameExitSignal>().WithCommand<GameExitCommand>();

            binderData.Container.DeclareSignal<ChangeUIPanelSignal>();

            binderData.Container.DeclareSignal<SpawnProjectileSignal>();
            binderData.Container.DeclareSignal<ProjectileHitSignal>();

            binderData.Container.DeclareSignal<PlayerHealthChangedSignal>();

            binderData.Container.DeclareSignal<SpawnEnemySignal>();
            binderData.Container.DeclareSignal<EnemyDeadSignal>();

            commandBinder.BindSignal<PlayAudioSignal>().WithCommand<PlayAudioCommand>();
        }
        private void PlayerBindings()
        {
            binderData.Container.BindInterfacesAndSelfTo<PlayerInputHandler>().AsSingle().NonLazy();
            binderData.Container.BindInterfacesAndSelfTo<PlayerMovementHandler>().AsSingle().NonLazy();
            binderData.Container.BindInterfacesAndSelfTo<PlayerRotationHandler>().AsSingle().NonLazy();
            binderData.Container.BindInterfacesAndSelfTo<PlayerAttackHandler>().AsSingle().NonLazy();
            binderData.Container.BindInterfacesAndSelfTo<PlayerHealthHandler>().AsSingle().NonLazy();
            binderData.Container.BindInterfacesAndSelfTo<PlayerDashHandler>().AsSingle().NonLazy();
        }
        private void ProjectileBindings()
        {
            binderData.Container.BindInterfacesAndSelfTo<ProjectileSpawnHandler>().AsSingle().NonLazy();
        }
        private void EnemyBindings()
        {
            binderData.Container.BindInterfacesAndSelfTo<EnemySpawnHandler>().AsSingle().NonLazy();
        }
        private void WaveBindings()
        {
            binderData.Container.BindInterfacesAndSelfTo<WaveHandler>().AsSingle().NonLazy();
        }
        #endregion
    }
}
