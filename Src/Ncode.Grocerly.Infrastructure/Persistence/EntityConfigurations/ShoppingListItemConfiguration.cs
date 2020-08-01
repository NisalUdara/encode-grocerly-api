using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ncode.Grocerly.Domain;

namespace Ncode.Grocerly.Infrastructure.Persistence.EntityConfigurations
{
    internal class ShoppingListItemConfiguration : IEntityTypeConfiguration<ShoppingListItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingListItem> builder)
        {
            builder.HasKey("Id");
            builder.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(s => s.Name)
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
