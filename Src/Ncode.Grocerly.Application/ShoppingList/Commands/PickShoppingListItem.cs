using MediatR;
using Microsoft.EntityFrameworkCore;
using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Domain.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ncode.Grocerly.Application.Commands
{
    public class PickShoppingListItem : IRequestHandler<PickShoppingListItemRequest, Unit>
    {
        private readonly IGrocerlyDbContext _dbContext;

        public PickShoppingListItem(IGrocerlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Unit> Handle(PickShoppingListItemRequest request, CancellationToken cancellationToken)
        {
            var owner = _dbContext
                .Shoppers
                .FirstOrDefault(shopper => shopper.Username.Equals(request.Username));

            if (owner is null)
            {
                throw new UnauthorizedShopperException();
            }

            var shoppingList = _dbContext
                .ShoppingLists
                .Include(s => s.Items)
                .FirstOrDefault(shoppingList => shoppingList.Id == request.ShoppingListId && shoppingList.OwnerId == owner.Id);

            if (shoppingList is null)
            {
                throw new MissingShoppingListException();
            }

            shoppingList.PickItem((Name)request.Name);
            _dbContext.ShoppingLists.Update(shoppingList);
            _dbContext.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}
