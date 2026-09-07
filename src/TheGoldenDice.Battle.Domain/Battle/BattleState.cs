namespace TheGoldenDice.Battle.Domain.Battle;

public enum BattleState
{
    NotStarted,
    PartyTurn,
    OppositePartyTurn,
    ResolveTurn,
    CheckStatus,
    Victory,
    Defeat
}
