using Ncode.Grocerly.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Domain
{
    public class Shopper: Identity
    {
        public Shopper(long shopperId, string username)
        {
            Id = shopperId;
            Username = username;
            ShoppingLists = new List<int>();
            SharedShoppingLists = new List<Share>();
        }

        public Shopper(
            int shopperId, 
            string username, 
            List<int> shoppingLists,
            List<Share> shares)
        {
            Id = shopperId;
            Username = username;
            ShoppingLists = shoppingLists;
            SharedShoppingLists = shares;
        }

        public string Username { get; private set; }
        public int WishList { get; private set; }
        public List<int> ShoppingLists { get; private set; }
        public List<Share> SharedShoppingLists { get; private set; }

        public void Share(int shopperId, int shoppingListId)
        {
            var share = new Share(shopperId, shoppingListId);
            SharedShoppingLists.Add(share);
        }

        public void AddShoppingList(int shoppingListId)
        {
            ShoppingLists.Add(shoppingListId);
        }

        public void RemoveShoppingList(int shoppingListId)
        {
            ShoppingLists.Remove(shoppingListId);
        }
    }
}
