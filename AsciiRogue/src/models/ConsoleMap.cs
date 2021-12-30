using System;

using System.Text.RegularExpressions;

namespace AsciiRogue
{
    public class ConsoleMap
    {
        protected string[] lines;
        protected string[] shadowLines;
        public string MapName = "level1";

        public void LoadMap(string mapName)
        {
            lines = FileUtils.readMapFromResources(mapName);
            produceShadowLinesClone();
        }

        public override string ToString()
        {
            return String.Join("\n", lines);
        }

        public string PrintShadowMap() {
            return String.Join("\n", shadowLines);
        }

        protected void produceShadowLinesClone() {
            shadowLines = new string[lines.Length];
            lines.CopyTo(shadowLines, 0);

            // remove interactive symbols
            char[] interactiveSymbols = { '@', 's', 'S', '#' }; 
            foreach (char symbol in interactiveSymbols) {
                Vector2Int pos = GetCharacterPositionShadow(symbol);
                if (pos == null)
                    continue;
                WriteSymbolToPointShadow(" ", pos);
            }

        }

        public void WriteSymbolToPoint(string symbol, Vector2Int point) 
        {
            WriteSymbolToPoint(symbol, point, lines);
        }

        public void WriteSymbolToPointShadow(string symbol, Vector2Int point) 
        {
            WriteSymbolToPoint(symbol, point, shadowLines);
        }

        public void WriteSymbolToPoint(string symbol, Vector2Int point, string[] memoryLines) 
        {
            int y = getActualY(point.y);

            memoryLines[y] = memoryLines[y].Remove(point.x, 1);
            memoryLines[y] = memoryLines[y].Insert(point.x, symbol);
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
            Vector2Int characterPos = GetCharacterPosition(symbolMoving[0]);
            Vector2Int desiredPosition = characterPos + vector;

            if (Traversable(desiredPosition, traversableSymbols)) 
            {
                MoveMapEntity(characterPos, desiredPosition);
                return true;
            }       
            return false;
        }

        public bool InteractWithObject(Vector2Int movementVector) {
            Vector2Int characterPos = GetCharacterPosition('@');
            if (characterPos == null) {
                Console.WriteLine("Warning: Interation with object failed to find the '@' player, so aborting.");
                return false;
            }
            Vector2Int destinationVector = characterPos + movementVector;
            String destinationSymbol = this[destinationVector.x, destinationVector.y];

            // if the adjacent object is a switch, 
            // flip the switch
            // and delete the gate
            if (destinationSymbol == "s") {
                this[destinationVector.x, destinationVector.y] = "S";

                char symbol = '#';
                // remove all grates from the map
                Vector2Int gratePosition = GetCharacterPosition(symbol);
                this[gratePosition.x, gratePosition.y] = " ";
                WriteSymbolToPointShadow(symbol.ToString(), gratePosition);
            } else if (destinationSymbol == "S") {
                this[destinationVector.x, destinationVector.y] = "s";

                char symbol = '#';
                // remove all grates from the map
                Vector2Int gratePosition = GetCharacterPositionShadow(symbol);
                WriteSymbolToPointShadow(" ", gratePosition);
                this[gratePosition.x, gratePosition.y] = symbol.ToString();
            } 
            
            else if (destinationSymbol == "8") {
                int mapIndex = int.Parse(MapName.Replace("level", ""));
                MapName = "level" + (mapIndex+1);

                LoadMap(MapName);
            }

            return false;
        }

        public string getCharacterAtPoint(Vector2Int point) {
            return lines[getActualY(point.y)][point.x].ToString();
        }

        public Vector2Int GetCharacterPosition(char mapEntity){
            return GetCharacterPosition(lines, mapEntity);
        }

        public Vector2Int GetCharacterPositionShadow(char mapEntity){
            return GetCharacterPosition(shadowLines, mapEntity);
        }

        public Vector2Int GetCharacterPosition(string[] mapLines, char mapEntity)
        {
            // So... I'm thinking this is a bug, I'm not doing anything to iterate along the Y, only X is regarded here, thus
            // I get an index out of bounds error with non-squar or unfortunately shaped maps...

            for (int i = 0; i < mapLines.Length; i++)
            {
                string line = mapLines[i];
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
        protected int getActualY(int y) {
            return lines.Length - 1 - y;
        }

    }
}
