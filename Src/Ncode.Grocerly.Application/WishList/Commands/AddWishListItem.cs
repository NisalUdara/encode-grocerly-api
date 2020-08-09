using MediatR;
using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Domain.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ncode.Grocerly.Application.Commands
{
    public class AddWishListItem : IRequestHandler<AddWishListItemRequest, Unit>
    {
        private readonly IGrocerlyDbContext _dbContext;

        public AddWishListItem(IGrocerlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Unit> Handle(AddWishListItemRequest request, CancellationToken cancellationToken)
        {
            var shopper = _dbContext.Shoppers
                .FirstOrDefault(shopper => shopper.Username.Equals(request.Username));

            if (shopper is null)
            {
                throw new UnauthorizedShopperException();
            }

            var wishList = _dbContext.WishLists
                .FirstOrDefault(wishList => wishList.OwnerId == shopper.Id && wishList.Id == request.WishListId);

            if (wishList is null)
            {
                throw new UnauthorizedShopperException();
            }

            wishList.AddItem(request.Item.Name, request.Item.UnitOfMeasure, request.Item.Quantity);
            _dbContext.WishLists.Update(wishList);
            _dbContext.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}
