namespace TheGoldenDice.Server.Rooms;

internal sealed class RoomWorker(Room room) : IHostedService
{
    private CancellationTokenSource? _cancellation;
    private Thread? _thread;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _cancellation = new CancellationTokenSource();
        _thread = new Thread(() => ProcessQueue(_cancellation.Token))
        {
            IsBackground = true,
            Name = $"room-worker-{room.Id}"
        };
        _thread.Start();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _cancellation?.Cancel();
        room.Queue.CompleteAdding();
        _thread?.Join();
        return Task.CompletedTask;
    }

    private void ProcessQueue(CancellationToken cancellationToken)
    {
        try
        {
            foreach (QueueEntry entry in room.Queue.GetConsumingEnumerable(cancellationToken))
            {
                try
                {
                    Match(entry);
                }
                catch (Exception)
                {
                }
            }
        }
        catch (OperationCanceledException)
        {
        }
    }

    private static void Match(QueueEntry entry)
        => throw new NotImplementedException();
}
