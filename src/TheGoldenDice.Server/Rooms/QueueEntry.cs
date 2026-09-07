using TheGoldenDice.Domain.Party;

namespace TheGoldenDice.Server.Rooms;

public sealed record QueueEntry(IParty Party, string ConnectionId);
