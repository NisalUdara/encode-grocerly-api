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
        private readonly IRepository<Shopper> _shopperRepository;
        private readonly IRepository<ShoppingList> _shoppingListRepository;

        public GetShoppingListsOwnedByUser(
            IRepository<Shopper> shopperRepository,
            IRepository<ShoppingList> shoppingListRepository)
        {
            _shopperRepository = shopperRepository;
            _shoppingListRepository = shoppingListRepository;
        }

        public IEnumerable<ShoppingList> Handle(string username)
        {
            var owner = _shopperRepository
                .Get(shopper => shopper.Username.Equals(username)).FirstOrDefault();
            if (owner is null)
            {
                throw new UnregisteredShopperException();
            }

            var shoppingLists = _shoppingListRepository
                .Get(shoppingLists => shoppingLists.OwnerId == owner.Id);
            return shoppingLists;
        }
    }
}
