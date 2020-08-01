using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Application.Repository;
using Ncode.Grocerly.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Ncode.Grocerly.Application.Commands
{
    public class AddShoppingListItem : ICommand<(long shoppingListId, string name, UnitOfMeasure unitOfMeasure, int quantity, string username)>
    {
        private readonly IGrocerlyDbContext _dbContext;

        private readonly IShoppingListPermissionRepository _permissionRepository;

        public AddShoppingListItem(
            IGrocerlyDbContext dbContext,
            IShoppingListPermissionRepository permissionRepository)
        {
            _dbContext = dbContext;
            _permissionRepository = permissionRepository;
        }

        public void Handle((long shoppingListId, string name, UnitOfMeasure unitOfMeasure, int quantity, string username) parameter)
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

            shoppingList.AddItem((Name)parameter.name, parameter.unitOfMeasure, parameter.quantity);
            _dbContext.ShoppingLists.Update(shoppingList);
            _dbContext.SaveChanges();
        }
    }
}
