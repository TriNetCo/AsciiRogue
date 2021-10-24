using System;
using Xunit;
using AsciiRogue;

namespace AsciiRogue.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void when_we_move_the_character_left_the_map_updates_correctly()
        {
            // setup
            string expectedMap = "";

            Game game = new Game();

            // excersise code
            game.character.MoveLeft();

            string map = game.printMap();

            // assertions
            Assert.Equal(expectedMap, map);
        }
    }
}
