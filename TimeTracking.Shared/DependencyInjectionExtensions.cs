using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TimeTracking.Abstractions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        private static IEnumerable<(Type, Type)> GetByType(Type type, Assembly assembly)
            => assembly.GetTypes().Where(t => !t.IsAbstract)
                  .SelectMany(t => t.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == type)
                  .Select(s => (s.GetGenericArguments().First(), t)));

        public static IServiceCollection AddSelfRegisteredServices(this IServiceCollection services, Assembly assembly)
        {            
            foreach (var dependency in GetByType(typeof(ISelfRegisteredService<>), assembly))
            {
                services.AddScoped(dependency.Item1, dependency.Item2);
            }
            return services;
        }
    }
}

































