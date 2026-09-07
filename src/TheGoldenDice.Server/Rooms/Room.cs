using System.Collections.Concurrent;

namespace TheGoldenDice.Server.Rooms;

internal sealed class Room(string id, int capacity) : IRoom
{
    private readonly BlockingCollection<QueueEntry> _queue = new();
    private int _participantCount;

    public string Id { get; } = id;
    public int Capacity { get; } = capacity;
    public int ParticipantCount => _participantCount;

    public BlockingCollection<QueueEntry> Queue => _queue;

    public void Enqueue(QueueEntry entry)
    {
        if (Interlocked.Increment(ref _participantCount) > Capacity)
        {
            Interlocked.Decrement(ref _participantCount);
            throw new InvalidOperationException($"Room '{Id}' is full.");
        }

        _queue.Add(entry);
    }
}
