namespace AsciiRogue
{
    public class Character
    {
        private GameMap map;

        public Character(GameMap map) {
            this.map = map;
        }

        public bool MoveLeft()
        {
            Vector2Int pos = map.GetCharacterPosition('@');
            Vector2Int desiredPosition = pos + new Vector2Int(-1 , 0);

            if (map.Traversable(desiredPosition)) 
            {
                map.MoveMapEntity(pos, desiredPosition);
                return true;
            }       
            return false;
        }

        public bool MoveRight(){ return false; }
        public bool MoveUp(){ return false; }
        public bool MoveDown(){ return false; }

    }
}