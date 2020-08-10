using MediatR;
using Ncode.Grocerly.Domain;

namespace Ncode.Grocerly.Application.Commands
{
    public class CreateShoppingListRequest : IRequest<ShoppingList>
    {
        public string Username { get; set; }
        public string ShoppingListName { get; set; }        
    }
}
