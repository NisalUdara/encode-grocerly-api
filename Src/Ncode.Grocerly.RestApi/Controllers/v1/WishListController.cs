using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ncode.Grocerly.Application.Commands;
using Ncode.Grocerly.Domain;
using Ncode.Grocerly.Domain.Common;
using Ncode.Grocerly.RestApi.Authentication;
using System.Threading.Tasks;

namespace Ncode.Grocerly.RestApi.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private IMediator _mediator;

        public WishListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("{wishListId}/items")]
        [HttpPost]
        public async Task<IActionResult> Post(long wishListId,[FromBody]WishListItem item)
        {
            var response = await _mediator.Send(new AddWishListItemRequest() { Username = User.GetUsername(), WishListId = wishListId, Item = item });
            return Created($"{wishListId}/items", item);
        }

        [Route("{wishListId}/items/{name}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(long wishListId,[FromRoute]string name)
        {
            var response = await _mediator.Send(new RemoveWishListItemRequest() { Username = User.GetUsername(), WishListId = wishListId, ItemName = name });
            return NoContent();
        }
    }
}
