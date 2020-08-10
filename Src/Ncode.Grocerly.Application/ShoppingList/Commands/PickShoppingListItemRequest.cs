using MediatR;

namespace Ncode.Grocerly.Application.Commands
{
    public class PickShoppingListItemRequest : IRequest<Unit>
    {
        public string Username { get; set; }
        public long ShoppingListId { get; set; }
        public string Name { get; set; }
    }
}
