using TheGoldenDice.Domain.Character;

namespace TheGoldenDice.Domain.Party;

internal sealed class Party : IParty
{
    public List<BaseCharacter> Characters { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}