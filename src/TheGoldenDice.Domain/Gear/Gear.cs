using TheGoldenDice.Domain.Items;
using TheGoldenDice.Domain.Stats;

namespace TheGoldenDice.Domain.Gear;

internal sealed class Gear : IGear
{
    public IHeadGear HeadSlot { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IWeapon WeaponSlot { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public IStats GetAccumulatedStats()
    {
        return HeadSlot.Stats.Plus(WeaponSlot.Stats);
    }
}