using HiveMindGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using HiveMindGameTemplate.Runtime.Views.CrossScene;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Factories
{
    public sealed class CurrencyTrailFactory : PlaceholderFactory<CurrencyTrailData, CurrencyTrailMediator> { }
    public sealed class CurrencyTrailPool : MonoPoolableMemoryPool<CurrencyTrailData, IMemoryPool, CurrencyTrailMediator> { }
}
