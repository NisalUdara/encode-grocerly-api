using MediatR;
using Ncode.Grocerly.Application.Common;
using System.Linq;
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
            var usernames = _dbContext
                .Shoppers
                .Where(shopper => shopper.Username.Contains(request.Username))
                .Select(shopper => shopper.Username);

            return Task.FromResult(new ShopperProfileResponse());
        }
    }
}
