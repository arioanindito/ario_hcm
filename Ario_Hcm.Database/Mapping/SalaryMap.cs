using System;
using Ario_Hcm.Database.Common;
using Ario_Hcm.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ario_Hcm.Database.Mapping
{
    public class SalaryMap : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder.ToTable(Tables.Salaries, "dbo");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasValueGenerator<IdValueGenerator>()
                .HasColumnName("id")
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(e => e.Amount)
                .HasColumnType("numeric(18,2)")
                .HasColumnName("amount")
                .IsRequired();

            builder.Property(e => e.Currency)
                .IsFixedLength()
                .HasMaxLength(3)
                .HasColumnName("currency")
                .IsRequired();

            builder.Property(e => e.AssignmentId)
                .HasColumnName("assignment_id")
                .IsRequired();

            builder.HasOne(e => e.Assignment)
                .WithMany(e => e.Sallaries)
                .HasForeignKey(e => e.AssignmentId)
                .IsRequired();
        }
    }
}
