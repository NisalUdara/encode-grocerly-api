using MediatR;

namespace Ncode.Grocerly.Application.Commands
{
    public class RemoveShoppingListItemRequest : IRequest<Unit>
    {
        public string Username { get; set; }
        public long ShoppingListId { get; set; }
        public string Name { get; set; }
    }
}
