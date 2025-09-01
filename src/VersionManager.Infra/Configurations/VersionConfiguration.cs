using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VersionManager.Domain.Entities.VersionAggregate;
using VersionManager.Domain.Enums;

namespace VersionManager.Infra.Configurations
{
    internal sealed class VersionConfiguration : IEntityTypeConfiguration<VersionBase>
    {
        public void Configure(EntityTypeBuilder<VersionBase> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasOne(v => v.System)
                .WithMany(s => s.Versions)
                .HasForeignKey(v => v.SystemId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(v => v.BugReports)      
                .WithOne(br => br.Version)
                .HasForeignKey(br => br.VersionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasDiscriminator(x => x.AmbientVersion)
                .HasValue<ReleaseVersion>(AmbientVersion.release)
                .HasValue<ApprovalVersion>(AmbientVersion.approval);
        }
    }
}
