using Ncode.Grocerly.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Domain
{
    public class WishListItem
    {
        public WishListItem(Name name, UnitOfMeasure unitOfMeasure, int quantity)
        {
            Name = name;
            UnitOfMeasure = unitOfMeasure;
            Quantity = quantity;
        }

        public Name Name { get; private set; }

        public UnitOfMeasure UnitOfMeasure { get; private set; }

        public int Quantity { get; private set; }
    }
}
