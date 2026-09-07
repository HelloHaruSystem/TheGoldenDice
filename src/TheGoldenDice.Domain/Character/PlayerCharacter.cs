using TheGoldenDice.Domain.Action;
using TheGoldenDice.Domain.Classes;
using TheGoldenDice.Domain.Gear;
using TheGoldenDice.Domain.Stats;

namespace TheGoldenDice.Domain.Character;

public sealed class PlayerCharacter(
        string name,
        int level,
        int baseHp,
        List<IAction> actions,
        IGear gear,
        IClass @class,
        IStats stats)
        : BaseCharacter(name, level, actions, gear, @class, stats), IDamageable
{

    private int _baseHp = baseHp;
    public int MaxHp 
    { 
        get 
        {
            return _baseHp + base.GetAccumulatedStats().HPModifier;
        }
    } 

    public int CurrentHp { get; set; } = baseHp;

    public void Heal(int healPoints)
    {
        int newHp = CurrentHp + healPoints;

        if (newHp >= MaxHp)
        {
            CurrentHp = MaxHp;
            return;
        }

        CurrentHp = newHp;

    }

    public void TakeDamage(int damagePoints)
    {
        int newHp = CurrentHp - damagePoints;

        if (newHp < 0)
        {
            CurrentHp = 0;
            return;
        }

        CurrentHp = newHp;

    }
}
