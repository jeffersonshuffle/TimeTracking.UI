using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TimeTracking.DataModels;
using TimeTracking.DAL;
using TimeTracking.MySQL;
using TimeTracking.DAL.Options;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDAL(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddContext(configuration);
        services.AddScoped<IUnitOfWork>(provider => provider.GetService<ApplicationDbContext>());
        services.AddDbSets();
        services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
        services.AddScoped(typeof(IQueryableDataAdapter<>), typeof(QueryableDataAdapter<>));

        return services;
    }

    private static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlConnection = configuration.GetSection(nameof(MySqlConnectionOptions)).Get<MySqlConnectionOptions>();
        var useMsSql = true;
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySQL(configuration.GetConnectionString(sqlConnection.ConnectionStringName)));
        return services;
    }

    private static IEnumerable<Type> EntityTypes => typeof(Entity).Assembly.GetTypes() // все типы сборки Entities
        .Where(t => t.IsClass);

    private static IServiceCollection AddDbSets(this IServiceCollection services)
    {
        var getDbSet = typeof(DbContext).GetMethod(nameof(DbContext.Set), Array.Empty<Type>());

        foreach (var entityType in EntityTypes)
        {
            var genericSet = getDbSet.MakeGenericMethod(entityType);
            services.AddScoped(
                typeof(DbSet<>).MakeGenericType(entityType),
                provider =>
                    genericSet.Invoke(provider.GetService<ApplicationDbContext>(), Array.Empty<object>()));
        }
        return services;
    }

}
