using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using System.Linq;

namespace Ncode.Grocerly.Application.Commands
{
    public class ShareShoppingList : ICommand<(long shoppingListId, string ownerUsername, string sharedWithUsername)>
    {
        private readonly IGrocerlyDbContext _dbContext;

        public ShareShoppingList(IGrocerlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle((long shoppingListId, string ownerUsername, string sharedWithUsername) parameter)
        {
            var shoppingList = _dbContext.ShoppingLists.FirstOrDefault(shoppingList => shoppingList.Id == parameter.shoppingListId);
            if (shoppingList is null)
            {
                throw new MissingShoppingListException();
            }

            var owner = _dbContext.Shoppers
                .FirstOrDefault(shopper => shopper.Username.Equals(parameter.ownerUsername));
            if (owner.Id != shoppingList.OwnerId)
            {
                throw new UnauthorizedShopperException();
            }

            var sharedWith = _dbContext.Shoppers
                .FirstOrDefault(shopper => shopper.Username.Equals(parameter.sharedWithUsername));
            if (sharedWith is null)
            {
                throw new UnregisteredShopperException("User doesn't exist to share the shopping list.");
            }

            owner.Share(sharedWith.Id, shoppingList.Id);
            _dbContext.Shoppers.Update(owner);
            _dbContext.SaveChanges();
        }
    }
}
