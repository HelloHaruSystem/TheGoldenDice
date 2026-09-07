using System.Net.Security;
using TheGoldenDice.Domain.Common;
using TheGoldenDice.Domain.Stats;

namespace TheGoldenDice.Domain.Classes;

public interface IClass : IEquatable<IClass>, ICatalogItem
{
    string Name { get; set; }
    string Description { get; set; }

    IStats GetStatsForLevel(int level);

}