using TheGoldenDice.Domain.Character;
using TheGoldenDice.Domain.Classes;
using TheGoldenDice.Domain.Common;

namespace TheGoldenDice.Domain.Action;

public interface IAction : ICatalogItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int CoolDownTurns { get; set; }
    public int RequiredLevel { get; set; }
    public HashSet<IClass> AllowedClasses { get; set; }

    public void Execute(IDamageable actor, IReadOnlyList<IDamageable> targets, double modifier);
}
