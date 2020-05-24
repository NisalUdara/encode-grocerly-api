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

        }
        public Name Name { get; set; }
        public int WishListId { get; set; }
        public List<int> ShoppingListIds { get;internal set; }
        public List<Share> Sharings { get; internal set; }

        public void Share(int ConsumerId, int shoppingListId)
        { 
        
        }
    }
}
