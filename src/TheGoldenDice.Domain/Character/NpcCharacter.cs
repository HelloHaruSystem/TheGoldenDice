using TheGoldenDice.Domain.Action;
using TheGoldenDice.Domain.Characters;
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
     ) : BaseCharacter(name, level, maxHp, actions, gear, @class, stats)

{
    private List<String> _tauntMessages { get; set; } = tauntMessages;

    public string GetTauntMessage()
        => throw new NotImplementedException();
}
