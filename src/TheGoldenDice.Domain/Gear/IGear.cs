using TheGoldenDice.Domain.Items;

namespace TheGoldenDice.Domain.Gear;

public interface IGear
{
    IHeadGear HeadSlot { get; set; }
    IWeapon WeaponSlot { get; set; }
}