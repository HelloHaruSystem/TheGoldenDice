using TheGoldenDice.Domain.Stats;

namespace TheGoldenDice.Domain.Classes;

public sealed class TecTeacher : IClass
{
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
        throw new NotImplementedException();
    }
}