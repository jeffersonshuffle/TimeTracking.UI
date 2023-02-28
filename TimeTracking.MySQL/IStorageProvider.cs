using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace TimeTracking.MySQL;

public interface IStorageProvider
{
    public DatabaseFacade Database { get; }
}
