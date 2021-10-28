using System;
using System.Collections;
using System.IO;

namespace AsciiRogue
{
    public class FileUtils
    {

        public static string[] readMapFromResources(string mapLevel) {
            return readTxtFromResources("game_maps.", mapLevel);
        }

        public static string[] readMenuFromResources(string menuName) {
            return readTxtFromResources("menus.", menuName);
        }

        public static string[] readTxtFromResources(string subfolder, string fileName) {
            var assembly = typeof(AsciiRogue.GameMap).Assembly;
            Stream resource = assembly.GetManifestResourceStream("AsciiRogue.assets." + subfolder + fileName + ".txt");
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
    }
}