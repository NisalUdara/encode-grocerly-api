using FluentAssertions;
using Ncode.Grocerly.Domain.Common;
using System;
using Xunit;

namespace Ncode.Grocerly.Domain.Test
{
    public class ShoppingListTests
    {
        [Fact]
        public void TestShoppingList()
        {
            var testOwnerId = 1;
            var testDate = DateTime.Now;
            var finishDate = DateTime.Now;
            var shoppingListName = (Name)"Vegi List";

            var shoppingList = new ShoppingList(testOwnerId, shoppingListName, testDate);
            shoppingList.OwnerId.Should().Equals(testOwnerId);
            shoppingList.Name.Should().Equals(shoppingListName);
            shoppingList.CreatedDateTime.Should().Equals(testDate);
            shoppingList.IsCompleted.Should().Equals(false);
            shoppingList.IsEmpty.Should().Equals(true);
            shoppingList.HasAllItemsPicked.Should().Equals(false);
            shoppingList.IsCompleted.Should().Equals(false);

            Action finishEmptyList = () => shoppingList.FinishShopping(finishDate);
            finishEmptyList.Should().Throw<InvalidOperationException>().WithMessage("Shopping list is empty.");

            Action addZeroQuantity = () => shoppingList.AddItem((Name)"Carrot", UnitOfMeasure.Gram, 0);
            addZeroQuantity.Should().Throw<ArgumentException>().WithMessage("Quantity has to be greater than zero.");

            shoppingList.AddItem((Name)"Carrot", UnitOfMeasure.Gram, 500);
            shoppingList.AddItem((Name)"Potato", UnitOfMeasure.Kilogram, 1);
            shoppingList.IsEmpty.Should().Equals(false);
            shoppingList.HasAllItemsPicked.Should().Equals(false);
            shoppingList.Items.Count.Should().Equals(2);
            shoppingList.IsCompleted.Should().Equals(false);

            Action removeItemNotInList = () => shoppingList.RemoveItem((Name)"Onion");
            removeItemNotInList.Should().Throw<ArgumentException>().WithMessage("Product not found.");

            shoppingList.AddItem((Name)"Onion", UnitOfMeasure.Gram, 250);
            shoppingList.Items.Count.Should().Equals(3);

            shoppingList.RemoveItem((Name)"Carrot");
            shoppingList.Items.Count.Should().Equals(2);

            Action pickItemNotInList = () => shoppingList.PickItem((Name)"Beans");
            pickItemNotInList.Should().Throw<ArgumentException>().WithMessage("Product not found.");

            shoppingList.PickItem((Name)"Onion");
            shoppingList.HasAllItemsPicked.Should().Equals(false);

            Action finishListWithUnpickedItems = () => shoppingList.FinishShopping(finishDate);
            finishListWithUnpickedItems.Should().Throw<InvalidOperationException>().WithMessage("Shopping list has unpicked items.");

            shoppingList.PickItem((Name)"Potato");
            shoppingList.HasAllItemsPicked.Should().Equals(true);
            shoppingList.IsCompleted.Should().Equals(false);

            shoppingList.FinishShopping(finishDate);
            shoppingList.HasAllItemsPicked.Should().Equals(true);
            shoppingList.IsCompleted.Should().Equals(true);
            shoppingList.FinishedDateTime.Should().Equals(finishDate);
        }
    }
}
