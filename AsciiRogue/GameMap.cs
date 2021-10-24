using System;
using System.IO;

namespace AsciiRogue
{
    public class GameMap
    {
        private string[] lines;

        public GameMap(){
            lines = File.ReadAllLines("./game_maps/level1.txt");
        }

        public string printMap() 
        {
            string flatMap = String.Join("\n", lines);
            Console.Clear();
            Console.WriteLine(flatMap);
            return flatMap;
        }

        public bool Traversable(Vector2Int position){
            return true;
        }

        public void MoveMapEntity(Vector2Int origin, Vector2Int destination){
            Char mapEntity = lines[origin.y][origin.x];
            
            // Replace origin character with space
            lines[origin.y] = lines[origin.y].Remove(origin.x, 1);

            // Place character at destination
            lines[destination.y] = lines[destination.y].Insert(destination.x, mapEntity.ToString());
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
    }
}