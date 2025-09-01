using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionManager.Domain.Entities;

namespace VersionManager.Infra.Configurations
{
    internal sealed class LaunchConfiguration : IEntityTypeConfiguration<Launch>
    {
        public void Configure(EntityTypeBuilder<Launch> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Message)
                .HasMaxLength(500);

            builder.HasOne(l => l.Version)
                .WithMany(v => v.Launchs)
                .HasForeignKey(l => l.VersionId)
                .IsRequired();
        }  
    }
}
