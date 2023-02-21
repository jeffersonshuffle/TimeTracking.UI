namespace TimeTracking.AppCore;

public interface IAsyncCommandHandler<TCommand>
{
    Task ExecuteAsync(TCommand command, CancellationToken token = default);
}
