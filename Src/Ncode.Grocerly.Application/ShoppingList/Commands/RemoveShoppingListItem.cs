using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Application.Repository;
using Ncode.Grocerly.Domain.Common;
using System.Linq;

namespace Ncode.Grocerly.Application.Commands
{
    public class RemoveShoppingListItem : ICommand<(long shoppingListId, string name, string username)>
    {
        private readonly IGrocerlyDbContext _dbContext;

        private readonly IShoppingListPermissionRepository _permissionRepository;

        public RemoveShoppingListItem(
            IGrocerlyDbContext dbContext,
            IShoppingListPermissionRepository permissionRepository)
        {
            _dbContext = dbContext;
            _permissionRepository = permissionRepository;
        }

        public void Handle((long shoppingListId, string name, string username) parameter)
        {
            var shoppingList = _dbContext.ShoppingLists.FirstOrDefault(shoppingList => shoppingList.Id == parameter.shoppingListId);
            if (shoppingList is null)
            {
                throw new MissingShoppingListException();
            }

            var isAuthorized = _permissionRepository.ValidatePermission(parameter.shoppingListId, parameter.username);
            if (!isAuthorized)
            {
                throw new UnauthorizedShopperException();
            }

            shoppingList.RemoveItem((Name)parameter.name);
            _dbContext.ShoppingLists.Update(shoppingList);
            _dbContext.SaveChanges();
        }
    }
}
