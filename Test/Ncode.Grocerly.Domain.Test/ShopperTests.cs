using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ncode.Grocerly.Domain.Test
{
    public class ShopperTests
    {
        [Fact]
        public void TestShopper()
        {
            int shopperId = 1;
            string shopperUsername = "Sarath";
            int shopperWishlistId = 1;
            int errandShopperId = 2;

            var shopper = new Shopper(shopperId, shopperUsername, DateTime.UtcNow);
            shopper.Id.Should().Equals(shopperId);
            shopper.Username.Should().Equals(shopperUsername);
            shopper.WishListId.Should().Equals(shopperWishlistId);
            shopper.ShoppingLists.Count.Equals(0);
            shopper.SharedShoppingLists.Count.Equals(0);

            shopper.AddShoppingList(1);
            shopper.ShoppingLists.Count.Equals(1);
            shopper.AddShoppingList(2);
            shopper.ShoppingLists.Count.Equals(2);
            shopper.RemoveShoppingList(2);
            shopper.ShoppingLists.Count.Equals(1);

            shopper.Share(1, errandShopperId);
            shopper.SharedShoppingLists.Count.Equals(1);
        }
    }
}
