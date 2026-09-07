namespace TheGoldenDice.Server.Rooms;

public interface IRoomRegistry
{
    IReadOnlyList<IRoom> Rooms { get; }

    IRoom GetRoom(string id);
}
