using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VersionManager.Infra.Configurations
{
    internal sealed class SystemConfiguration : IEntityTypeConfiguration<VersionManager.Domain.Entities.System>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.System> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.HasMany(x => x.Versions)
                .WithOne(x => x.System)
                .HasForeignKey(x => x.SystemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
