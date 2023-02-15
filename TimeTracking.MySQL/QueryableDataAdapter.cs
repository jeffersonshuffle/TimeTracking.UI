using Microsoft.EntityFrameworkCore;

namespace TimeTracking.DAL
{
    internal class QueryableDataAdapter<TEntity>: IQueryableDataAdapter<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> _set;
        public QueryableDataAdapter(DbSet<TEntity> set) => _set = set;
        public IQueryable<TEntity> AsQueryable() => _set.AsNoTracking().AsQueryable();
    }
}
