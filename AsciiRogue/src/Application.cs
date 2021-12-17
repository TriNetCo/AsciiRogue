using AsciiRogue;
using AsciiRogue.menu;
using AsciiRogue.inputHandlers;
using System.Collections.Generic;

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
            Dictionary<string, string> config = new Dictionary<string, string>();
            config["mapName"] = "multiplayer_screen";
            StartScreen startScreen = new StartScreen(config);
            StartScreenInputHandler startScreenInputHandler = new StartScreenInputHandler(startScreen);
            
            while (true)
            {
                string command = startScreenInputHandler.Control();

                if (command == "join_game")
                    startJoinGameMenu();
                if (command == "host_private_game")
                    startHostedMultiplayerGame();
                if (command == "q") return;
                
            }
        }



        static void startJoinGameMenu() {

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

        static void startHostedMultiplayerGame()
        {
            Game game = new Game();
            NetworkHandler networkHandler = new NetworkHandler(game);
            GameInputHandler gameInputHandler = new GameInputHandler(game);

            while (true) 
            {
                string command = gameInputHandler.Control();

                if (command == "q") return;
            }
        }

    }
}
