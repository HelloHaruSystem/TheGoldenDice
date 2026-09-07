using TheGoldenDice.Domain.Character;
using TheGoldenDice.Domain.Classes;

namespace TheGoldenDice.Domain.Action;

public sealed class RegisterAbsenceAction : IAction
{
    public string Name { get; set; } = "Register Absence";
    public string Description { get; set; } = "Mark someone as absent instead of dealing with them.";
    public int CoolDownTurns { get; set; } = 2;
    public int RequiredLevel { get; set; } = 1;
    public HashSet<IClass> AllowedClasses { get; set; } = [new TecTeacher()];

    public void Execute(IDamageable actor, IDamageable victim, double modifier)
    {
        throw new NotImplementedException();
    }
}
