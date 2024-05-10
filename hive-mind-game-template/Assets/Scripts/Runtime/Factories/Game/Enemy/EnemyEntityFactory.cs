using HiveMindGameTemplate.Runtime.Views.Game.Enemy;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Factories.Game.Enemy
{
    public sealed class EnemyEntityFactory : PlaceholderFactory<Datas.ScriptableObjects.Game.Enemy.Enemy, Vector2, Quaternion, EnemyEntityMediator> { }
    public sealed class EnemyEntityPool : MonoPoolableMemoryPool<Datas.ScriptableObjects.Game.Enemy.Enemy, Vector2, Quaternion, IMemoryPool, EnemyEntityMediator> { }
}
