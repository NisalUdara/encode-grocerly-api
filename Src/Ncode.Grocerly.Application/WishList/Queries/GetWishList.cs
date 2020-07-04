using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Application.Repository;
using Ncode.Grocerly.Domain;
using System.Linq;

namespace Ncode.Grocerly.Application.Queries
{
    public class GetWishList: IQuery<string, WishList>
    {
        private readonly IRepository<Shopper> _shopperRepository;
        private readonly IRepository<WishList> _wishListrepository;

        public GetWishList(
            IRepository<Shopper> shopperRepository,
            IRepository<WishList> wishListrepository)
        {
            _shopperRepository = shopperRepository;
            _wishListrepository = wishListrepository;
        }

        public WishList Handle(string username)
        {
            var shopper = _shopperRepository
                .Get(shopper => shopper.Username.Equals(username))
                .FirstOrDefault();

            if (shopper is null)
            {
                throw new UnregisteredShopperException();
            }

            var wishList = _wishListrepository
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
