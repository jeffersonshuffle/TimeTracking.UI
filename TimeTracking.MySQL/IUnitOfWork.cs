namespace TimeTracking.DAL;
public interface IUnitOfWork
{
    int SaveChanges();
    int SaveChanges(bool acceptAllChangesOnSuccess);
    Task<int> SaveChangesAsync(CancellationToken token = default);
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken token = default);
}