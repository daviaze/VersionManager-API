using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VersionManager.Domain.Entities;

namespace VersionManager.Infra.Configurations
{
    internal sealed class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ExternalId)
                .ValueGeneratedOnAdd();

            builder.HasMany(x => x.Customers)
                .WithMany(c => c.Contracts);

            builder.HasMany(x => x.Systems)
                .WithMany(s => s.Contracts);
        }
    }
}
