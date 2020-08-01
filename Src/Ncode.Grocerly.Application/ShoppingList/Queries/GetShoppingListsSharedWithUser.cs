using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Application.Repository;
using Ncode.Grocerly.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncode.Grocerly.Application.Queries
{
    public class GetShoppingListsSharedWithUser : IQuery<string, IEnumerable<ShoppingList>>
    {
        private readonly IGrocerlyDbContext _dbContext;

        public GetShoppingListsSharedWithUser(
            IGrocerlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ShoppingList> Handle(string username)
        {
            var sharee = _dbContext.Shoppers.FirstOrDefault(shopper => shopper.Username.Equals(username));
            if (sharee is null)
            {
                throw new UnregisteredShopperException();
            }

            var sharedShoppingListIds = new List<ShoppingList>();
            return sharedShoppingListIds;
        }
    }
}
