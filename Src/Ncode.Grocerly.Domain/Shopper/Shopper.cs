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
        }

        public string Username { get; private set; }
        public long WishListId { get; private set; }
    }
}
