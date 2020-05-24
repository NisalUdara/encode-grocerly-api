using Ncode.Grocerly.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Domain
{
    public class Consumer: Identity
    {
        public Consumer()
        {
            SharedShoppingListsByConsumer = new List<Share>();
        }
        public Name Name { get; set; }
        public int WishListId { get; set; }
        public List<int> ShoppingListIds { get;internal set; }
        public List<Share> SharedShoppingListsByConsumer { get; internal set; }

        public void Share(int consumerId, int shoppingListId)
        {
            var share = new Share(consumerId, shoppingListId);
            SharedShoppingListsByConsumer.Add(share);
        }
    }
}
