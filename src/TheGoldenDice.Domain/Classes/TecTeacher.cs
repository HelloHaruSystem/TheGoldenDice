using TheGoldenDice.Domain.Stats;

namespace TheGoldenDice.Domain.Classes;

public sealed class TecTeacher : IClass
{
    private const int _hpModifier = 5;
    private const int _attackPower = 1;
    private const int _defensePower = 2;
    private const int _speed = 1;

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
            HPModifier = _hpModifier * level,
            AttackPower = _attackPower * level,
            DefensePower = _defensePower * level,
            Speed = _speed * level
        };
    }
}
