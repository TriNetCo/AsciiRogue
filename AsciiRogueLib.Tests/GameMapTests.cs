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
    public void when_the_character_touches_a_switch_the_gate_is_removed_and_the_switch_downcases()
    {
      // setup
      string expectedOutcomeMap =
              @"xxxxxxxxxx
                      x        x
                      x x xxxx x
                      x x8xxxx x
                      x x x xx x
                      x s@     x
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
    public void when_the_character_travles_to_stairs_the_next_level_loads()
    {
      // setup
      string expectedOutcomeMap =
              @"xxxxxxxxxx
                      x        x
                      x x xxxx x
                      x x8xxxx x
                      x x x xx x
                      x s@     x
                      x xxx    x
                      x xxxx   x
                      x        x
                      xxxxxxxxxx".TrimIndentation();

      // excersise code
      game.character.MoveUp();
      game.character.MoveUp();

      string map = game.printMap();

      // assertions
      Assert.Equal<object>(expectedOutcomeMap, map);
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
