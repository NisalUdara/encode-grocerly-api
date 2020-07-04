using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Domain.Common;
using System.Linq;

namespace Ncode.Grocerly.Application.Commands
{
    public class AddWishListItem : ICommand<(string username, Name name, UnitOfMeasure unitOfMeasure, int quantity)>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddWishListItem(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Handle((string username, Name name, UnitOfMeasure unitOfMeasure, int quantity) parameters)
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

            wishList.AddItem(parameters.name, parameters.unitOfMeasure, parameters.quantity);
        }
    }
}
