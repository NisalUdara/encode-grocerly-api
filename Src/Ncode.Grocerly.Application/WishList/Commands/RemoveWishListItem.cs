using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Domain.Common;
using System;
using System.Linq;

namespace Ncode.Grocerly.Application.Commands
{
    public class RemoveWishListItem : ICommand<(string name, string username)>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveWishListItem(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Handle((string name, string username) parameters)
        {

            var shopper = _unitOfWork.Shoppers
                .Get(shopper => shopper.Username.Equals(parameters.username))
                .FirstOrDefault();

            if (shopper is null)
            {
                throw new UnregisteredShopperException();
            }

            var wishList = _unitOfWork.WishLists
                .Get(wishList => wishList.OwnerId == shopper.Id)
                .FirstOrDefault();

            if (wishList is null)
            {
                throw new UnregisteredShopperException();
            }

            wishList.RemoveItem((Name)parameters.name);
            _unitOfWork.WishLists.Update(wishList);
            _unitOfWork.Save();
        }
    }
}
