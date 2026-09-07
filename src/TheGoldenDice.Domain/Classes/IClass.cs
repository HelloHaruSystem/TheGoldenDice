using System.Net.Security;
using TheGoldenDice.Domain.Common;
using TheGoldenDice.Domain.Stats;

namespace TheGoldenDice.Domain.Classes;

public interface IClass : IEquatable<IClass>, ICatalogItem
{
    IStats GetStatsForLevel(int level);

}