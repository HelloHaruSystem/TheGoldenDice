using TheGoldenDice.Battle.Domain.Turn;
using TheGoldenDice.Domain.Action;
using TheGoldenDice.Domain.Character;
using TheGoldenDice.Domain.Party;
using TurnRecord = TheGoldenDice.Battle.Domain.Turn.Turn;

namespace TheGoldenDice.Battle.Domain.Battle;

internal sealed class Battle : IBattle
{
    private readonly IParty _partyA;
    private readonly IParty _partyB;
    private readonly List<ITurn> _turns = [];
    private int _actingIndex = -1;
    private ActionSubmission? _pendingAction;

    public Battle(IReadOnlyList<IParty> parties)
    {
        if (parties.Count != 2)
            throw new ArgumentException("A battle requires exactly two parties.", nameof(parties));

        foreach (IParty party in parties)
        {
            if (party.Characters.Count == 0)
                throw new ArgumentException("A party must have at least one character.", nameof(parties));

            foreach (BaseCharacter character in party.Characters)
            {
                if (character is not IDamageable)
                    throw new ArgumentException(
                        $"{character.Name} does not implement {nameof(IDamageable)} and cannot take part in a battle.",
                        nameof(parties));
            }
        }

        Parties = parties;
        _partyA = parties[0];
        _partyB = parties[1];
    }

    public IReadOnlyList<IParty> Parties { get; }
    public IReadOnlyList<ITurn> Turns => _turns;
    public BattleState State { get; private set; } = BattleState.NotStarted;
    public BaseCharacter CurrentActor => ActingParty.Characters[_actingIndex];

    private IParty ActingParty => State == BattleState.PartyTurn ? _partyA : _partyB;

    public Task StartAsync()
    {
        if (State != BattleState.NotStarted)
            throw new InvalidOperationException("Battle has already started.");

        State = BattleState.PartyTurn;
        AdvanceToNextActor();
        return Task.CompletedTask;
    }

    public Task SubmitActionAsync(BaseCharacter actor, IAction action, BaseCharacter? target)
    {
        if (State != BattleState.PartyTurn && State != BattleState.OppositePartyTurn)
            throw new InvalidOperationException("Battle is not waiting on an action right now.");

        if (!ReferenceEquals(actor, CurrentActor))
            throw new InvalidOperationException("It is not this character's turn.");

        _pendingAction = new ActionSubmission(action, target);
        return Task.CompletedTask;
    }

    public Task AdvanceTurnAsync()
    {
        if (State != BattleState.PartyTurn && State != BattleState.OppositePartyTurn)
            throw new InvalidOperationException("Battle is not waiting on an action right now.");

        if (_pendingAction is null)
            return Task.CompletedTask;

        BaseCharacter actor = CurrentActor;
        ActionSubmission submission = _pendingAction.Value;
        _pendingAction = null;

        ResolveAction(actor, submission);

        if (IsPartyDefeated(_partyB))
        {
            State = BattleState.Victory;
            return Task.CompletedTask;
        }

        if (IsPartyDefeated(_partyA))
        {
            State = BattleState.Defeat;
            return Task.CompletedTask;
        }

        AdvanceToNextActor();
        return Task.CompletedTask;
    }

    private void AdvanceToNextActor()
    {
        IParty party = ActingParty;

        do
        {
            _actingIndex++;
        } while (_actingIndex < party.Characters.Count && !IsAlive(party.Characters[_actingIndex]));

        if (_actingIndex < party.Characters.Count)
            return;

        if (State == BattleState.PartyTurn)
        {
            State = BattleState.OppositePartyTurn;
        }
        else
        {
            _turns.Add(new TurnRecord(_turns.Count + 1, _partyA, _partyB));
            State = BattleState.PartyTurn;
        }

        _actingIndex = -1;
        AdvanceToNextActor();
    }

    private static void ResolveAction(BaseCharacter actor, ActionSubmission submission)
        => throw new NotImplementedException();

    private static bool IsPartyDefeated(IParty party)
        => party.Characters.All(c => !IsAlive(c));

    private static bool IsAlive(BaseCharacter character)
        => AsDamageable(character).CurrentHp > 0;

    private static IDamageable AsDamageable(BaseCharacter character)
        => (IDamageable)character;

    private readonly record struct ActionSubmission(IAction Action, BaseCharacter? Target);
}
