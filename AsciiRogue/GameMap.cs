using System;
using System.IO;
using System.Collections;

namespace AsciiRogue
{
    public class GameMap : ConsoleMap
    {
        public Character Character;
        
        public GameMap() {
            this.Character = new Character(this);
            lines = FileUtils.readMapFromResources("level1");
        }

        public GameMap(string map) {
            this.Character = new Character(this);
            lines = map.Split("\n");
        }

    }
}
