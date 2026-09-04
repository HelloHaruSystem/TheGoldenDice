using TheGoldenDice.Domain.Action;
using TheGoldenDice.Domain.Characters;
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
        : BaseCharacter(name, level, maxHp, actions, gear, @class, stats)
{
}
