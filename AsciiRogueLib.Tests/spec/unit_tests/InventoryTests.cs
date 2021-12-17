using Xunit;
using TestExtensions;

namespace AsciiRogue.Tests
{
    public class InventoryTests
    {
        private string startingMap;
        private Game game;
    
        public InventoryTests()
        {
        }

        [Fact]
        public void items_can_be_added_and_removed_from_the_inventory()
        {
            string itemName = "Sword";
            Inventory inventory = new Inventory();

            Assert.Equal<int>(inventory.Count(), 0);


            InventoryItem item = new InventoryItem(itemName);
            inventory.GiveItem(item);

            Assert.Equal<int>(inventory.Count(), 1);

            inventory.RemoveItem(itemName);

            Assert.Equal<int>(inventory.Count(), 0);
        }

        [Fact]
        public void it_renders_the_inventory_well()
        {
            string expectedIneventoryScreen = 
                    @"IIIIIIIIIIIIIIIIII
                      I   INVENTORY    I
                      IIIIIIIIIIIIIIIIII
                      I  - Sword       I
                      I                I
                      I                I
                      I                I
                      I                I
                      I                I
                      IIIIIIIIIIIIIIIIII".TrimIndentation();
            string itemName = "Sword";
            Inventory inventory = new Inventory();

            InventoryItem item = new InventoryItem(itemName);
            inventory.GiveItem(item);

            Assert.Equal<object>(inventory.ToString(), expectedIneventoryScreen);
        }


    
    }
}
