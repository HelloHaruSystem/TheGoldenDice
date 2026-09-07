using TheGoldenDice.Domain.Common;

namespace TheGoldenDice.Domain.Items;

public sealed class HeadGearCatalog : ICatalog<IHeadGear>
{
    // TODO: discover head gear via reflection instead of hardcoding it here.
    public IReadOnlyList<ICatalogItem> All { get; } = [new TecVest()];
}
