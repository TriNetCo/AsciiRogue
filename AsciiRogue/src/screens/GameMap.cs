namespace AsciiRogue
{
    public class GameMap : ConsoleMap
    {
        public Character Character;
        
        public GameMap() {
            this.Character = new Character(this);
            lines = FileUtils.readMapFromResources("level1");
            produceShadowLinesClone();
        }

        public GameMap(string map) {
            this.Character = new Character(this);
            lines = map.Split("\n");
            produceShadowLinesClone();
        }

        public GameMap(string map, string shadowMap) {
            this.Character = new Character(this);
            lines = map.Split("\n");
            shadowLines = shadowMap.Split("\n");
        }

    }
}
