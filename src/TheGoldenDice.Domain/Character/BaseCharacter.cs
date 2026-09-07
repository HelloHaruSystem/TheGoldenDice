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
    public string Name { get; set; } = name;
    public int Level { get; set; } = level;
    public List<IAction> Actions { get; set; } = actions;
    public IGear Gear { get; set; } = gear;

    private IClass _class = @class;
    private IStats _stats = stats;

    public virtual List<IItem> Loot()
        => throw new NotImplementedException();

    public IStats GetAccumulatedStats()
    {
        return _stats
            .Plus(_class.GetStatsForLevel(level))
            .Plus(Gear.GetAccumulatedStats());
    }
}
