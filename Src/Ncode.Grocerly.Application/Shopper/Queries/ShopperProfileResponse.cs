using Ncode.Grocerly.Domain;
using System.Collections.Generic;

namespace Ncode.Grocerly.Application.Queries
{
    public class ShopperProfileResponse
    {
        public string Username { get; set; }
        public Dictionary<long, string> OwnedShoppingLists { get; set; }
        public Dictionary<long, string> SharedShoppingLists { get; set; }
        public WishList WishList { get; set; }
    }
}
