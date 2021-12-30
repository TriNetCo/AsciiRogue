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



    }
}
