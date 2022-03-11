using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EntitiesConfiguration
{
    internal class SupportRequestConfiguration : IEntityTypeConfiguration<SupportRequest>
    {
        public void Configure(EntityTypeBuilder<SupportRequest> builder)
        {
            builder.ToTable("SupportRequest");
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasColumnName(@"Id")
                .IsRequired()
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(x => x.DateTime)
                .IsRequired();

            builder.Property(x => x.UserName)
                .HasMaxLength(255);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(100);

            builder.Property(x => x.Theme)
                .HasMaxLength(255);

            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(x => x.Status)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.SupportRequests)
                .HasForeignKey(x => x.UserId);
        }
    }
}
