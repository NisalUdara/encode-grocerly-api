using Ncode.Grocerly.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncode.Grocerly.Domain
{
    public class WishList: Identity
    {
        public WishList()
        {
            Items = new List<WishListItem>();
        }

        public IList<WishListItem> Items { get; private set; }

        public void AddItem(Name name, UnitOfMeasure unitOfMeasure, int quantity)
        {
            if (quantity < 1)
            {
                throw new ArgumentException("Quantity has to be greater than zero.");
            }

            Items.Add(new WishListItem(name, unitOfMeasure, quantity));
        }

        public void RemoveItem(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Product name has to  be non empty.");
            }

            var itemToRemove = Items.FirstOrDefault(item => item.Name.Equals(name));
            if (itemToRemove is null)
            {
                throw new ArgumentException("Product not found.");
            }

            Items.Remove(itemToRemove);
        }
    }
}
