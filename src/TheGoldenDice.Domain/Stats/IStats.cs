namespace TheGoldenDice.Domain.Stats;

public interface IStats 
{
    int HPModifier { get; set; }
    int AttackPower { get; set; }
    int DefensePower { get; set; }
    int Speed { get; set; }
}