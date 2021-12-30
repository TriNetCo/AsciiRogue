using System;
using System.Collections.Generic;

namespace AsciiRogue.menu
{
    public class StartScreen : ConsoleMap
    {
        public Character Character;
        
        public StartScreen() {
            lines = FileUtils.readMenuFromResources("start_screen");
            Character = new Character(this, "*", new char[] { '-' });
        }

        public StartScreen(string map) {
            lines = map.Split("\n");
            Character = new Character(this, "*", new char[] { '-' });
        }

        public StartScreen(Dictionary<string,string> config) {
            if (config["mapName"] != null) {
                lines = FileUtils.readMenuFromResources(config["mapName"]);
            } else if (config["mapData"] != null) {
                lines = config["mapData"].Split("\n");
            }

            Character = new Character(this, "*", new char[] { '-' });
        }

        public string GetCurrentButton() {
            var cursorPoint = GetCharacterPosition('*');

            string line = lines[getActualY(cursorPoint.y)];

            return line.Replace('#', ' ').Replace('*', ' ').Trim().ToLower().Replace(' ', '_');
        }

    }
}