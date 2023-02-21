using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

internal static class DependencyInjectionExtensions
{
    internal static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddSelfRegisteredServices(Assembly.GetExecutingAssembly());
        return services;
    }
}
