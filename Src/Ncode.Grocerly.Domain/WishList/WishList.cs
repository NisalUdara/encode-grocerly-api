using Ncode.Grocerly.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ncode.Grocerly.Domain
{
    public class WishList: Identity
    {
        public WishList(int ownerId)
        {
            OwnerId = ownerId;
            Items = new List<WishListItem>();
        }

        public IList<WishListItem> Items { get; private set; }

        public int OwnerId { get; private set; }

        public void AddItem(Name name, UnitOfMeasure unitOfMeasure, int quantity)
        {
            if (quantity < 1)
            {
                throw new ArgumentException("Quantity has to be greater than zero.");
            }

            Items.Add(new WishListItem(name, unitOfMeasure, quantity));
        }

        public void RemoveItem(Name name)
        {
            var itemToRemove = getItem(name);

            Items.Remove(itemToRemove);
        }

        public void MoveItem(Name name, ShoppingList shoppingList)
        {
            var itemToMove = getItem(name);
            shoppingList.AddItem(itemToMove.Name, itemToMove.UnitOfMeasure, itemToMove.Quantity);

            Items.Remove(itemToMove);
        }

        private WishListItem getItem(Name name)
        { 
            var item = Items.FirstOrDefault(item => item.Name.Equals(name));
            if (item is null)
            {
                throw new ArgumentException("Product not found.");
            }

            return item;
        }
    }
}
