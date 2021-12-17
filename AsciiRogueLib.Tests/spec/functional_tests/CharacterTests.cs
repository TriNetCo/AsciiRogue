using System;
using Xunit;
using TestExtensions;

namespace AsciiRogue.Tests
{
    public class FunctionalCharacterTests
    {
        private string startingMap;
        private Game game;

        public FunctionalCharacterTests()
        {
            startingMap = 
                    @"xxxxxxxxxx
                      x    s   x
                      x xxxxxx x
                      x x8xxxx x
                      x x#x xx x
                      x    @   x
                      x xxx    x
                      x xxxx   x
                      x        x
                      xxxxxxxxxx".TrimIndentation();

            game = new Game(startingMap);
        }

        [Fact]
        public void when_we_move_the_character_left_the_map_updates_correctly()
        {
            // setup
            string expectedOutcomeMap = 
                    @"xxxxxxxxxx
                      x    s   x
                      x xxxxxx x
                      x x8xxxx x
                      x x#x xx x
                      x   @    x
                      x xxx    x
                      x xxxx   x
                      x        x
                      xxxxxxxxxx".TrimIndentation();

            // excersise code
            game.Character.MoveLeft();

            string map = game.printMap();

            // assertions
            Assert.Equal<object>(expectedOutcomeMap, map);
        }

        [Fact]
        public void when_we_move_the_character_right_the_map_updates_correctly()
        {
            // setup
            string expectedOutcomeMap = 
                    @"xxxxxxxxxx
                      x    s   x
                      x xxxxxx x
                      x x8xxxx x
                      x x#x xx x
                      x     @  x
                      x xxx    x
                      x xxxx   x
                      x        x
                      xxxxxxxxxx".TrimIndentation();

            // excersise code
            game.Character.MoveRight();

            string map = game.printMap();

            Console.WriteLine(map);

            // assertions
            Assert.Equal(expectedOutcomeMap, map);
        }


        [Fact]
        public void when_we_move_the_character_up_the_map_updates_correctly()
        {
            // setup
            string expectedOutcomeMap = 
                    @"xxxxxxxxxx
                      x    s   x
                      x xxxxxx x
                      x x8xxxx x
                      x x#x@xx x
                      x        x
                      x xxx    x
                      x xxxx   x
                      x        x
                      xxxxxxxxxx".TrimIndentation();

            // excersise code
            game.Character.MoveUp();

            string map = game.printMap();
            Console.WriteLine(map);

            // assertions
            Assert.Equal(expectedOutcomeMap, map);
        }

        
        [Fact]
        public void when_we_move_the_character_down_the_map_updates_correctly()
        {
            // setup
            string expectedOutcomeMap = 
                    @"xxxxxxxxxx
                      x    s   x
                      x xxxxxx x
                      x x8xxxx x
                      x x#x xx x
                      x        x
                      x xxx@   x
                      x xxxx   x
                      x        x
                      xxxxxxxxxx".TrimIndentation();

            // excersise code
            game.Character.MoveDown();

            string map = game.printMap();

            Console.WriteLine(map);

            // assertions
            Assert.Equal(expectedOutcomeMap, map);
        }

        [Fact]
        public void the_character_cannot_move_through_an_obstacle()
        {
            // setup
            string startingMap =
                    @"xxxxx
                      x @ x
                      xxxxx".TrimIndentation();

            string expectedOutcomeMap =
                    @"xxxxx
                      x @ x
                      xxxxx".TrimIndentation();

            Game g = new Game(startingMap);

            // excersise code
            g.Character.MoveUp();

            string map = g.printMap();

            Console.WriteLine(map);

            // assertions
            Assert.Equal(expectedOutcomeMap, map);
        }

        [Fact]
        public void when_the_character_touches_a_switch_the_gate_is_removed_and_the_switch_downcases()
        {
            // setup
            string startingMap =
                    @"xx8xx
                      x # x
                      xs@ x
                      xxxxx".TrimIndentation();

            string expectedOutcomeMap =
                    @"xx8xx
                      x   x
                      xS@ x
                      xxxxx".TrimIndentation();
            
            Game g = new Game(startingMap);


            // excersise code
            g.Character.MoveLeft();

            string map = g.printMap();

            // assertions
            Assert.Equal<object>(expectedOutcomeMap, map);
        }

        [Fact]
        public void when_gates_are_switched_off_they_exist_in_the_shadow_lines_map()
        {
            // setup
            string startingMap =
                    @"xx8xx
                      x # x
                      xs@ x
                      xxxxx".TrimIndentation();

            string expectedOutcomeMap =
                    @"xx8xx
                      x # x
                      x   x
                      xxxxx".TrimIndentation();
            
            Game g = new Game(startingMap);


            // excersise code
            g.Character.MoveLeft();

            string map = g.PrintShadowMap();

            // assertions
            Assert.Equal<object>(expectedOutcomeMap, map);
        }

        [Fact]
        public void when_the_character_touches_a_toggled_switch_the_switch_gets_small_again()
        {
            // setup
            string startingMap =
                    @"xx8xx
                      x   x
                      xS@ x
                      xxxxx".TrimIndentation();

            string startingShadowMap =    
                    @"xx xx
                      x # x
                      x   x
                      xxxxx".TrimIndentation();       

            string expectedOutcomeMap =
                    @"xx8xx
                      x # x
                      xs@ x
                      xxxxx".TrimIndentation();
            
            Game g = new Game(startingMap, startingShadowMap);

            // excersise code
            g.Character.MoveLeft();

            string map = g.printMap();

            // assertions
            Assert.Equal<object>(expectedOutcomeMap, map);
        }

        [Fact]
        public void when_the_character_travles_to_stairs_the_next_level_loads()
        {
            // setup
            string startingMap =
                    @"xx8xx
                      x   x
                      xs@ x
                      xxxxx".TrimIndentation();

            string expectedOutcomeMap =
                     @"xxxxxxxxxx
                       x        x
                       x xxxxxx x
                       x x@     x
                       x xxxxx  x
                       x        x
                       x     7  x
                       x        x
                       x    8   x
                       xxxxxxxxxx".TrimIndentation();
                       
            Game g = new Game(startingMap);

            // excersise code
            g.Character.MoveUp();
            g.Character.MoveUp();

            string map = g.printMap();
            Console.WriteLine(map);

            // assertions
            // Assert.Equal<object>(expectedOutcomeMap, map);

            Assert.Equal("level2", g.map.MapName);
            Assert.Equal<object>(expectedOutcomeMap, map);
        }
        
    }
}
