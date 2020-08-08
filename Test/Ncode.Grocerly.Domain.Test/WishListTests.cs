using FluentAssertions;
using Ncode.Grocerly.Domain.Common;
using System;
using Xunit;

namespace Ncode.Grocerly.Domain.Test
{
    public class WishListTests
    {
        [Fact]
        public void TestWishList()
        {
            int testOwnerId = 1;
            var wishList = new WishList(1, testOwnerId);
            wishList.Items.Count.Should().Equals(0);

            wishList.AddItem((Name)"Milk", UnitOfMeasure.Bottle, 2);
            wishList.AddItem((Name)"Bread", UnitOfMeasure.Nos, 1);
            wishList.AddItem((Name)"Sugar", UnitOfMeasure.Gram, 500);
            wishList.Items.Count.Should().Equals(3);

            wishList.RemoveItem((Name)"Milk");
            wishList.Items.Count.Should().Equals(2);

            var shoppingList = new ShoppingList(1, testOwnerId, (Name)"Shopping List 1", DateTime.UtcNow);
            wishList.MoveItem((Name)"Bread", shoppingList);
            wishList.Items.Count.Should().Equals(1);
            shoppingList.Items.Count.Should().Equals(1);
        }
    }
}
