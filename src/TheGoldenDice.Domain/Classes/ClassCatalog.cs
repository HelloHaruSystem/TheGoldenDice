using TheGoldenDice.Domain.Common;

namespace TheGoldenDice.Domain.Classes;

public sealed class ClassCatalog : ICatalog<IClass>
{
    // TODO: discover classes via reflection instead of hardcoding them here.
    public IReadOnlyList<ICatalogItem> All { get; } = [new TecTeacher()];
}
