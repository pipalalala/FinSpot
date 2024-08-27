using FinSpotAPI.Common.Enumerations;
using FinSpotAPI.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinSpotAPI.Domain.EntityConfiguration.Users
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("users")
                .HasKey(e => e.Id);

            builder
                .Property(p => p.Id)
                .IsRequired();

            builder
                .Property(p => p.FirstName)
                .IsRequired();

            builder
                .Property(p => p.LastName)
                .IsRequired();

            builder
                .Property(p => p.Email)
                .IsRequired();

            builder
                .Property(p => p.HashedPassword)
                .IsRequired();

            builder
                .Property(p => p.MobileNumber)
                .IsRequired(false);

            builder
                .Property(p => p.DateOfBirth)
                .IsRequired();

            builder
                .Property(p => p.Gender)
                .IsRequired()
                .HasConversion(new EnumToStringConverter<Gender>());

            builder
                .Property(p => p.GenderName)
                .IsRequired(false);


            builder
                .HasMany(_ => _.Operations)
                .WithOne(_ => _.User)
                .HasForeignKey(_ => _.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder
                .HasIndex(e => e.Email)
                .IsUnique();
        }
    }
}
