using Ncode.Grocerly.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Domain
{
    public class Shopper: Identity
    {
        public Shopper()
        {
            SharedShoppingListsByConsumer = new List<Share>();
        }
        public string Username { get; set; }
        public int WishList { get; set; }
        public List<int> ShoppingLists { get;internal set; }
        public List<Share> SharedShoppingListsByConsumer { get; internal set; }
        public void Share(int shopperId, int shoppingListId)
        {
            var share = new Share(shopperId, shoppingListId);
            SharedShoppingListsByConsumer.Add(share);
        }
    }
}
