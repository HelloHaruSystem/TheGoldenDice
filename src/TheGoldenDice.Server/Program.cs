using TheGoldenDice.Server.Hubs;
using TheGoldenDice.Server.Rooms;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

List<Room> rooms = [new Room("room-1", 24), new Room("room-2", 24)];

foreach (Room room in rooms)
{
    builder.Services.AddSingleton(room);
    builder.Services.AddSingleton<IHostedService>(new RoomWorker(room));
}

builder.Services.AddSingleton<IRoomRegistry>(new RoomRegistry(rooms));
builder.Services.AddSignalR();

WebApplication app = builder.Build();

app.MapHub<RoomHub>("/hub/rooms");

app.Run();
