using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ncode.Grocerly.Domain;

namespace Ncode.Grocerly.Infrastructure.Persistence.EntityConfigurations
{
    internal class WishListConfiguration : IEntityTypeConfiguration<WishList>
    {
        public void Configure(EntityTypeBuilder<WishList> builder)
        {
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Id)
                .HasColumnType("int")
                .IsRequired();
            builder.Property(s => s.OwnerId)
                .HasColumnType("int")
                .IsRequired();
            builder.HasMany(s => s.Items)
                .WithOne()
            //builder.Property(s => s.)
        }
    }
}
