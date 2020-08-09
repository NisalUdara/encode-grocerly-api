using Microsoft.EntityFrameworkCore;
using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Domain;
using Ncode.Grocerly.Infrastructure.Persistence.EntityConfigurations;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Ncode.Grocerly.Infrastructure.Persistence
{
    public class GrocerlyDbContext : DbContext, IGrocerlyDbContext
    {
        public GrocerlyDbContext(DbContextOptions<GrocerlyDbContext> options)
           : base(options)
        { }

        public DbSet<Shopper> Shoppers { get; set; }

        public DbSet<ShoppingList> ShoppingLists { get; set; }

        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }

        public DbSet<WishList> WishLists { get; set; }

        public DbSet<WishListItem> WishListItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new WishListItemConfiguration());
            builder.ApplyConfiguration(new ShoppingListItemConfiguration());
            builder.ApplyConfiguration(new ShopperConfiguration());
            builder.ApplyConfiguration(new WishListConfiguration());
            builder.ApplyConfiguration(new ShoppingListConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
