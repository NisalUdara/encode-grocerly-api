using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ShopperProfileResponse> Get()
        {
            var response = await _mediator.Send(new ShopperProfileRequest() { Username = User.GetUsername() });
            return response;
        }

        [Authorize]
        [HttpPost]
        public void Post()
        {
            var user = User;
            throw new NotImplementedException();
        }

        [Route("{shoppingListId}/share")]
        [HttpPost]
        public void Share(string username)
        {
            throw new NotImplementedException();
        }
    }
}
