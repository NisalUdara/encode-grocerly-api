using MediatR;
using Microsoft.EntityFrameworkCore;
using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Domain.Common;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ncode.Grocerly.Application.Commands
{
    public class RemoveWishListItem : IRequestHandler<RemoveWishListItemRequest, Unit>
    {
        private readonly IGrocerlyDbContext _dbContext;

        public RemoveWishListItem(IGrocerlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle((string name, string username) parameters)
        {
        }

        public Task<Unit> Handle(RemoveWishListItemRequest request, CancellationToken cancellationToken)
        {
            var shopper = _dbContext.Shoppers
                .FirstOrDefault(shopper => shopper.Username.Equals(request.Username));

            if (shopper is null)
            {
                throw new UnauthorizedAccessException();
            }

            var wishList = _dbContext.WishLists
                .Include(w => w.Items)
                .FirstOrDefault(wishList => wishList.OwnerId == shopper.Id);

            if (wishList is null)
            {
                throw new UnauthorizedAccessException();
            }

            wishList.RemoveItem((Name)request.ItemName);
            _dbContext.WishLists.Update(wishList);
            _dbContext.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}
