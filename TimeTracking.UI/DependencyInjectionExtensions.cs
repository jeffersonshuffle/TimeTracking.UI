using System.Reflection;
using TimeTracking.UI.Views;

namespace Microsoft.Extensions.DependencyInjection;

internal static class DependencyInjectionExtensions
{
    internal static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddSelfRegisteredServices(Assembly.GetExecutingAssembly());
        return services;
    }

    internal static IServiceCollection AddViews(this IServiceCollection services)
    {
        services.AddScoped<EditEmployeeForm>();
        return services;
    }

}
