using TheGoldenDice.Domain.Action;
using TheGoldenDice.Domain.Classes;
using TheGoldenDice.Domain.Gear;
using TheGoldenDice.Domain.Stats;

namespace TheGoldenDice.Domain.Character;

internal sealed class PlayerCharacter(
        string name,
        int level,
        int maxHp,
        List<IAction> actions,
        IGear gear,
        IClass @class,
        IStats stats)
        : BaseCharacter(name, level, actions, gear, @class, stats), IDamageable
{
    public int MaxHp { get; set; } = maxHp;
    public int CurrentHp { get; set; } = maxHp;

    public void Heal(int healPoints)
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(int damagePoints)
    {
        throw new NotImplementedException();
    }
}
