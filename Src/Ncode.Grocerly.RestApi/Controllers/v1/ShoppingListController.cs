using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ncode.Grocerly.Application.Commands;
using Ncode.Grocerly.Application.Queries;
using Ncode.Grocerly.Domain;
using Ncode.Grocerly.RestApi.Authentication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ncode.Grocerly.RestApi.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private IMediator _mediator;

        public ShoppingListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetShoppingListsRequest() { Username = User.GetUsername() });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShoppingList([FromBody] string shoppingListName)
        {
            var response = await _mediator.Send(new CreateShoppingListRequest() { Username = User.GetUsername(), ShoppingListName = shoppingListName });
            return Created("", response);
        }

        [Route("{shoppingListId}")]
        [HttpPost]
        public async Task<IActionResult> AddListItem(long shoppingListId, [FromBody]ShoppingListItem item)
        {
            var response = await _mediator.Send(new AddShoppingListItemRequest() { Username = User.GetUsername(), ShoppingListId = shoppingListId, Item = item });
            return Created("", item);
        }

        [Route("{shoppingListId}/item/{name}")]
        [HttpPut]
        public async Task<IActionResult> PickListItem(long shoppingListId, string name)
        {
            var response = await _mediator.Send(new PickShoppingListItemRequest() { Username = User.GetUsername(), ShoppingListId = shoppingListId, Name = name });
            return Ok();
        }

        [Route("{shoppingListId}/item/{name}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteListItem(long shoppingListId, string name)
        {
            var response = await _mediator.Send(new RemoveShoppingListItemRequest() { Username = User.GetUsername(), ShoppingListId = shoppingListId, Name = name });
            return NoContent();
        }
    }
}
