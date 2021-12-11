using System;
using System.Linq;

namespace AsciiRogue
{
    public class Character
    {
        public string symbol;
        private ConsoleMap map;
        private char[] traversableSymbols;

        public Inventory inventory;

        public Character(ConsoleMap map) {
            inventory = new Inventory();
            this.map = map;
            symbol = "@";
            this.traversableSymbols = new char[] { ' ' };
        }

        public Character(ConsoleMap map, string symbol, char[] traversableSymbols) {
            inventory = new Inventory();
            this.map = map;
            this.symbol = symbol;
            this.traversableSymbols = traversableSymbols;
        }

        public bool MoveByVector(Vector2Int vector) {
            bool moved = map.MoveByVector(vector, traversableSymbols, symbol);
            if (moved)
                return moved;
            
            map.InteractWithObject(vector);
            return false; // we didn't move, perhaps we interacted but who really cares...
        }

        public bool MoveLeft() {
            return MoveByVector(new Vector2Int(-1 , 0));
        }

        public bool MoveRight() { 
            return MoveByVector(new Vector2Int(1 , 0));
        }

        public bool MoveUp() { 
            return MoveByVector(new Vector2Int(0 , 1));
        }

        public bool MoveDown() { 
            return MoveByVector(new Vector2Int(0 , -1));
        }
        
        // clear the screen
        // render the inventory template
        // render the items in their appropriate slot
        public string ShowInventory() {
           
            Console.Clear();
            string[] inventoryLines = FileUtils.readMenuFromResources("inventory_screen");
            // inventoryLines[3] = "I  - hihihih     I";

            for (int i = 0; i < inventory.inventoryItems.Count; i++) {
                InventoryItem item = (InventoryItem) inventory.inventoryItems[i];

                inventoryLines[i+3] = "I  - " + item.Name.PadRight(12) + "I";
            }

            string invLinesJoined = String.Join("\n", inventoryLines);
            Console.WriteLine(invLinesJoined);

            return invLinesJoined;
        }

        public bool GiveItem(string itemName) {
            InventoryItem item = new InventoryItem(itemName);
            inventory.GiveItem(item);
            return true;
        }

    }
}