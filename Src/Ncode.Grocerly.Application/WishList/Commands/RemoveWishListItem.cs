using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Domain.Common;
using System;
using System.Linq;

namespace Ncode.Grocerly.Application.Commands
{
    public class RemoveWishListItem : ICommand<(string name, string username)>
    {
        private readonly IGrocerlyDbContext _dbContext;

        public RemoveWishListItem(IGrocerlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle((string name, string username) parameters)
        {

            var shopper = _dbContext.Shoppers
                .FirstOrDefault(shopper => shopper.Username.Equals(parameters.username));

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

            wishList.RemoveItem((Name)parameters.name);
            _dbContext.WishLists.Update(wishList);
            _dbContext.SaveChanges();
        }
    }
}
