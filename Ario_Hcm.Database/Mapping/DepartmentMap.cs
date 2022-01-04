using System;
using Ario_Hcm.Database.Common;
using Ario_Hcm.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ario_Hcm.Database.Mapping
{
    public sealed class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable(Tables.Departments, "dbo");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasValueGenerator<IdValueGenerator>()
                .HasColumnName("id")
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(e => e.Country)
                .IsFixedLength()
                .HasMaxLength(3)
                .HasColumnName("country")
                .IsRequired();

            builder.Property(e => e.City)
                .HasMaxLength(128)
                .HasColumnName("city")
                .IsRequired();

            builder.HasMany(e => e.Assignments)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);
        }
    }
}
