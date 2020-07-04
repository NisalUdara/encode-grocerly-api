using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Application.Repository;
using Ncode.Grocerly.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Ncode.Grocerly.Application.Commands
{
    public class AddShoppingListItem : ICommand<(long shoppingListId, string name, UnitOfMeasure unitOfMeasure, int quantity, string username)>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IShoppingListPermissionRepository _permissionRepository;

        public AddShoppingListItem(
            IUnitOfWork unitOfWork,
            IShoppingListPermissionRepository permissionRepository)
        {
            _unitOfWork = unitOfWork;
            _permissionRepository = permissionRepository;
        }

        public void Handle((long shoppingListId, string name, UnitOfMeasure unitOfMeasure, int quantity, string username) parameter)
        {
            var shoppingList = _unitOfWork.ShoppingLists.GetById(parameter.shoppingListId);
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
            _unitOfWork.ShoppingLists.Update(shoppingList);
            _unitOfWork.Save();
        }
    }
}
