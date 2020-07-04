using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using System.Linq;

namespace Ncode.Grocerly.Application.Commands
{
    public class ShareShoppingList : ICommand<(long shoppingListId, string ownerUsername, string sharedWithUsername)>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShareShoppingList(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Handle((long shoppingListId, string ownerUsername, string sharedWithUsername) parameter)
        {
            var shoppingList = _unitOfWork.ShoppingLists.GetById(parameter.shoppingListId);
            if (shoppingList is null)
            {
                throw new MissingShoppingListException();
            }

            var owner = _unitOfWork.Shoppers
                .Get(shopper => shopper.Username.Equals(parameter.ownerUsername))
                .FirstOrDefault();
            if (owner.Id != shoppingList.OwnerId)
            {
                throw new UnauthorizedShopperException();
            }

            var sharedWith = _unitOfWork.Shoppers
                .Get(shopper => shopper.Username.Equals(parameter.sharedWithUsername))
                .FirstOrDefault();
            if (sharedWith is null)
            {
                throw new UnregisteredShopperException("User doesn't exist to share the shopping list.");
            }

            owner.Share(sharedWith.Id, shoppingList.Id);
            _unitOfWork.Shoppers.Update(owner);
            _unitOfWork.Save();
        }
    }
}
