using Ncode.Grocerly.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Application.Repository
{
    public interface IShoppingListSharesRepository
    {
        IEnumerable<ShoppingList> GetShareShoppingListsForShopper(string username);
    }
}
