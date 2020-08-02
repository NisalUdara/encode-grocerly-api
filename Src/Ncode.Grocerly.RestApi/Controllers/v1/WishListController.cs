using Microsoft.AspNetCore.Mvc;
using Ncode.Grocerly.Domain;
using System;

namespace Ncode.Grocerly.RestApi.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        [HttpGet]
        public WishList Get()
        {
            throw new NotImplementedException();
        }

        [Route("{wishListId}/items")]
        [HttpPost]
        public WishList Post(int wishListId,[FromBody]string wishListDetails)
        {
            throw new NotImplementedException();
        }

        [Route("{wishListId}/items/{id}")]
        [HttpDelete]
        public WishList Delete(int wishListId, int id)
        {
            throw new NotImplementedException();
        }
    }
}
