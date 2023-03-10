using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace TimeTracking.DAL;
public interface IRepository<TEntity> where TEntity : class
{
    DbSet<TEntity> Set { get;}        
    void Attach(TEntity entity);
    void Delete(TEntity entity);
    void Insert(TEntity entity);
    void Update(TEntity entity);
}