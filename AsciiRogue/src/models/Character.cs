using System.Runtime;
using System;

namespace AsciiRogue
{
    public class Character
    {
        public string symbol;
        private ConsoleMap map;
        private char[] traversableSymbols;

        public Character(ConsoleMap map) {
            this.map = map;
            symbol = "@";
            this.traversableSymbols = new char[] { ' ' };
        }

        public Character(ConsoleMap map, string symbol, char[] traversableSymbols) {
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
        
        public string ShowInventory() {
            throw new NotImplementedException();
        }

        public bool GiveItem(string itemName) {
            throw new NotImplementedException();
        }

    }
}