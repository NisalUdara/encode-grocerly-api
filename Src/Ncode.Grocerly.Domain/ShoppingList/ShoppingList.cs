using Ncode.Grocerly.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncode.Grocerly.Domain
{
    public class ShoppingList : Identity
    {
        public ShoppingList(int ownerId, Name name, DateTime createDatetime)
        {
            OwnerId = ownerId;
            Name = name;
            Items = new List<ShoppingListItem>();
            CreatedDateTime = createDatetime;
        }

        public ShoppingList(int ownerId, ShoppingList shoppingList, DateTime createDatetime)
            : this(ownerId, shoppingList.Name, createDatetime)
        {
            var unPickedItems = shoppingList.Items
                .Where(item => !item.IsPicked).ToList();

            foreach (var item in unPickedItems)
            {
                shoppingList.Items.Remove(item);
            }
        }

        public int OwnerId { get; private set; }

        public Name Name { get; private set; }

        public bool IsCompleted { get; private set; }

        public DateTime CreatedDateTime { get; private set; }

        public DateTime FinishedDateTime { get; private set; }

        public bool IsEmpty
        {
            get
            {
                return Items.Count() == 0;
            }
        }

        public bool HasAllItemsPicked
        {
            get
            {
                return Items.Where(item => item.IsPicked).Count() == Items.Count() && !IsEmpty;
            }
        }

        public IList<ShoppingListItem> Items { get; private set; }

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
