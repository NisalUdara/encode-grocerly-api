using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Domain.Common;
using System.Linq;

namespace Ncode.Grocerly.Application.Commands
{
    public class AddWishListItem : ICommand<(string username, Name name, UnitOfMeasure unitOfMeasure, int quantity)>
    {
        private readonly IGrocerlyDbContext _dbContext;

        public AddWishListItem(IGrocerlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle((string username, Name name, UnitOfMeasure unitOfMeasure, int quantity) parameters)
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

            wishList.AddItem(parameters.name, parameters.unitOfMeasure, parameters.quantity);
            _dbContext.WishLists.Update(wishList);
            _dbContext.SaveChanges();
        }
    }
}
