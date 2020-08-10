using Ncode.Grocerly.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncode.Grocerly.Domain
{
    public class ShoppingList : Identity
    {
        public ShoppingList(long id, long ownerId, Name name, DateTime createdDateTime)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
            Items = new List<ShoppingListItem>();
            CreatedDateTime = createdDateTime;
            FinishedDateTime = DateTime.MaxValue;
        }

        public ShoppingList(long id, long ownerId, ShoppingList shoppingList, DateTime createdDateTime)
            : this(id, ownerId, shoppingList.Name, createdDateTime)
        {
            var unPickedItems = shoppingList.Items
                .Where(item => !item.IsPicked).ToList();

            foreach (var item in unPickedItems)
            {
                shoppingList.Items.Remove(item);
            }
        }

        public long OwnerId { get; private set; }

        public Name Name { get; private set; }

        public bool IsCompleted { get; private set; }

        public DateTime CreatedDateTime { get; private set; }

        public DateTime FinishedDateTime { get; private set; }

        public IList<ShoppingListItem> Items { get; private set; }

        public bool IsEmpty
        {
            get
            {
                return Items.Count() == 0;
            }
            private set { IsEmpty = value; }
        }

        public bool HasAllItemsPicked
        {
            get
            {
                return Items.Where(item => item.IsPicked).Count() == Items.Count() && !IsEmpty;
            }
        }

        public void AddItem(Name name, UnitOfMeasure unitOfMeasure, int quantity)
        {
            if (quantity < 1)
            {
                throw new ArgumentException("Quantity has to be greater than zero.");
            }
            if (IsCompleted)
            {
                throw new InvalidOperationException("Cannot Add items from closed shopping lists.");
            }

            Items.Add(new ShoppingListItem(name, unitOfMeasure, quantity));
        }

        public void RemoveItem(Name name)
        {
            var itemToRemove = Items.FirstOrDefault(item => item.Name.Equals(name));
            if (itemToRemove is null)
            {
                throw new ArgumentException("Product not found.");
            }

            Items.Remove(itemToRemove);
        }

        public void PickItem(Name name)
        {
            var itemToPick = Items.FirstOrDefault(item => item.Name.Equals(name));
            if (itemToPick is null)
            {
                throw new ArgumentException("Product not found.");
            }

            itemToPick.Pick();
        }

        public void FinishShopping(DateTime finishedDateTime)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Shopping list is empty.");
            }
            else if (HasAllItemsPicked)
            {
                FinishedDateTime = finishedDateTime;
                IsCompleted = true;
            }
            else
            {
                throw new InvalidOperationException("Shopping list has unpicked items.");
            }
        }
    }
}
