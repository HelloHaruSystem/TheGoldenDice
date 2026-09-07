namespace TheGoldenDice.Server.Rooms;

internal sealed class RoomRegistry : IRoomRegistry
{
    private readonly Dictionary<string, IRoom> _rooms;

    public RoomRegistry(IReadOnlyList<Room> rooms)
    {
        _rooms = rooms.ToDictionary(room => room.Id, room => (IRoom)room);
        Rooms = rooms;
    }

    public IReadOnlyList<IRoom> Rooms { get; }

    public IRoom GetRoom(string id)
        => _rooms.TryGetValue(id, out IRoom? room)
            ? room
            : throw new KeyNotFoundException($"No room with id '{id}'.");
}
