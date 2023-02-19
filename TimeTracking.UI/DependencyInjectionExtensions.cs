namespace Microsoft.Extensions.DependencyInjection;

internal static class DependencyInjectionExtensions
{
    internal static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        return services.AddSelfRegisteredServices();
    }
}
