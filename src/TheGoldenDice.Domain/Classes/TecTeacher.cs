using TheGoldenDice.Domain.Stats;

namespace TheGoldenDice.Domain.Classes;

public sealed class TecTeacher : IClass
{
    private static readonly IStats _baseStats = new Stats.Stats
    {
        HPModifier = 10,
        AttackPower = 3,
        DefensePower = 2,
        Speed = 5
    };

    public string Name { get; set; } = "Tec Teacher";
    public string Description { get; set; } = "A teacher who would rather be outside having a smoke than teaching this class.";

    public bool Equals(IClass? other)
        => other is not null && Name == other.Name;

    public override bool Equals(object? obj)
        => Equals(obj as IClass);

    public override int GetHashCode()
        => Name.GetHashCode();

    public IStats GetStatsForLevel(int level)
    {
        return new Stats.Stats
        {
            HPModifier = _baseStats.HPModifier * level,
            AttackPower = _baseStats.AttackPower * level,
            DefensePower = _baseStats.DefensePower * level,
            Speed = _baseStats.Speed * level
        };
    }
}
