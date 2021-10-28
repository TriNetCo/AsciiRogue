using System;
using AsciiRogue;
using AsciiRogue.menu;
using AsciiRogue.inputHandlers;

namespace AsciiRogueCli
{
    class Application
    {
        static void Main(string[] args)
        {

            startTheStartScreen();

            // startSinglePlayerGame();

        }


        static void startTheStartScreen()
        {
            StartScreen startScreen = new StartScreen();
            StartScreenInputHandler startScreenInputHandler = new StartScreenInputHandler(startScreen);
            
            while (true) 
            {
                string command = startScreenInputHandler.Control();

                if (command == "new_game")
                    startSinglePlayerGame();
                if (command == "multiplayer")
                    startMultiplayerMenu();
                if (command == "q") return;
                
            }
        }

        static void startMultiplayerMenu()
        {
            return;
        }


        static void startSinglePlayerGame()
        {
            Game game = new Game();
            GameInputHandler gameInputHandler = new GameInputHandler(game);
            
            while (true) 
            {
                string command = gameInputHandler.Control();

                if (command == "q") return;
            }
        }

    }
}
