using TheGoldenDice.Domain.Action;
using TheGoldenDice.Domain.Classes;
using TheGoldenDice.Domain.Items;

namespace TheGoldenDice.Domain.Character;

public interface ICharacterFactory
{
    BaseCharacter CreatePlayerCharacter(
        string name,
        int level,
        IClass characterClass,
        IHeadGear? headGear,
        IWeapon? weapon,
        List<IAction> actions);

    BaseCharacter CreateNpcCharacter(
        string name,
        int level,
        IClass characterClass,
        IHeadGear? headGear,
        IWeapon? weapon,
        List<IAction> actions,
        List<string> tauntMessages);
}
