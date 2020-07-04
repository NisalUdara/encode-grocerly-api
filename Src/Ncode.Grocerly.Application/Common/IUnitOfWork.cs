using Ncode.Grocerly.Application.Repository;
using Ncode.Grocerly.Domain;

namespace Ncode.Grocerly.Application.Common
{
    public interface IUnitOfWork
    {
        IRepository<Shopper> Shoppers { get; }
        IRepository<WishList> WishLists { get; }
        IRepository<ShoppingList> ShoppingLists { get; }
        void Save();
    }
}
