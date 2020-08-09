using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ncode.Grocerly.Application.Commands;
using Ncode.Grocerly.Application.Queries;
using Ncode.Grocerly.RestApi.Authentication;
using System;
using System.Threading.Tasks;

namespace Ncode.Grocerly.RestApi.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShopperController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShopperController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new ShopperProfileRequest() { Username = User.GetUsername() });
            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var response = await _mediator.Send(new CreateShopperRequest() { Username = User.GetUsername() });
            return Created("", response);
        }

        [Route("{shoppingListId}/share")]
        [HttpPost]
        public void Share(string username)
        {
            throw new NotImplementedException();
        }
    }
}
