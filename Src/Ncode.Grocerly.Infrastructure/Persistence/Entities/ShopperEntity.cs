using Ncode.Grocerly.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Infrastructure.Persistence.Entities
{
    internal class ShopperEntity : BaseEntity
    {
        public string Username { get; set; }
        public int WishList { get; set; }
        public List<ShoppingListEntity> ShoppingLists { get; private set; }
        public List<Share> SharedShoppingLists { get; private set; }
    }
}
