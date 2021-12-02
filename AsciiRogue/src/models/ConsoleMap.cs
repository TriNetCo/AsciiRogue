using System;

namespace AsciiRogue
{
    public class ConsoleMap
    {
        protected string[] lines;

        public void LoadMap(string mapName)
        {
            lines = FileUtils.readMapFromResources(mapName);
        }

        public override string ToString()
        {
            return String.Join("\n", lines);
        }

        public void WriteSymbolToPoint(string symbol, Vector2Int point) 
        {
            int y = getActualY(point.y);

            lines[y] = lines[y].Remove(point.x, 1);
            lines[y] = lines[y].Insert(point.x, symbol);
        }

        public bool Traversable(Vector2Int position, char[] traversableSymbols) {
            char destinationSymbol = getCharacterAtPoint(position)[0];

            foreach (char traversableSymbol in traversableSymbols) 
                if (traversableSymbol == destinationSymbol)
                    return true;
            return false;
        }

        /// <summary>Moves the Map Entity at origin to the destination
        /// </summary>
        public void MoveMapEntity(Vector2Int origin, Vector2Int destination)
        {
            string originMapEntity = getCharacterAtPoint(origin);
            string destMapEntity = getCharacterAtPoint(destination);
            WriteSymbolToPoint(originMapEntity, destination);
            WriteSymbolToPoint(destMapEntity, origin);
        }

        public bool MoveByVector(Vector2Int vector, char[] traversableSymbols, string symbolMoving) {
            Vector2Int pos = GetCharacterPosition(symbolMoving[0]);
            Vector2Int desiredPosition = pos + vector;

            if (Traversable(desiredPosition, traversableSymbols)) 
            {
                MoveMapEntity(pos, desiredPosition);
                return true;
            }       
            return false;
        }

        public string getCharacterAtPoint(Vector2Int point) {
            return lines[getActualY(point.y)][point.x].ToString();
        }

        public Vector2Int GetCharacterPosition(char mapEntity)
        {
            for (int i = 0; i < lines[0].Length; i++)
            {
                string line = lines[i];
                int x = line.IndexOf(mapEntity);

                if (x == -1)
                    continue; // continue searching

                return new Vector2Int(x, getActualY(i));
            }

            return null; // character not on map!
        }

        public string this[int x, int y]
        {
            //called when we ask for something = mySession["value"]
            get
            {
                return lines[getActualY(y)][x].ToString();
            }

            //called when we assign mySession["value"] = something
            set
            {
                Vector2Int point = new Vector2Int(x, y);
                WriteSymbolToPoint(value, point);
            }
        }

        /// <summary>Translate the mathy x,y format into the raster-based format
        /// </summary>
        private int getActualY(int y) {
            return lines.Length - 1 - y;
        }

    }
}
