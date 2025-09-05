using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VersionManager.Domain.Entities;
using VersionManager.Domain.Entities.VersionAggregate;

namespace VersionManager.Infra.Context
{
    internal sealed class VersionContext : DbContext
    {
        public DbSet<VersionBase> Version => Set<VersionBase>();
        public DbSet<BugReport> BugReport => Set<BugReport>();
        public DbSet<VersionManager.Domain.Entities.System> System 
            => Set<VersionManager.Domain.Entities.System>();
        public DbSet<Contract> Contract => Set<Contract>();
        public DbSet<Customer> Customer => Set<Customer>();
        public DbSet<Launch> Launch => Set<Launch>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var assembly = Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
