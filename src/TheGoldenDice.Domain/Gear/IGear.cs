using TheGoldenDice.Domain.Items;
using TheGoldenDice.Domain.Stats;

namespace TheGoldenDice.Domain.Gear;

public interface IGear
{
    IHeadGear HeadSlot { get; set; }
    IWeapon WeaponSlot { get; set; }

    IStats GetAccumulatedStats();
}