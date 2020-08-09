using Microsoft.EntityFrameworkCore;
using Ncode.Grocerly.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ncode.Grocerly.Application.Common
{
    public interface IGrocerlyDbContext
    {

        public DbSet<Shopper> Shoppers { get; set; }

        public DbSet<Share> ShareDetails { get; set; }

        public DbSet<ShoppingList> ShoppingLists { get; set; }

        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }

        public DbSet<WishList> WishLists { get; set; }

        public DbSet<WishListItem> WishListItems { get; set; }

        public int SaveChanges();
    }
}
