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
            return moveByVector(new Vector2Int(-1 , 0));
        }

        public bool MoveRight() { 
            return moveByVector(new Vector2Int(1 , 0)); 
        }
        
        public bool MoveUp() { return false; }
        public bool MoveDown() { return false; }
        
        private bool moveByVector(Vector2Int vector) {
            Vector2Int pos = map.GetCharacterPosition('@');
            Vector2Int desiredPosition = pos + vector;

            if (map.Traversable(desiredPosition)) 
            {
                map.MoveMapEntity(pos, desiredPosition);
                return true;
            }       
            return false;
        }

    }
}