namespace AsciiRogue
{
    public class Vector2Int
    {
        public int x;
        public int y;

        public Vector2Int(){
            x = 0;
            y = 0;
        }

        public Vector2Int(int x, int y){
            this.x = x;
            this.y = y;
        }

        public static Vector2Int operator +(Vector2Int vectorA, Vector2Int vectorB)
        {
            return new Vector2Int (
                vectorA.x + vectorB.x,
                vectorA.y + vectorB.y);
        }
    }
}