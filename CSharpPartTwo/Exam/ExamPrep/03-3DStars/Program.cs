using System;

class Stars
{
    public static char[, ,] cube;
    static void Main()
    {
        string[] rawDimentions = Console.ReadLine().Split();
        int width = int.Parse(rawDimentions[0]);
        int height = int.Parse(rawDimentions[1]);
        int depth = int.Parse(rawDimentions[2]);
        cube = new char[width, height, depth];

        for (int h = 0; h < height; h++)
        {
            string[] line = Console.ReadLine().Split();
            for (int d = 0; d < depth; d++)
            {
                string token = line[d];
                for (int w = 0; w < width; w++)
                {
                    cube[w, h, d] = token[w];
                }
            }
        }
        Console.WriteLine();
    }
}