using Microsoft.EntityFrameworkCore;

namespace TimeTracking.DAL;

internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    public DbSet<TEntity> Set { get; private set; }
    public Repository(DbSet<TEntity> set) => Set = set;

    public void Insert(TEntity entity)
    {
        Set.Add(entity);
        Inserted(entity);
    }

    protected virtual void Inserted(TEntity entity)
    {
        // по умолчанию ничего не делаем
    }

    public void Attach(TEntity entity)
    {
        Set.Attach(entity);
    }

    public void Update(TEntity entity)
    {
        Set.Update(entity);
    }


    public void Delete(TEntity entity)
    {
        Set.Remove(entity);
    }
}
    

