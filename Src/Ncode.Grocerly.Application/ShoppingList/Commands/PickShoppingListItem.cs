using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Application.Repository;
using Ncode.Grocerly.Domain.Common;

namespace Ncode.Grocerly.Application.Commands
{
    public class PickShoppingListItem : ICommand<(long shoppingListId, string name, string username)>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IShoppingListPermissionRepository _permissionRepository;

        public PickShoppingListItem(IUnitOfWork unitOfWork,
            IShoppingListPermissionRepository permissionRepository)
        {
            _unitOfWork = unitOfWork;
            _permissionRepository = permissionRepository;
        }

        public void Handle((long shoppingListId, string name, string username) parameter)
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

            shoppingList.PickItem((Name)parameter.name);
            _unitOfWork.ShoppingLists.Update(shoppingList);
            _unitOfWork.Save();
        }
    }
}
