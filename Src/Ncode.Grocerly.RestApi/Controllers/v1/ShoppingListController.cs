using Microsoft.AspNetCore.Mvc;
using Ncode.Grocerly.Domain;
using System;
using System.Collections.Generic;

namespace Ncode.Grocerly.RestApi.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<ShoppingList> Get(string username)
        {
            throw new NotImplementedException();
        }

        [Route("shared")]
        [HttpGet]
        public IEnumerable<ShoppingList> GetSharedLists(string username)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void CreateShoppingList([FromBody] ShoppingList shoppingList)
        {
            throw new NotImplementedException();
        }

        [Route("{shoppingListId}")]
        [HttpPost]
        public void AddListItem(int shoppingListId, [FromBody]ShoppingListItem item)
        {
            throw new NotImplementedException();
        }

        [Route("{shoppingListId}/item/{id}")]
        [HttpPut]
        public void PickListItem(int shoppingListId, int id)
        {
            throw new NotImplementedException();
        }

        [Route("{shoppingListId}/item/{id}")]
        [HttpDelete]
        public void DeleteListItem(int shoppingListId, int id)
        {
            throw new NotImplementedException();
        }
    }
}
