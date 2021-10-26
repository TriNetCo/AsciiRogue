using System;
using Xunit;
using TestExtensions;

namespace AsciiRogue.Tests
{
    public class MovementTests
    {

        private string startingMap;
        private Game game;

        public MovementTests()
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
            game.character.MoveLeft();

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
            game.character.MoveRight();

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
            game.character.MoveUp();

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
            game.character.MoveDown();

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
            g.character.MoveUp();

            string map = g.printMap();

            Console.WriteLine(map);

            // assertions
            Assert.Equal(expectedOutcomeMap, map);
        }
        
    }
}
