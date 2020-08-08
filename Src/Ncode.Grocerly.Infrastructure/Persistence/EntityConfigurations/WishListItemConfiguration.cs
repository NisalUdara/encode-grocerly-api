using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ncode.Grocerly.Domain;
using Ncode.Grocerly.Domain.Common;

namespace Ncode.Grocerly.Infrastructure.Persistence.EntityConfigurations
{
    internal class WishListItemConfiguration : IEntityTypeConfiguration<WishListItem>
    {
        public void Configure(EntityTypeBuilder<WishListItem> builder)
        {
            builder.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.HasKey("Id");
            builder.Property(s => s.Name)
                .HasConversion(n => n.Text, n => (Name)n)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(s => s.Quantity)
                .HasColumnType("int")
                .IsRequired();
            builder.Property(s => s.UnitOfMeasure)
                .HasColumnType("int")
                .IsRequired();
            builder.Property<byte[]>("Version")
                .IsRowVersion();
        }
    }
}
