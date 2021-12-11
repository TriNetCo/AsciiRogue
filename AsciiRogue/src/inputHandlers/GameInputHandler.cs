using System;

namespace AsciiRogue.inputHandlers
{
    public class GameInputHandler
    {

        Game game;

        public GameInputHandler(Game game) {
            this.game = game;
        }
        
        public string Control() {
            Character character = game.Character;
            while (true) {
                string flatMap = game.printMap();
                Console.Clear();
                Console.WriteLine(flatMap);

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
                    case ConsoleKey.LeftArrow:
                        character.MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        character.MoveRight();
                        break;
                    case ConsoleKey.UpArrow:
                        character.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        character.MoveDown();
                        break;

                    case ConsoleKey.I:
                        character.ShowInventory();
                        ConsoleKeyInfo info = Console.ReadKey();
                        break;
                    
                    case ConsoleKey.Q:
                        return "q";
                    case ConsoleKey.M:
                        return "m";
                }
            }

        }
    }
}