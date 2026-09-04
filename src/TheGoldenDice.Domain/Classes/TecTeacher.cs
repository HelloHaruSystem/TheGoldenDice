using TheGoldenDice.Domain.Stats;

namespace TheGoldenDice.Domain.Classes;

internal sealed class TecTeacher : IClass
{
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public bool Equals(IClass? other)
    {
        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public IStats GetStatsForLevel(int level)
    {
        throw new NotImplementedException();
    }
}