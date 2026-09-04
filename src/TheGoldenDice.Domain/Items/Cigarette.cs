using TheGoldenDice.Domain.Stats;

namespace TheGoldenDice.Domain.Items;

internal sealed class Cigarette : IWeapon
{
    public IStats Stats { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}