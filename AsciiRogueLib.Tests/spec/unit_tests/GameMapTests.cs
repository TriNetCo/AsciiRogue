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
        }
    
        [Fact]
        public void we_have_an_ok_syntax_for_writing_to_the_map()
        {
            // setup
            string startingMap =
                @"xxxxx
                  x @ x
                  xxxxx".TrimIndentation();
    
            string expectedOutcomeMap =
                @"xxxxx
                  x @ x
                  gxxxx".TrimIndentation();

            GameMap g = new GameMap(startingMap);
            Vector2Int point = new Vector2Int(0,0);

            // excersise code
            g.WriteSymbolToPoint("g", point);
    
            string map = g.ToString();
    
            // assertions
            Assert.Equal<object>(expectedOutcomeMap, map);
        }

        [Fact]
        public void we_have_a_great_syntax_for_writing_to_the_map()
        {
            // setup
            string startingMap =
                @"xxxxx
                  x @ x
                  xxxxx".TrimIndentation();
    
            string expectedOutcomeMap =
                @"xxxxx
                  x @ x
                  gxxxx".TrimIndentation();

            GameMap g = new GameMap(startingMap);

            // excersise code
            g[0,0] = "g";
            string map = g.ToString();

            Console.WriteLine(map);
    
            // assertions
            Assert.Equal<object>(expectedOutcomeMap, map);
        }

        [Fact]
        public void it_has_a_shadowmap_that_initializes_correctly()
        {
            // setup
            string startingMap =
                @"xxxxx
                  x#@sx
                  xxxxx".TrimIndentation();
    
            string expectedOutcomeMap =
                @"xxxxx
                  x   x
                  xxxxx".TrimIndentation();

            GameMap g = new GameMap(startingMap);

            string map = g.PrintShadowMap();

            Console.WriteLine(map);
    
            // assertions
            Assert.Equal<object>(expectedOutcomeMap, map);
        }

    }
}
