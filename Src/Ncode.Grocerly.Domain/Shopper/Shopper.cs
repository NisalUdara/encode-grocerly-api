using Ncode.Grocerly.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Domain
{
    public class Shopper: Identity
    {
        public Shopper(long id, string username, long wishListId)
        {
            Id = id;
            Username = username;
            WishListId = wishListId;
            SharedShoppingLists = new List<Share>();
        }

        public Shopper(
            int shopperId, 
            string username, 
            List<Share> shares)
        {
            Id = shopperId;
            Username = username;
            SharedShoppingLists = shares;
        }

        public string Username { get; private set; }
        public long WishListId { get; private set; }
        public List<Share> SharedShoppingLists { get; private set; }

        public void Share(long shopperId, long shoppingListId)
        {
            var share = new Share(shopperId, shoppingListId);
            SharedShoppingLists.Add(share);
        }
    }
}
