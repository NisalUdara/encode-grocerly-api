using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ncode.Grocerly.Domain;

namespace Ncode.Grocerly.Infrastructure.Persistence.EntityConfigurations
{
    internal class ShopperConfiguration : IEntityTypeConfiguration<Shopper>
    {
        public void Configure(EntityTypeBuilder<Shopper> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .HasColumnType("bigint")
                .ValueGeneratedNever()
                .IsRequired();
            builder.Property(s => s.Username)
                .HasColumnType("varchar(100)")
                .HasMaxLength(200)
                .IsRequired();
            builder.Property<byte[]>("Version")
                .IsRowVersion();
        }
    }
}
