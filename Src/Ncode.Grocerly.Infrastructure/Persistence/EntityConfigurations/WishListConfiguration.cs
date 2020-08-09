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
                .HasColumnType("bigint")
                .IsRequired();
            builder.Property(s => s.OwnerId)
                .HasColumnType("bigint")
                .IsRequired();
            builder.HasMany(s => s.Items)
                .WithOne();
            builder.Property<byte[]>("Version")
                .IsRowVersion();
        }
    }
}
