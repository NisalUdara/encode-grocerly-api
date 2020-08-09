using MediatR;
using Ncode.Grocerly.Application.Queries;

namespace Ncode.Grocerly.Application.Commands
{
    public class CreateShopperRequest : IRequest<ShopperProfileResponse>
    {
        public string Username { get; set; }
    }
}
