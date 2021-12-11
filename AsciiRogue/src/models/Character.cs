using System;

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

            string inventoryResult = inventory.ToString();
            Console.WriteLine(inventoryResult);

            return inventoryResult;
        }

        public bool GiveItem(string itemName) {
            InventoryItem item = new InventoryItem(itemName);
            inventory.GiveItem(item);
            return true;
        }

    }
}