using System;

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

        public string GetCurrentButton() {
            var cursorPoint = GetCharacterPosition('*');

            string line = lines[cursorPoint.y];

            return line.Replace('#', ' ').Replace('*', ' ').Trim().ToLower().Replace(' ', '_');
        }

    }
}