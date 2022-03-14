using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EntitiesConfiguration
{
    internal class CityConfiguration : IEntityTypeConfiguration<City>
    {
		public void Configure(EntityTypeBuilder<City> builder)
		{
			builder.ToTable("City");
			builder.HasKey(e => e.Id);
			builder.Property(x => x.Id).HasColumnName(@"Id")
				.IsRequired()
				.HasColumnType("int")
				.UseIdentityColumn();

			builder.Property(x => x.Name).HasMaxLength(255).IsRequired();

			builder.Property(x => x.Latitude).HasColumnType("decimal(18,10)").IsRequired();

			builder.Property(x => x.Longitude).HasColumnType("decimal(18,10)").IsRequired();
		}
	}
}
