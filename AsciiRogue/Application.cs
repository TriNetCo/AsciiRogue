﻿using System;
using AsciiRogue;

namespace AsciiRogueCli
{
    class Application
    {
        static void Main(string[] args)
        {
            GameMap map = new GameMap(); 
            map.printMap();

            Game game = new Game();
            Character character = game.character;

            while (true) {
                map.printMap();

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
                    
                    case ConsoleKey.Q:
                        return;
                    case ConsoleKey.I:
                        return;
                }
            }




        }
    }
}
