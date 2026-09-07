using TheGoldenDice.Domain.Items;
using TheGoldenDice.Domain.Stats;

namespace TheGoldenDice.Domain.Gear;

internal sealed class Gear : IGear
{
    public IHeadGear? HeadSlot { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IWeapon? WeaponSlot { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public IStats GetAccumulatedStats()
    {
        IStats total = Stats.Stats.None;                                   // 0 i alle felter

        if (HeadSlot is not null) total = total.Plus(HeadSlot.Stats);
        if (WeaponSlot is not null) total = total.Plus(WeaponSlot.Stats);

        return total;
    }
}