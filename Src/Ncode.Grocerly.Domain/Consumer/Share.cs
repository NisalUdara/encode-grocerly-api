using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Domain
{
    public class Share
    {
        public Share(long shopperId, long shoppingListId)
        {
            if (shopperId < 1 )
            {
                throw new ArgumentException("Consumer id needs to be valid.");
            }
            if (shoppingListId < 1)
            {
                throw new ArgumentException("Shopping list id needs to be valid.");
            }

            ShopperId = shopperId;
            ShoppingListId = shoppingListId;
        }
        public long ShopperId { get; private set; }
        public long ShoppingListId { get; private set; }
    }
}
