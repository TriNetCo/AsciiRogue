namespace AsciiRogue
{
    public class Game
    {
        public Character Character;

        private GameMap map;

        public Game() 
        {
            map = new GameMap();
            Character = map.Character;
        }

        public Game(string mapString) 
        {
            map =  new GameMap(mapString);
            Character = map.Character;
        }

        public string printMap() {
            return map.ToString();
        }
    }
}