using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Ncode.Grocerly.Application.Queries
{
    public class GetShopperProfile : IRequestHandler<ShopperProfileRequest, ShopperProfileResponse>
    {
        private readonly IGrocerlyDbContext _dbContext;

        public GetShopperProfile(IGrocerlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ShopperProfileResponse> Handle(ShopperProfileRequest request, CancellationToken cancellationToken)
        {
            var shopper = _dbContext
                .Shoppers
                .FirstOrDefault(shopper => shopper.Username.Equals(request.Username));

            if (shopper is null)
            {
                throw new UnregisteredShopperException();
            }

            var wishList = _dbContext
                .WishLists
                .Include(w => w.Items)
                .FirstOrDefault(w => w.OwnerId == shopper.Id);

            var ownedShoppingLists = _dbContext
                .ShoppingLists
                .Where(s => s.OwnerId == shopper.Id)
                .Select(s => new KeyValuePair<long, string>(s.Id, s.Name))
                .ToList();

            var shopperProfile = new ShopperProfileResponse()
            {
                Username = request.Username,
                WishList = wishList,
                ShoppingLists = ownedShoppingLists
            };

            return Task.FromResult(shopperProfile);
        }
    }
}
