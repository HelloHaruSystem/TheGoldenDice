using TheGoldenDice.Domain.Character;

namespace TheGoldenDice.Domain.Party;

public sealed class PartyFactory : IPartyFactory
{
    public IParty Create(IReadOnlyList<BaseCharacter> characters)
    {
        if (characters.Count is < 1 or > 4)
            throw new ArgumentException("A party must have between 1 and 4 characters.", nameof(characters));

        return new Party(characters.ToList());
    }
}
