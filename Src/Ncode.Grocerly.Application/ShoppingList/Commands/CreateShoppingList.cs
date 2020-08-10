using MediatR;
using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Common;
using Ncode.Grocerly.Domain;
using Ncode.Grocerly.Domain.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ncode.Grocerly.Application.Commands
{
    public class CreateShoppingList : IRequestHandler<CreateShoppingListRequest, ShoppingList>
    {
        private readonly IGrocerlyDbContext _dbContext;

        private readonly IIdGenerator _idGenerator;

        private readonly IClock _clock;

        public CreateShoppingList(IGrocerlyDbContext dbContext, IIdGenerator idGenerator, IClock clock)
        {
            _dbContext = dbContext;
            _idGenerator = idGenerator;
            _clock = clock;
        }

        public Task<ShoppingList> Handle(CreateShoppingListRequest request, CancellationToken cancellationToken)
        {
            var owner = _dbContext.Shoppers.FirstOrDefault(shopper => shopper.Username.Equals(request.Username));
            if (owner is null)
            {
                throw new UnregisteredShopperException();
            }

            var id = _idGenerator.CreateId();
            var createdDateTime = _clock.UtcNow;
            var shoppingList = new ShoppingList(id, owner.Id, (Name)request.ShoppingListName, createdDateTime);

            _dbContext.ShoppingLists.Add(shoppingList);
            _dbContext.SaveChanges();

            return Task.FromResult(shoppingList);
        }
    }
}
