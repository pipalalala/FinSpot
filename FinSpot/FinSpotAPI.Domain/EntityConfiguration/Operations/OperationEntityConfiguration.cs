using FinSpotAPI.Common.Enumerations;
using FinSpotAPI.Domain.Models.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinSpotAPI.Domain.EntityConfiguration.Operations
{
    public class OperationEntityConfiguration : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder
                .ToTable("operations")
                .HasKey(e => e.Id);

            builder
                .Property(p => p.Id)
                .IsRequired();

            builder
                .Property(p => p.Name)
                .IsRequired();

            builder
                .Property(p => p.DateTime)
                .IsRequired();

            builder
                .Property(p => p.Type)
                .IsRequired()
                .HasConversion(new EnumToStringConverter<OperationType>());

            builder
                .Property(p => p.Amount)
                .HasPrecision(18, 6)
                .IsRequired();

            builder
                .Property(p => p.Currency)
                .IsRequired()
                .HasConversion(new EnumToStringConverter<Currency>());

            builder
                .Property(p => p.ExpenseCategory)
                .IsRequired()
                .HasConversion(new EnumToStringConverter<ExpenseCategory>());

            builder
                .Property(p => p.Details)
                .IsRequired(false);


            builder
                .HasIndex(e => e.Name);

            builder
                .HasIndex(e => e.Amount);
        }
    }
}
