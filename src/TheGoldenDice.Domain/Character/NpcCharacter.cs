using TheGoldenDice.Domain.Action;
using TheGoldenDice.Domain.Classes;
using TheGoldenDice.Domain.Gear;
using TheGoldenDice.Domain.Stats;

namespace TheGoldenDice.Domain.Character;

internal sealed class NpcCharacter
    (string name,
     int level,
     int maxHp,
     List<IAction> actions,
     IGear gear,
     IClass @class,
     IStats stats,
     List<string> tauntMessages
     ) : BaseCharacter(name, level, actions, gear, @class, stats), IDamageable

{
    public int MaxHp { get; set; } = maxHp;
    public int CurrentHp { get; set; } = maxHp;
    private readonly List<string> _tauntMessages = tauntMessages;

    public string GetTauntMessage()
    {
        if (_tauntMessages.Count == 0) 
        {
            return string.Empty;
        }

        return _tauntMessages[Random.Shared.Next(_tauntMessages.Count)];
    }

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
