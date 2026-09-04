using TheGoldenDice.Domain.Classes;

namespace TheGoldenDice.Domain.Action;

public interface IAction
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int CoolDownTurns { get; set; }
    public int RequiredLevel { get; set; }
    public HashSet<IClass> AllowedClasses { get; set; }

    public void Execute();
}
