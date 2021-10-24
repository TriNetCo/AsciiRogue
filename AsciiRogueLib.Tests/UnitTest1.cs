using System;
using Xunit;
using AsciiRogue;
using System.Linq;

namespace AsciiRogue.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void when_we_move_the_character_left_the_map_updates_correctly()
        {
            // setup
            var expectedOutcomeMap = String.Join("\n", 
                  @"xxxxxxxxxx
                    x    s   x
                    x xxxxxx x
                    x x8xxxx x
                    x x#xxxx x
                    x        x
                    x xxx    x
                    x xxxx   x
                    x@       x
                    xxxxxxxxxx"
                .Replace(Environment.NewLine, "\n")
                .Split("\n")
                .Select (el => el.Trim() )
                .ToList()
            );

            Game game = new Game();

            // excersise code
            game.character.MoveLeft();
            game.character.MoveLeft();
            game.character.MoveLeft();

            string map = game.printMap();
            Console.WriteLine(expectedOutcomeMap);

            // assertions
            Assert.Equal(expectedOutcomeMap, map);
        }
    }
}
