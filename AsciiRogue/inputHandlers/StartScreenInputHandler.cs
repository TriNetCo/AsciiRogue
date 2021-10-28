using System;
using AsciiRogue.menu;

namespace AsciiRogue.inputHandlers
{
    public class StartScreenInputHandler
    {

        StartScreen screen;

        public StartScreenInputHandler(StartScreen screen) {
            this.screen = screen;
        }
        
        public string Control() {
            Character cursor = screen.Character;
            
            while (true) {
                Console.Clear();
                Console.WriteLine(screen);

                ConsoleKeyInfo input;
                try 
                {
                    input = Console.ReadKey();
                }
                catch(System.InvalidOperationException) 
                {
                    Console.WriteLine("Something went wrong reading the CLI");
                    continue;
                }

                switch(input.Key) {
                    case ConsoleKey.UpArrow:
                        cursor.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        cursor.MoveDown();
                        break;
                    
                    case ConsoleKey.Q:
                        return "q";
                    case ConsoleKey.Spacebar:
                    case ConsoleKey.Enter:
                    case ConsoleKey.E:
                        return screen.GetCurrentButton();
                }
            }

        }
    }
}
