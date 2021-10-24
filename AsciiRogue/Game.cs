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

        public Game(string mapString) 
        {
            this.map =  new GameMap(mapString);
            this.character = new Character(map);
        }

        public string printMap() {
            return map.printMap();
        }
    }
}