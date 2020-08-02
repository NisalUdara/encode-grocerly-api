using Microsoft.EntityFrameworkCore;
using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Domain;
using System.Reflection;

namespace Ncode.Grocerly.Infrastructure.Persistence
{
    public class GrocerlyDbContext : DbContext, IGrocerlyDbContext
    {
        public GrocerlyDbContext(DbContextOptions<GrocerlyDbContext> options)
           : base(options)
        { }

        public DbSet<Shopper> Shoppers { get; set; }

        public DbSet<Share> ShareDetails { get; set; }

        public DbSet<ShoppingList> ShoppingLists { get; set; }

        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }

        public DbSet<WishList> WishLists { get; set; }

        public DbSet<WishListItem> WishListItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
