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

            var shopper = new Shopper(shopperId, shopperUsername, shopperWishlistId);
            shopper.Id.Should().Equals(shopperId);
            shopper.Username.Should().Equals(shopperUsername);
            shopper.WishListId.Should().Equals(shopperWishlistId);
        }
    }
}
