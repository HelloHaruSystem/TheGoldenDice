using TheGoldenDice.Domain.Party;

namespace TheGoldenDice.Battle.Domain.Turn;

internal sealed class Turn(
    int number,
    IParty actingParty,
    IParty opposingParty
    ) : ITurn
{
    public int Number { get; set; } = number;
    public IParty ActingParty { get; set; } = actingParty;
    public IParty OpposingParty { get; set; } = opposingParty;
}
