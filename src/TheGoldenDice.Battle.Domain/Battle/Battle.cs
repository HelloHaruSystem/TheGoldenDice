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
    private readonly Dictionary<BaseCharacter, ActionSubmission> _actingSubmissions = [];
    private readonly Dictionary<BaseCharacter, ActionSubmission> _opposingSubmissions = [];

    public Battle(IReadOnlyList<IParty> parties)
    {
        if (parties.Count != 2)
            throw new ArgumentException("A battle requires exactly two parties.", nameof(parties));

        foreach (IParty party in parties)
        {
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

    public Task StartAsync()
    {
        if (State != BattleState.NotStarted)
            throw new InvalidOperationException("Battle has already started.");

        State = BattleState.PartyTurn;
        return Task.CompletedTask;
    }

    public Task SubmitActionAsync(BaseCharacter actor, IAction action, BaseCharacter? target)
    {
        if (State != BattleState.PartyTurn && State != BattleState.OppositePartyTurn)
            throw new InvalidOperationException("Battle is not waiting on party actions right now.");

        (IParty party, Dictionary<BaseCharacter, ActionSubmission> submissions) = State == BattleState.PartyTurn
            ? (_partyA, _actingSubmissions)
            : (_partyB, _opposingSubmissions);

        if (!party.Characters.Contains(actor))
            throw new InvalidOperationException("Actor is not a member of the party whose turn it is.");

        if (AsDamageable(actor).CurrentHp <= 0)
            throw new InvalidOperationException("Actor is downed and cannot act.");

        submissions[actor] = new ActionSubmission(action, target);
        return Task.CompletedTask;
    }

    public Task AdvanceTurnAsync()
    {
        if (State == BattleState.PartyTurn)
        {
            if (!AllLivingMembersSubmitted(_partyA, _actingSubmissions))
                return Task.CompletedTask;

            State = BattleState.OppositePartyTurn;
        }

        if (State == BattleState.OppositePartyTurn)
        {
            if (!AllLivingMembersSubmitted(_partyB, _opposingSubmissions))
                return Task.CompletedTask;

            State = BattleState.ResolveTurn;
        }

        if (State == BattleState.ResolveTurn)
        {
            throw new NotImplementedException();
        }

        if (State == BattleState.CheckStatus)
        {
            bool partyADefeated = _partyA.Characters.All(c => AsDamageable(c).CurrentHp <= 0);
            bool partyBDefeated = _partyB.Characters.All(c => AsDamageable(c).CurrentHp <= 0);

            if (partyBDefeated)
            {
                State = BattleState.Victory;
            }
            else if (partyADefeated)
            {
                State = BattleState.Defeat;
            }
            else
            {
                _turns.Add(new TurnRecord(_turns.Count + 1, _partyA, _partyB));
                _actingSubmissions.Clear();
                _opposingSubmissions.Clear();
                State = BattleState.PartyTurn;
            }
        }

        return Task.CompletedTask;
    }

    private static bool AllLivingMembersSubmitted(
        IParty party,
        Dictionary<BaseCharacter, ActionSubmission> submissions)
        => party.Characters.Where(c => AsDamageable(c).CurrentHp > 0).All(submissions.ContainsKey);

    private static IDamageable AsDamageable(BaseCharacter character)
        => (IDamageable)character;

    private readonly record struct ActionSubmission(IAction Action, BaseCharacter? Target);
}
