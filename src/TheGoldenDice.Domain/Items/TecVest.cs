using TheGoldenDice.Domain.Stats;

namespace TheGoldenDice.Domain.Items;

public sealed class TecVest : IHeadGear
{
    public IStats Stats { get; set; } = new Stats.Stats { HPModifier = 1, DefensePower = 2 };
    public string Name { get; set; } = "Tec Vest";
    public string Description { get; set; } = "A hi-vis vest. Offers a small sense of authority, and a little bit of protection.";
}