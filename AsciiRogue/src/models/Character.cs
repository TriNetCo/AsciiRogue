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

        public bool MoveLeft() {
            bool moved = map.MoveByVector(new Vector2Int(-1 , 0), traversableSymbols, symbol);
            if (moved)
                return moved;
            
            map.InteractWithObject(new Vector2Int(-1 , 0));

            return false; // we didn't move, perhaps we interacted but who cares...
        }

        public bool MoveRight() { 
            return map.MoveByVector(new Vector2Int(1 , 0), traversableSymbols, symbol); 
        }

        public bool MoveUp() { 
            return map.MoveByVector(new Vector2Int(0 , 1), traversableSymbols, symbol);
        }

        public bool MoveDown() { 
            return map.MoveByVector(new Vector2Int(0 , -1), traversableSymbols, symbol); 
        }
        

        public string ShowInventory() {
            throw new NotImplementedException();
        }

        public bool GiveItem(string itemName) {
            throw new NotImplementedException();
        }

    }
}