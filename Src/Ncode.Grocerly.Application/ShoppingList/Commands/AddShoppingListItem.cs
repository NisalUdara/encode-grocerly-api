using MediatR;
using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Domain.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ncode.Grocerly.Application.Commands
{
    public class AddShoppingListItem : IRequestHandler<AddShoppingListItemRequest, Unit>
    {
        private readonly IGrocerlyDbContext _dbContext;

        public AddShoppingListItem(
            IGrocerlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Unit> Handle(AddShoppingListItemRequest request, CancellationToken cancellationToken)
        {
            var shopper = _dbContext
                .Shoppers
                .FirstOrDefault(shopper => shopper.Username.Equals(request.Username));

            if (shopper is null)
            {
                throw new UnauthorizedShopperException();
            }

            var shoppingList = _dbContext
                .ShoppingLists
                .FirstOrDefault(shoppingList => shoppingList.Id == request.ShoppingListId && shoppingList.OwnerId == shopper.Id);
            if (shoppingList is null)
            {
                throw new MissingShoppingListException();
            }

            shoppingList.AddItem(request.Item.Name, request.Item.UnitOfMeasure, request.Item.Quantity);
            _dbContext.ShoppingLists.Update(shoppingList);
            _dbContext.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}
