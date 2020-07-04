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
        private readonly IRepository<Shopper> _shopperRespository;
        private readonly IShoppingListSharesRepository _sharesRespository;

        public GetShoppingListsSharedWithUser(
            IRepository<Shopper> shopperRespository,
            IShoppingListSharesRepository sharesRespository)
        {
            _shopperRespository = shopperRespository;
            _sharesRespository = sharesRespository;
        }

        public IEnumerable<ShoppingList> Handle(string username)
        {
            var sharee = _shopperRespository.Get(shopper => shopper.Username.Equals(username)).FirstOrDefault();
            if (sharee is null)
            {
                throw new UnregisteredShopperException();
            }

            var sharedShoppingListIds = _sharesRespository.GetShareShoppingListsForShopper(username);
            return sharedShoppingListIds;
        }
    }
}
