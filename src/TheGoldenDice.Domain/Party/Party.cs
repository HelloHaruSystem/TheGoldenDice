using TheGoldenDice.Domain.Character;

namespace TheGoldenDice.Domain.Party;

public sealed class Party(List<BaseCharacter> characters) : IParty
{
    public List<BaseCharacter> Characters { get; set; } = characters;
}