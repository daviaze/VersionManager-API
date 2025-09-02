using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VersionManager.Application.Services.Interfaces;

namespace VersionManager.Application.DependencyInjection
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            return services.AddServices(assembly);
        }

       private static IServiceCollection AddServices(
       this IServiceCollection services,
       Assembly assembly)
        {

            var typesToRegister = assembly
                .GetTypes()
                .Where(type =>
                    type is { IsClass: true, IsAbstract: false } &&
                    typeof(IService).IsAssignableFrom(type))
                .ToList();

            foreach (var type in typesToRegister)
            {
                services.AddScoped(type);
            }

            return services;
        }
    }
}
