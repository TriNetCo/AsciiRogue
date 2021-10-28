namespace AsciiRogue.menu
{
    public class Cursor
    {


        public bool MoveLeft()
        {
            return moveByVector(new Vector2Int(-1 , 0));
        }

        public bool MoveRight() { 
            return moveByVector(new Vector2Int(1 , 0)); 
        }

        public bool MoveUp() { 
            return moveByVector(new Vector2Int(0 , -1));
        }

        public bool MoveDown() { 
            return moveByVector(new Vector2Int(0 , 1)); 
        }

        public bool moveByVector(Vector2Int v)
        {
            return true;

        }
        
    }
}