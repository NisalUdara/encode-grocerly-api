using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Domain
{
    public class Share
    {
        public Share(long consumerId, long shoppingListId)
        {
            if (consumerId < 1 )
            {
                throw new ArgumentException("Consumer id needs to be valid.");
            }
            if (shoppingListId < 1)
            {
                throw new ArgumentException("Shopping list id needs to be valid.");
            }

            ConsumerId = consumerId;
            ShoppingListId = shoppingListId;
        }
        public long ConsumerId { get; private set; }
        public long ShoppingListId { get; private set; }
    }
}
