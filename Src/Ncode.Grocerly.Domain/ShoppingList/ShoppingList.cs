﻿using Ncode.Grocerly.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncode.Grocerly.Domain
{
    public class ShoppingList
    {
        public ShoppingList(Name name, DateTime createDatetime)
        {
            Name = name;
            Items = new List<ShoppingListItem>();
            CreatedDateTime = createDatetime;
        }

        public Name Name { get; private set; }

        public bool IsCompleted { get; private set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime FinishedDateTime { get; set; }

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
                return Items.Where(item => item.IsPicked).Count() == Items.Count() ;
            }                
        }

        public IList<ShoppingListItem> Items { get; private set; }

        public void AddItem(Name name, UnitOfMeasure unitOfMeasure, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Product name has to  be non empty.");
            }
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