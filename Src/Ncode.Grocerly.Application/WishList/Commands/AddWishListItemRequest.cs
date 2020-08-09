using MediatR;
using Ncode.Grocerly.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Application.Commands
{
    public class AddWishListItemRequest : IRequest<Unit>
    {
        public long WishListId { get; set; }

        public string Username { get; set; }
        public WishListItem Item { get; set; }
    }
}
