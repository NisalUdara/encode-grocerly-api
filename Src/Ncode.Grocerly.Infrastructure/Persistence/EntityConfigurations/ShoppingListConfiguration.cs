using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ncode.Grocerly.Domain;

namespace Ncode.Grocerly.Infrastructure.Persistence.EntityConfigurations
{
    internal class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .HasColumnType("int")
                .IsRequired();
            builder.Property(s => s.IsCompleted)
                .HasColumnType("bit")
                .IsRequired();
            builder.Property(s => s.IsEmpty)
                .HasColumnType("bit")
                .IsRequired();
            builder.Property(s => s.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(s => s.OwnerId)
                .HasColumnType("int")
                .IsRequired();
            builder.Property(s => s.HasAllItemsPicked)
                .HasColumnType("bit")
                .IsRequired();
            builder.Property(s => s.FinishedDateTime)
                .HasColumnType("datetime");
            builder.Property(s => s.CreatedDateTime)
                .HasColumnType("datetime")
                .IsRequired();
            //builder.Property(s => s.)
        }
    }
}
