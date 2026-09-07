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
    private List<String> _tauntMessages { get; set; } = tauntMessages;

    public string GetTauntMessage()
        => throw new NotImplementedException();

    public void Heal(int healPoints)
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(int damagePoints)
    {
        throw new NotImplementedException();
    }
}
