using Ncode.Grocerly.Application.Common;
using Ncode.Grocerly.Application.Exceptions;
using Ncode.Grocerly.Common;
using Ncode.Grocerly.Domain;
using Ncode.Grocerly.Domain.Common;
using System.Linq;

namespace Ncode.Grocerly.Application.Commands
{
    public class CreateShoppingList : ICommand<(string username, string shoppingListName)>
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

        public void Handle((string username, string shoppingListName) parameters)
        {
            var owner = _dbContext.Shoppers.FirstOrDefault(shopper => shopper.Username.Equals(parameters.username));
            if (owner is null)
            {
                throw new UnregisteredShopperException();
            }

            var id = _idGenerator.CreateId();
            var createdDateTime = _clock.UtcNow;
            var shoppingList = new ShoppingList(id, owner.Id, (Name)parameters.shoppingListName, createdDateTime);

            _dbContext.ShoppingLists.Add(shoppingList);
            _dbContext.SaveChanges();
        }
    }
}
