using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Domain;
using System.Linq;

namespace Ncode.Grocerly.Application.Queries
{
    public class GetWishList: IQuery<string, WishList>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetWishList(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public WishList Handle(string username)
        {
            var shopper = _unitOfWork.Shoppers
                .Get(shopper => shopper.Username.Equals(username))
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

            return wishList;
        }
    }
}
