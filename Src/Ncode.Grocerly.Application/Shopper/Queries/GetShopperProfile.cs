using MediatR;
using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
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
            var shopper = _dbContext
                .Shoppers
                .FirstOrDefault(shopper => shopper.Username.Equals(request.Username));

            if (shopper is null)
            {
                throw new UnregisteredShopperException();
            }

            return Task.FromResult(new ShopperProfileResponse());
        }
    }
}
