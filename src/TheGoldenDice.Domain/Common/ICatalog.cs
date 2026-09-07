namespace TheGoldenDice.Domain.Common;

public interface ICatalog<T> where T : ICatalogItem
{
    IReadOnlyList<ICatalogItem> All { get; }
}
