using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ncode.Grocerly.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Infrastructure.Persistence.EntityConfigurations
{
    internal class ShareConfiguration : IEntityTypeConfiguration<Share>
    {
        public void Configure(EntityTypeBuilder<Share> builder)
        {
            builder.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.HasKey("Id");
            builder.Property(s => s.ShopperId)
                .HasColumnType("int")
                .IsRequired();
            builder.Property(s => s.ShoppingListId)
                .HasColumnType("int")
                .IsRequired();
            builder.Property<byte[]>("Version")
                .IsRowVersion();
        }
    }
}
