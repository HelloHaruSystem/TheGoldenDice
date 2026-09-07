using TheGoldenDice.Domain.Common;

namespace TheGoldenDice.Domain.Action;

public sealed class ActionCatalog : ICatalog<IAction>
{
    public IReadOnlyList<ICatalogItem> All { get; } =
    [
        new GetSomeFreshAirAction(),
        new RegisterAbsenceAction()
    ];
}
