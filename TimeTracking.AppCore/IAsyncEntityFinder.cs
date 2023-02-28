namespace TimeTracking.AppCore
{
    public interface IAsyncEntityFinder<TIdentity, TDetails>
    {
        Task<TDetails> FindAsync(TIdentity entityId, CancellationToken token = default);
    }
}
