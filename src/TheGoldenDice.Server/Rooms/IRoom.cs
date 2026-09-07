namespace TheGoldenDice.Server.Rooms;

public interface IRoom
{
    string Id { get; }
    int Capacity { get; }
    int ParticipantCount { get; }

    void Enqueue(QueueEntry entry);
}
