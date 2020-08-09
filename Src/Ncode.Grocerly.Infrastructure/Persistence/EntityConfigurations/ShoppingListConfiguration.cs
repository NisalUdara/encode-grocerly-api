using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ncode.Grocerly.Domain;
using Ncode.Grocerly.Domain.Common;

namespace Ncode.Grocerly.Infrastructure.Persistence.EntityConfigurations
{
    internal class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .ValueGeneratedNever()
                .HasColumnType("bigint")
                .IsRequired();
            builder.Property(s => s.IsCompleted)
                .HasColumnType("bit")
                .IsRequired();
            builder.Property(s => s.IsEmpty)
                .HasColumnType("bit")
                .IsRequired();
            builder.Property(s => s.Name)
                .HasConversion(n => n.Text, n => (Name)n)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(s => s.OwnerId)
                .HasColumnType("bigint")
                .IsRequired();
            builder.Property(s => s.HasAllItemsPicked)
                .HasColumnType("bit")
                .IsRequired();
            builder.Property(s => s.FinishedDateTime)
                .HasColumnType("datetime");
            builder.Property(s => s.CreatedDateTime)
                .HasColumnType("datetime")
                .IsRequired();
            builder.HasMany(s => s.Items)
                .WithOne();
            builder.Property<byte[]>("Version")
                .IsRowVersion();

            builder.Ignore(s => s.HasAllItemsPicked);
        }
    }
}
