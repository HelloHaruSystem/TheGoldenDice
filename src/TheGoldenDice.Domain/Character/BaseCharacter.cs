using TheGoldenDice.Domain.Action;
using TheGoldenDice.Domain.Characters;
using TheGoldenDice.Domain.Gear;
using TheGoldenDice.Domain.Items;
using TheGoldenDice.Domain.Stats;

namespace TheGoldenDice.Domain.Character;

public abstract class BaseCharacter(
    string name,
    int level,
    int maxHp,
    List<IAction> actions,
    IGear gear,
    IClass @class,
    IStats stats
    )
{
    public string Name { get; set; } = name;
    public int Level { get; set; } = level;
    public int MaxHp { get; set; } = maxHp;
    public int CurrentHp { get; set; } = maxHp;
    public List<IAction> Actions { get; set; } = actions;
    public IGear Gear { get; set; } = gear;

    private IClass _class = @class;
    private IStats _stats = stats;

    public virtual List<IItem> Loot()
        => throw new NotImplementedException();

    public virtual void TakeDamage(int damage)
        => throw new NotImplementedException();

    public virtual void Heal(int amount)
       => throw new NotImplementedException();

    public IStats GetAccumulatedStats()
      => throw new NotImplementedException();
}
