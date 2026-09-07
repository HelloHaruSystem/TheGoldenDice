using TheGoldenDice.Domain.Character;
using TheGoldenDice.Domain.Classes;

namespace TheGoldenDice.Domain.Action;

public sealed class GetSomeFreshAirAction : IAction
{
    public string Name { get; set; } = "Get Some Fresh Air";
    public string Description { get; set; } = "Step outside for a moment to clear your head.";
    public int CoolDownTurns { get; set; } = 3;
    public int RequiredLevel { get; set; } = 1;
    public HashSet<IClass> AllowedClasses { get; set; } = [new TecTeacher()];

    public void Execute(IDamageable actor, IReadOnlyList<IDamageable> targets, double modifier)
        => actor.Heal(5);
}
