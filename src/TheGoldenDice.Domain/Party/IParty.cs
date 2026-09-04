using TheGoldenDice.Domain.CharacterClasses;

namespace TheGoldenDice.Domain.Party;

public interface IParty
{
 List<BaseCharacter> Characters { get; set; }   
}