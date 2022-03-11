using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EntitiesConfiguration
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasColumnName(@"Id")
                .IsRequired()
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Hotel)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.HotelId);

            builder.Property(x => x.Role);
        }
    }
}
