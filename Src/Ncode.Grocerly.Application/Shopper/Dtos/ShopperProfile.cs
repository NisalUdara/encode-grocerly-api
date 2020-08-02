using Ncode.Grocerly.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Application.Shopper.Dtos
{
    public class ShopperProfile
    {
        public string Username { get; set; }
        public Dictionary<long, string> OwnedShoppingLists { get; set; }
        public Dictionary<long, string> SharedShoppingLists { get; set; }
    }
}
