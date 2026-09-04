using TheGoldenDice.Domain.Stats;

namespace TheGoldenDice.Domain.Items;

public interface IWearableItem : IItem
{
    IStats Stats { get; set; }
}