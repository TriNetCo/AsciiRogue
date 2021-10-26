using System;
using System.IO;
using System.Collections;

namespace AsciiRogue
{
    public class GameMap
    {
        private string[] lines;

        public GameMap() {
            lines = readMapFromResources("level1");
        }

        public GameMap(string map) {
            lines = map.Split("\n");
        }

        public string printMap()
        {
            string flatMap = String.Join("\n", lines);
            return flatMap;
        }

        public bool Traversable(Vector2Int position) {
            string mapEntity = getCharacterAtPoint(position);
            if (mapEntity == " ")
                return true;
            return false;
        }
        
        /// <summary>Moves the Map Entity at origin to the destination
        /// </summary>
        public void MoveMapEntity(Vector2Int origin, Vector2Int destination){
            string originMapEntity = getCharacterAtPoint(origin);

            if (isLeavingCurrentRow(origin, destination)) {
                //   remove a " " from the row we're entering 
                lines[destination.y] = lines[destination.y].Remove(destination.x, 1);
                //   add a " " to the row we're leaving
                lines[origin.y] = lines[origin.y].Insert(origin.x, " ");
            }

            // Remove character at origin space
            lines[origin.y] = lines[origin.y].Remove(origin.x, 1);

            // Place character at destination
            lines[destination.y] = lines[destination.y].Insert(destination.x, originMapEntity);

            // Force our origin space to become a " " symbol
            overwriteCharacterAtPoint(origin, " ");
        }

        public string getCharacterAtPoint(Vector2Int point) {
            return lines[point.y][point.x].ToString();
        }

        public void overwriteCharacterAtPoint(Vector2Int point, string character) {
            lines[point.y] = lines[point.y].Remove(point.x, 1);
            lines[point.y] = lines[point.y].Insert(point.x, character);
        }

        public bool isLeavingCurrentRow(Vector2Int origin, Vector2Int destination) {
            return (origin.y != destination.y);
        }

        public Vector2Int GetCharacterPosition(Char mapEntity)
        {
            for (int i = 0; i < lines[0].Length; i++)
            {
                string line = lines[i];
                int x = line.IndexOf(mapEntity);

                if (x == -1)
                    continue; // continue searching

                return new Vector2Int(x, i);
            }

            return null; // character not on map!
        }

        public string[] readMapFromResources(string mapLevel) {
            var assembly = typeof(AsciiRogue.GameMap).Assembly;
            Stream resource = assembly.GetManifestResourceStream("AsciiRogue.assets.game_maps." + mapLevel + ".txt");
            ArrayList lineList = new ArrayList();

            using (StreamReader reader = new StreamReader(resource))
            {
                while(!reader.EndOfStream)
                {
                    lineList.Add(reader.ReadLine());
                }
            }

            string[] fileLines = new string[lineList.Count];
            for (int i = 0; i < lineList.Count; i++) {
                fileLines[i] = (string) lineList[i];
            }

            return fileLines;
        }

        public string this[int x, int y]
        {
            //called when we ask for something = mySession["value"]
            get
            {
                return lines[y][x].ToString();
            }

            //called when we assign mySession["value"] = something
            set
            {
                //lines[y][x] = value;
                // MySetData(key, value);
            }
        }

    }
}
