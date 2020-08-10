using MediatR;
using Ncode.Grocerly.Domain;
using System.Collections.Generic;

namespace Ncode.Grocerly.Application.Queries
{
    public class GetShoppingListsRequest : IRequest<IEnumerable<ShoppingList>>
    {
        public string Username { get; set; }
    }
}
