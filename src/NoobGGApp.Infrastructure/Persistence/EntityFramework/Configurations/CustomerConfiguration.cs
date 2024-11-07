using Microsoft.EntityFrameworkCore;
using NoobGGApp.Domain.Entities;
using NoobGGApp.Domain.ValueObjects;

namespace NoobGGApp.Infrastructure.Persistence.EntityFramework.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customer> builder)
    {
        // ID  - Primary Key
        builder.HasKey(customer => customer.Id);
        builder.Property(customer => customer.Id)
        .ValueGeneratedOnAdd()
        .HasConversion(customerId => customerId.Value, value => new CustomerId(value));

        // Email
        builder.Property(customer => customer.Email)
        .IsRequired()
        .HasConversion(email => email.Value, value => new Email(value));

        // Full Name
        builder.OwnsOne(customer => customer.FullName, fullNameBuilder =>
        {
            fullNameBuilder.Property(fullName => fullName.FirstName)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("first_name");

            fullNameBuilder.Property(fullName => fullName.LastName)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("last_name");
        });

        // Address
        builder.OwnsOne(customer => customer.Address, addressBuilder =>
        {
            addressBuilder.Property(address => address.Street)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("street");

            addressBuilder.Property(address => address.City)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("city");

            addressBuilder.Property(address => address.Country)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("country");

            addressBuilder.Property(address => address.ZipCode)
            .IsRequired()
            .HasMaxLength(10)
            .HasColumnName("zip_code");

            addressBuilder.Property(address => address.State)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("state");
        });
    }
}
