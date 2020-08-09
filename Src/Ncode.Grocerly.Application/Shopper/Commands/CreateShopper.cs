using MediatR;
using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Application.Queries;
using Ncode.Grocerly.Common;
using Ncode.Grocerly.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ncode.Grocerly.Application.Commands
{
    public class CreateShopper : IRequestHandler<CreateShopperRequest, ShopperProfileResponse>
    {
        private readonly IGrocerlyDbContext _dbContext;

        private readonly IIdGenerator _idGenerator;

        private readonly IClock _clock;

        public CreateShopper(IGrocerlyDbContext dbContext, IIdGenerator idGenerator, IClock clock)
        {
            _dbContext = dbContext;
            _idGenerator = idGenerator;
            _clock = clock;
        }

        public Task<ShopperProfileResponse> Handle(CreateShopperRequest request, CancellationToken cancellationToken)
        {
            var isUserExists = _dbContext.Shoppers.Where(shopper => shopper.Username.Equals(request.Username)).Any();
            if (isUserExists)
            {
                throw new DuplicateUsernameException();
            }

            var id = _idGenerator.CreateId();
            var wishListId = _idGenerator.CreateId();
            var createdDateTime = _clock.UtcNow;
            var newShopper = new Shopper(id, request.Username, wishListId);
            _dbContext.Shoppers.Add(newShopper);

            var wishList = new WishList(wishListId, id);
            _dbContext.WishLists.Add(wishList);

            _dbContext.SaveChanges();

            var shopperProfile = new ShopperProfileResponse();
            shopperProfile.Username = request.Username;
            shopperProfile.WishList = wishList;
            shopperProfile.ShoppingLists = new List<KeyValuePair<long, string>>();

            return Task.FromResult(shopperProfile);
        }
    }
}
