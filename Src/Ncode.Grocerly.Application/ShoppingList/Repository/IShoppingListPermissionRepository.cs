using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Application.Repository
{
    public interface IShoppingListPermissionRepository
    {
        bool ValidatePermission(long shoppingListId, string username);
    }
}
