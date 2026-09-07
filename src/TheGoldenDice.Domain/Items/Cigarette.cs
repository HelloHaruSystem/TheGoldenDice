using TheGoldenDice.Domain.Stats;

namespace TheGoldenDice.Domain.Items;

public sealed class Cigarette : IWeapon
{
    public IStats Stats { get; set; } = new Stats.Stats { HPModifier = -1, AttackPower = 2 };
    public string Name { get; set; } = "Cigarette";
    public string Description { get; set; } = "Not really a weapon, but it works in a pinch.";
}
