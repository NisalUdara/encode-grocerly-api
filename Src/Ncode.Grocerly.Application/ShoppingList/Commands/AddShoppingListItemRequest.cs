using MediatR;
using Ncode.Grocerly.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Application.Commands
{
    public class AddShoppingListItemRequest : IRequest<Unit>
    {
        public string Username { get; set; }
        public long ShoppingListId { get; set; }
        public ShoppingListItem Item { get; set; }
    }
}
