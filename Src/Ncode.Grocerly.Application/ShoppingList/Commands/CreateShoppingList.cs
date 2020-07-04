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
        private readonly IUnitOfWork _unitOfWork;

        private readonly IIdGenerator _idGenerator;

        private readonly IClock _clock;

        public CreateShoppingList(IUnitOfWork unitOfWork, IIdGenerator idGenerator, IClock clock)
        {
            _unitOfWork = unitOfWork;
            _idGenerator = idGenerator;
            _clock = clock;
        }

        public void Handle((string username, string shoppingListName) parameters)
        {
            var owner = _unitOfWork.Shoppers.Get(shopper => shopper.Username.Equals(parameters.username)).FirstOrDefault();
            if (owner is null)
            {
                throw new UnregisteredShopperException();
            }

            var id = _idGenerator.CreateId();
            var createdDateTime = _clock.UtcNow;
            var shoppingList = new ShoppingList(owner.Id, (Name)parameters.shoppingListName, createdDateTime);

            _unitOfWork.ShoppingLists.Add(shoppingList);
            _unitOfWork.Save();
        }
    }
}
