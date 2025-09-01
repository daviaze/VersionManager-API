using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VersionManager.Domain.Entities;

namespace VersionManager.Infra.Configurations
{
    internal sealed class BugReportConfiguration : IEntityTypeConfiguration<BugReport>
    {
        public void Configure(EntityTypeBuilder<BugReport> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasOne(x => x.Version)
                .WithMany(v => v.BugReports)
                .HasForeignKey(x => x.VersionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
