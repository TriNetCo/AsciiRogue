using System;
using Xunit;
using TestExtensions;

namespace AsciiRogue.Tests
{
    public class FunctionalInventoryTests
    {

        private string startingMap;
        private Game game;

        public FunctionalInventoryTests()
        {
            game = new Game("@");
        }

        [Fact]
        public void when_no_items_are_owned_a_blank_inventory_is_displayed()
        {
            // setup
            string expectedInventory = 
                    @"IIIIIIIIIIIIIIIIII
                      I   INVENTORY    I
                      IIIIIIIIIIIIIIIIII
                      I                I
                      I                I
                      I                I
                      I                I
                      I                I
                      I                I
                      IIIIIIIIIIIIIIIIII".TrimIndentation();

            // excersise code
            string actualInventory = game.character.ShowInventory();

            // assertions
            Assert.Equal<object>(expectedInventory, actualInventory);
        }

        [Fact]
        public void when_an_item_is_given_it_is_reflected_in_the_inventory()
        {
            // setup
            string expectedInventory = 
                    @"IIIIIIIIIIIIIIIIII
                      I   INVENTORY    I
                      IIIIIIIIIIIIIIIIII
                      I                I
                      I - Sword        I
                      I                I
                      I                I
                      I                I
                      I                I
                      IIIIIIIIIIIIIIIIII".TrimIndentation();

            // excersise code
            game.character.GiveItem("sword");
            string actualInventory = game.character.ShowInventory();

            // assertions
            Assert.Equal<object>(expectedInventory, actualInventory);
        }
    }
}
