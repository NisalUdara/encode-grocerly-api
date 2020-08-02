using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ncode.Grocerly.Application.Shopper.Dtos;

namespace Ncode.Grocerly.RestApi.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShopperController : ControllerBase
    {

        [HttpGet]
        public ShopperProfile Get()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void Post(string username)
        {
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
