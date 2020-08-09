using MediatR;
using Ncode.Grocerly.Domain.Common;

namespace Ncode.Grocerly.Application.Commands
{
    public class RemoveWishListItemRequest : IRequest<Unit>
    {
        public long WishListId { get; set; }

        public string Username { get; set; }

        public Name ItemName { get; set; }
    }
}
