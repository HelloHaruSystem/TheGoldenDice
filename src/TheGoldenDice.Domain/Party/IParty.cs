using TheGoldenDice.Domain.Character;

namespace TheGoldenDice.Domain.Party;

public interface IParty
{
 List<BaseCharacter> Characters { get; set; }   
}