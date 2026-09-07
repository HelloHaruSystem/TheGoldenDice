using Microsoft.AspNetCore.SignalR;
using TheGoldenDice.Server.Rooms;

namespace TheGoldenDice.Server.Hubs;

public sealed class RoomHub(IRoomRegistry rooms) : Hub
{
    public Task JoinRoomAsync(string roomId)
    {
        rooms.GetRoom(roomId);
        throw new NotImplementedException();
    }
}
