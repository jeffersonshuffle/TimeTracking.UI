namespace TimeTracking.DAL;

public interface IQueryableDataAdapter<TEntity>
    where TEntity : class
{
    IQueryable<TEntity> AsQueryable();
}
