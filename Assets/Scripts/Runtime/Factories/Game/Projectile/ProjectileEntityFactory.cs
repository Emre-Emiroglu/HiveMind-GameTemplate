using HiveMindGameTemplate.Runtime.Views.Game.Projectile;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Factories.Game.Projectile
{
    public sealed class ProjectileEntityFactory : PlaceholderFactory<Datas.ScriptableObjects.Game.Projectile.Projectile, Vector2, Quaternion, ProjectileEntityMediator> { }
    public sealed class ProjectileEntityPool : MonoPoolableMemoryPool<Datas.ScriptableObjects.Game.Projectile.Projectile, Vector2, Quaternion, IMemoryPool, ProjectileEntityMediator> { }
}
