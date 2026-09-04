using TheGoldenDice.Domain.Characters;

namespace TheGoldenDice.Domain.Action;

internal sealed class GetSomeFreshAirAction(
    string name,
    string description,
    int coolDownTurns,
    int requiredLevel,
    HashSet<IClass> allowedClasses)
    : IAction
{
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public int CoolDownTurns { get; set; } = coolDownTurns;
    public int RequiredLevel { get; set; } = requiredLevel;
    public HashSet<IClass> AllowedClasses { get; set; } = allowedClasses;

    public void Execute()
    {
        throw new NotImplementedException();
    }
}
