using System;
using System.Collections.Generic;
using System.IO;

namespace Point
{
    public static class PathStorage
    {
        public static void SavePath(Path path)
        {
            using (StreamWriter writer = new StreamWriter("../../Saves.txt"))
            {
                foreach (var point in path.AllPoints)
                {
                    writer.WriteLine(point);
                }
                Console.WriteLine("The new path was saved successfuly!");
            }
        }

        public static Path LoadPath()
        {
            Path loadPath = new Path();
            using (StreamReader reader = new StreamReader("../../Saves.txt"))
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    string[] splittedLine = line.Split(new char[] {' ', '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                    loadPath.AddPoint(new Point3D(double.Parse(splittedLine[0]), double.Parse(splittedLine[1]), double.Parse(splittedLine[2])));
                }
                return loadPath;
            }

        }

    }
}
