using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Application.Repository;
using Ncode.Grocerly.Domain;
using System.Linq;

namespace Ncode.Grocerly.Application.Queries
{
    public class GetWishList: IQuery<string, WishList>
    {
        private readonly IGrocerlyDbContext _dbContext;

        public GetWishList(
            IGrocerlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public WishList Handle(string username)
        {
            var shopper = _dbContext.Shoppers
                .FirstOrDefault(shopper => shopper.Username.Equals(username));

            if (shopper is null)
            {
                throw new UnregisteredShopperException();
            }

            var wishList = _dbContext.WishLists
                .FirstOrDefault(wishList => wishList.OwnerId == shopper.Id);

            if (wishList is null)
            {
                throw new UnregisteredShopperException();
            }

            return wishList;
        }
    }
}
