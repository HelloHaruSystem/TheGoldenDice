using System.Net.Security;
using TheGoldenDice.Domain.Stats;

namespace TheGoldenDice.Domain.Classes;

public interface IClass : IEquatable<IClass>
{
    string Name { get; set; }
    string Description { get; set; }

    IStats GetStatsForLevel(int level);

}