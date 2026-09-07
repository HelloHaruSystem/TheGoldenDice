using TheGoldenDice.Domain.Character;

namespace TheGoldenDice.Domain.Party;

public interface IPartyFactory
{
    IParty Create(IReadOnlyList<BaseCharacter> characters);
}
