namespace TheGoldenDice.Domain.Stats;

internal sealed class Stats : IStats
{
    public int HPModifier { get; set; } = 0;
    public int AttackPower { get; set; } = 0;
    public int DefensePower { get; set; } = 0;
    public int Speed { get; set; } = 0;

    public static readonly Stats None = new();
}