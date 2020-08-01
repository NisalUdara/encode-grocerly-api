using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Application.Repository;
using Ncode.Grocerly.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Ncode.Grocerly.Application.Queries
{
    public class GetShoppingListsOwnedByUser : IQuery<string, IEnumerable<ShoppingList>>
    {
        private readonly IGrocerlyDbContext _dbContext;

        public GetShoppingListsOwnedByUser(
            IGrocerlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ShoppingList> Handle(string username)
        {
            var owner = _dbContext.Shoppers
                .FirstOrDefault(shopper => shopper.Username.Equals(username));
            if (owner is null)
            {
                throw new UnregisteredShopperException();
            }

            var shoppingLists = _dbContext.ShoppingLists
                .Where(shoppingLists => shoppingLists.OwnerId == owner.Id);
            return shoppingLists;
        }
    }
}
