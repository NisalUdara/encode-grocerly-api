using MediatR;
using Microsoft.EntityFrameworkCore;
using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ncode.Grocerly.Application.Queries
{
    public class GetShoppingLists : IRequestHandler<GetShoppingListsRequest, IEnumerable<ShoppingList>>
    {
        private readonly IGrocerlyDbContext _dbContext;

        public GetShoppingLists(
            IGrocerlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<ShoppingList>> Handle(GetShoppingListsRequest request, CancellationToken cancellationToken)
        {
            var owner = _dbContext.Shoppers
                .FirstOrDefault(shopper => shopper.Username.Equals(request.Username));

            if (owner is null)
            {
                throw new UnauthorizedShopperException();
            }

            var shoppingLists = _dbContext.ShoppingLists
                .Include(s => s.Items)
                .Where(shoppingLists => shoppingLists.OwnerId == owner.Id)
                .ToList();

            return Task.FromResult(shoppingLists.AsEnumerable());
        }
    }
}
