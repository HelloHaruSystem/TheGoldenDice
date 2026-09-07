using TheGoldenDice.Domain.Party;

namespace TheGoldenDice.Battle.Domain.Turn;

public interface ITurn
{
    int Number { get; set; }
    IParty ActingParty { get; set; }
    IParty OpposingParty { get; set; }
}
