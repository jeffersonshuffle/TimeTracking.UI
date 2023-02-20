namespace TimeTracking.AppCore;

public interface IAsyncQueryHandler<TQuery, TResult>
{
    Task<TResult> HandleAsync(TQuery query, CancellationToken token = default);
}
