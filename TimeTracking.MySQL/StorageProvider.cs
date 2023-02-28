using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace TimeTracking.MySQL;

internal class StorageProvider: IStorageProvider
{
    public DatabaseFacade Database { get; init; }
}
