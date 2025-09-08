using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VersionManager.Infra.Context;
using VersionManager.Infra.Repository;
using VersionManager.Infra.Repository.Contracts;

namespace VersionManager.Infra.DependencyInjection
{
    public static class InfraConfiguration
    {
        public static IServiceCollection ConfigureInfra(this IServiceCollection services)
        {
            return services
            .AddDbContext<VersionContext>((sp, opt) =>
            {
                opt.UseInMemoryDatabase("VersionManager");
            })
            .AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
