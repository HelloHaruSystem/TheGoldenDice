using TheGoldenDice.Domain.Action;
using TheGoldenDice.Domain.Classes;
using TheGoldenDice.Domain.Gear;
using TheGoldenDice.Domain.Items;
using TheGoldenDice.Domain.Stats;

namespace TheGoldenDice.Domain.Character;

public abstract class BaseCharacter(
    string name,
    int level,
    List<IAction> actions,
    IGear gear,
    IClass @class,
    IStats stats
    )
{
    private const int DropChancePercent = 10; //TODO: Flyt constant til samlet fil
    public string Name { get; set; } = name;
    public int Level { get; set; } = level;
    public List<IAction> Actions { get; set; } = actions;
    public IGear Gear { get; set; } = gear;

    private IClass _class = @class;
    private IStats _stats = stats;

    public virtual List<IItem> LootThisCharacter()
    {
        var loot = new List<IItem>();

        if (Gear.HeadSlot is { } head && Random.Shared.Next(100) < DropChancePercent)
        {
            loot.Add(head);
            Gear.HeadSlot = null;
        }

        if (Gear.WeaponSlot is { } weapon && Random.Shared.Next(100) < DropChancePercent)
        {
            loot.Add(weapon);
            Gear.WeaponSlot = null;
        }

        return loot;
    }

    public IStats GetAccumulatedStats()
    {
        return _stats
            .Plus(_class.GetStatsForLevel(level))
            .Plus(Gear.GetAccumulatedStats());
    }
}
