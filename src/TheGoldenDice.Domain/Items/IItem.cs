using TheGoldenDice.Domain.Common;

namespace TheGoldenDice.Domain.Items;

public interface IItem : ICatalogItem
{
    string Name { get; set;  }
    string Description { get; set; }
}