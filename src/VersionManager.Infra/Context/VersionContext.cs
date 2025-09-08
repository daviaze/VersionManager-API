using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VersionManager.Domain.Entities;
using VersionManager.Domain.Entities.VersionAggregate;

namespace VersionManager.Infra.Context
{
    internal sealed class VersionContext(DbContextOptions<VersionContext> options) : DbContext(options)
    {
        internal DbSet<VersionBase> Version => Set<VersionBase>();
        internal DbSet<BugReport> BugReport => Set<BugReport>();
        internal DbSet<VersionManager.Domain.Entities.System> System => Set<VersionManager.Domain.Entities.System>();
        internal DbSet<Contract> Contract => Set<Contract>();
        internal DbSet<Customer> Customer => Set<Customer>();
        internal DbSet<Launch> Launch => Set<Launch>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var assembly = Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
