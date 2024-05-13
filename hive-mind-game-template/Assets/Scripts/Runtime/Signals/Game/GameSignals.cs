using HiveMindGameTemplate.Runtime.Enums.Game.Enemy;
using HiveMindGameTemplate.Runtime.Enums.Game.Projectile;
using HiveMindGameTemplate.Runtime.Enums.UI;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Signals.Game
{
    #region GameCycle
    public readonly struct InitializeGameSignal { } // Has Command
    public readonly struct StartGameSignal { } // Has Command
    public readonly struct WaveWinSignal { } // Has Command
    public readonly struct NextWaveSignal { } // Has Command
    public readonly struct GameOverSignal { } // Has Command
    public readonly struct GameExitSignal { } // Has Command
    #endregion

    #region UI
    public readonly struct ChangeUIPanelSignal
    {
        #region ReadonlyFields
        private readonly UIPanelTypes uiPanelType;
        #endregion

        #region Getters
        public readonly UIPanelTypes UIPanelType => uiPanelType;
        #endregion

        #region Constructor
        public ChangeUIPanelSignal(UIPanelTypes uiPanelType)
        {
            this.uiPanelType = uiPanelType;
        }
        #endregion
    }
    #endregion

    #region Projectile
    public readonly struct SpawnProjectileSignal
    {
        #region ReadonlyFields
        private readonly ProjectileTypes projectileType;
        private readonly Vector2 spawnPosition;
        private readonly Quaternion spawnRotation;
        private readonly int value;
        #endregion

        #region Getters
        public readonly ProjectileTypes ProjectileType => projectileType;
        public readonly Vector2 SpawnPosition => spawnPosition;
        public readonly Quaternion SpawnRotation => spawnRotation;
        public readonly int Value => value;
        #endregion

        #region Constructor
        public SpawnProjectileSignal(ProjectileTypes projectileType, Vector2 spawnPosition, Quaternion spawnRotation, int value)
        {
            this.projectileType = projectileType;
            this.spawnPosition = spawnPosition;
            this.spawnRotation = spawnRotation;
            this.value = value;
        }
        #endregion
    }
    public readonly struct ProjectileHitSignal
    {
        #region ReadonlyFields
        private readonly GameObject hittedObject;
        private readonly ProjectileOwnerTypes ownerType;
        private readonly int value;
        #endregion

        #region Getters
        public readonly GameObject HittedObject => hittedObject;
        public readonly ProjectileOwnerTypes OwnerType => ownerType;
        public readonly int Value => value;
        #endregion

        #region Constructor
        public ProjectileHitSignal(GameObject hittedObject, ProjectileOwnerTypes ownerType, int value)
        {
            this.hittedObject = hittedObject;
            this.ownerType = ownerType;
            this.value = value;
        }
        #endregion
    }
    #endregion

    #region Player
    public readonly struct PlayerHealthChangedSignal
    {
        #region ReadonlyFields
        private readonly int currentHealth;
        private readonly int maxHealth;
        #endregion

        #region Getters
        public readonly int CurrentHealth => currentHealth;
        public readonly int MaxHealth => maxHealth;
        #endregion

        #region Contructor
        public PlayerHealthChangedSignal(int currentHealth, int maxHealth)
        {
            this.currentHealth = currentHealth;
            this.maxHealth = maxHealth;
        }
        #endregion
    }
    #endregion

    #region Enemy
    public readonly struct SpawnEnemySignal
    {
        #region ReadonlyFields
        private readonly EnemyTypes enemyType;
        private readonly Vector2 spawnPosition;
        #endregion

        #region Getters
        public readonly EnemyTypes EnemyType => enemyType;
        public readonly Vector2 SpawnPosition => spawnPosition;
        #endregion

        #region Constructor
        public SpawnEnemySignal(EnemyTypes enemyType, Vector2 spawnPosition)
        {
            this.enemyType = enemyType;
            this.spawnPosition = spawnPosition;
        }
        #endregion
    }
    public readonly struct EnemyDeadSignal { }
    public readonly struct EnemyMeleAttackSignal
    {
        #region ReadonlyFields
        private readonly int attackValue;
        #endregion

        #region Getters
        public readonly int AttackValue => attackValue;
        #endregion

        #region Constructor
        public EnemyMeleAttackSignal(int attackValue)
        {
            this.attackValue = attackValue;
        }
        #endregion
    }
    #endregion

    #region Audio
    public readonly struct PlayAudioSignal
    {
        #region ReadonlyFields
        private readonly AudioClip audioClip;
        #endregion

        #region Getters
        public readonly AudioClip AudioClip => audioClip;
        #endregion

        #region Constructor
        public PlayAudioSignal(AudioClip audioClip) => this.audioClip = audioClip;
        #endregion
    } // Has Command
    #endregion
}
