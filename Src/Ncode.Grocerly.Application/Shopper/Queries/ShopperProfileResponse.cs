using Ncode.Grocerly.Domain;
using System.Collections.Generic;

namespace Ncode.Grocerly.Application.Queries
{
    public class ShopperProfileResponse
    {
        public string Username { get; set; }
        public IList<KeyValuePair<long, string>> ShoppingLists { get; set; }
        public WishList WishList { get; set; }
    }
}
