using TheGoldenDice.Domain.Common;

namespace TheGoldenDice.Domain.Items;

public sealed class WeaponCatalog : ICatalog<IWeapon>
{
    // TODO: discover weapons via reflection instead of hardcoding them here.
    public IReadOnlyList<ICatalogItem> All { get; } = [new Cigarette()];
}
