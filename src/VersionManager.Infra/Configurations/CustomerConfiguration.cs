using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VersionManager.Domain.Entities;

namespace VersionManager.Infra.Configurations
{
    internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(100);

            builder.Property(x => x.Document)
                .HasMaxLength(14);

            builder.Property(x => x.Email)
                .HasMaxLength(100);

            builder.HasMany(x => x.Contracts)
                .WithMany(c => c.Customers);
        }
    }
}
