using System;
using Xunit;
using TestExtensions;

namespace AsciiRogue.Tests
{
    public class GameMapTests
    {
        private string startingMap;
        private Game game;
    
        public GameMapTests()
        {
            startingMap =
                  @"xxxxxxxxxx
                    x        x
                    x x#xxxx x
                    x x8xxxx x
                    x x x xx x
                    x S@     x
                    x xxx    x
                    x xxxx   x
                    x        x
                    xxxxxxxxxx".TrimIndentation();
    
            game = new Game(startingMap);
        }
    
        [Fact]
        public void we_have_a_good_syntax_for_writing_to_the_map()
        {
            // setup
            string startingMap =
                @"xxxxx
                  x   x
                  x @ x
                  x   x
                  xxxxx".TrimIndentation();
    
            string expectedOutcomeMap =
                @"xxxxx
                  x @ x
                  x   x
                  x   x
                  xxxxx".TrimIndentation();
    
    
            // excersise code
            Game g = new Game(startingMap);
    
            string map = g.printMap();
    
            // assertions
            Assert.Equal<object>(expectedOutcomeMap, map);
        }
    }
}
