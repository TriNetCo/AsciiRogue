namespace AsciiRogue
{
    public class Game
    {
        public Character character;
         
        private GameMap map;

        public Game() 
        {
            this.map = new GameMap();
            this.character = new Character(map);
        }
    }
}