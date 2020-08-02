using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Domain.Common;
using System.Linq;

namespace Ncode.Grocerly.Application.Commands
{
    public class PickShoppingListItem : ICommand<(long shoppingListId, string name, string username)>
    {
        private readonly IGrocerlyDbContext _dbContext;

        public PickShoppingListItem(IGrocerlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle((long shoppingListId, string name, string username) parameter)
        {
            var shoppingList = _dbContext.ShoppingLists.FirstOrDefault(shoppingList => shoppingList.Id == parameter.shoppingListId);
            if (shoppingList is null)
            {
                throw new MissingShoppingListException();
            }

            var isAuthorized = false;
            if (!isAuthorized)
            {
                throw new UnauthorizedShopperException();
            }

            shoppingList.PickItem((Name)parameter.name);
            _dbContext.ShoppingLists.Update(shoppingList);
            _dbContext.SaveChanges();
        }
    }
}
