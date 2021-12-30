using System;
using Xunit;
using TestExtensions;
using AsciiRogue.menu;

namespace AsciiRogue.Tests
{
    public class StartScreenTests
    {
        private StartScreen startScreen;
    
        public StartScreenTests()
        {
            startScreen = new StartScreen();
        }
    
        [Fact]
        public void the_start_screen_shows_up()
        {
            // setup
            string expectedScreen = 
                    @"#######################
                      #     Ascii Rogue     #
                      #######################
                      #                     #
                      #    * New Game       #
                      #    - Continue       #
                      #    - Multiplayer    #
                      #                     #
                      #######################".TrimIndentation();
            
            // excersise code
            string screen = startScreen.ToString();
    
            // assertions
            Assert.Equal<object>(expectedScreen, screen);
        }

        [Fact]
        public void we_can_get_the_button_name_selected()
        {
            // setup
            string expectedButtonName = "new_game";
            
            // excersise code
            string buttonName = startScreen.GetCurrentButton();
    
            // assertions
            Assert.Equal<object>(expectedButtonName, buttonName);
        }

        [Fact]
        public void we_can_move_the_cursor()
        {
            // setup
            string expectedScreen = 
                    @"#######################
                      #     Ascii Rogue     #
                      #######################
                      #                     #
                      #    - New Game       #
                      #    * Continue       #
                      #    - Multiplayer    #
                      #                     #
                      #######################".TrimIndentation();
            
            // excersise code
            startScreen.Character.MoveDown();
    
            // assertions
            Assert.Equal<object>(expectedScreen, startScreen.ToString());
        }

        [Fact]
        public void we_dont_get_an_index_out_of_bounds_error_when_we_move_below_the_last_button()
        {
            // setup
            string expectedScreen = 
                    @"#######################
                      #     Ascii Rogue     #
                      #######################
                      #                     #
                      #    - New Game       #
                      #    - Continue       #
                      #    * Multiplayer    #
                      #                     #
                      #######################".TrimIndentation();

            startScreen.Character.MoveDown();
            startScreen.Character.MoveDown();
            startScreen.Character.MoveDown();


            Assert.Equal<object>(expectedScreen, startScreen.ToString());
        }


        [Fact]
        public void we_can_render_the_multiplayer_screen()
        {
            // setup

            StartScreen multiplayerScreen = new StartScreen();

            string expectedScreen = 
                    @"#########################
                      #       Join Game       #
                      #########################
                      #                       #
                      #  * Join Game          #
                      #  - Host Private Game  #
                      #  - Host Public Game   #
                      #  - List Public Games  #
                      #                       #
                      #########################".TrimIndentation();


            String button;
            Vector2Int pos;
            button = startScreen.GetCurrentButton();
            pos = startScreen.GetCharacterPosition('*');

            // excersise code
            startScreen.Character.MoveDown();

            pos = startScreen.GetCharacterPosition('*');
            button = startScreen.GetCurrentButton();

            startScreen.Character.MoveDown();

            pos = startScreen.GetCharacterPosition('*');
            button = startScreen.GetCurrentButton();

            // Uhh.... so to "navigate" to a new screen, you press the enter key
            // on the keyboard while the startScreen is waiting for input
            // That triggers the start screen to end it's input handler loop by
            // returning the button name to the calling function...
            // There's no calling function in this test so...

            // assertions
            Assert.Equal<object>("multiplayer", button);
        }

    }
}
