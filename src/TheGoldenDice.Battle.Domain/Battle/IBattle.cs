using TheGoldenDice.Battle.Domain.Turn;
using TheGoldenDice.Domain.Action;
using TheGoldenDice.Domain.Character;
using TheGoldenDice.Domain.Party;

namespace TheGoldenDice.Battle.Domain.Battle;

public interface IBattle
{
    IReadOnlyList<IParty> Parties { get; }
    IReadOnlyList<ITurn> Turns { get; }
    BattleState State { get; }
    BaseCharacter CurrentActor { get; }

    Task StartAsync();
    Task SubmitActionAsync(BaseCharacter actor, IAction action, BaseCharacter? target);
    Task AdvanceTurnAsync();
}
