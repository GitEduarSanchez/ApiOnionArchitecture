using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Configuration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasColumnType("nvarchar").HasMaxLength(80).IsRequired();
            builder.Property(p => p.LastName).HasColumnType("nvarchar").HasMaxLength(80).IsRequired();
            builder.Property(p => p.DateOfBirth).IsRequired();
            builder.Property(p => p.Phone).HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
            builder.Property(p => p.Email).HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(p => p.Address).HasColumnType("nvarchar").HasMaxLength(300).IsRequired();
            builder.Property(p => p.Age);
            builder.Property(p => p.CreatedBy).HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(p => p.LastUpdatedBy).HasColumnType("nvarchar").HasMaxLength(100);
        }
    }
}
