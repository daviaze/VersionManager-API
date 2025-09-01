using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VersionManager.Infra.Context;

namespace VersionManager.Infra.DependencyInjection
{
    public sealed class InfraConfiguration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            return services
            .AddDbContext<VersionContext>((sp, opt) =>
            {
                opt.UseInMemoryDatabase("ProjectManager");
            });
        }
    }
}
