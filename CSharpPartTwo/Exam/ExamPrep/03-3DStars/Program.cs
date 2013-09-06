using System;
using System.Collections.Generic;
using System.Linq;

class Stars
{
    //public static char[, ,] cube;
    static void Main()
    {
        string[] rawDimentions = Console.ReadLine().Split();
        int width = int.Parse(rawDimentions[0]);
        int height = int.Parse(rawDimentions[1]);
        int depth = int.Parse(rawDimentions[2]);
        char[, ,] cube = new char[width, height, depth];

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

        Dictionary<char, int> stars = new Dictionary<char, int>();
        for (int h = 1; h < height - 1; h++)
        {
            for (int d = 1; d < depth - 1; d++)
            {
                for (int w = 1; w < width - 1; w++)
                {
                    if (cube[w, h, d] == cube[w, h + 1, d]
                     && cube[w, h, d] == cube[w, h - 1, d]
                     && cube[w, h, d] == cube[w + 1, h, d]
                     && cube[w, h, d] == cube[w - 1, h, d]
                     && cube[w, h, d] == cube[w, h, d + 1]
                     && cube[w, h, d] == cube[w, h, d - 1])
                    {
                        if (stars.ContainsKey(cube[w, h, d]))
                        {
                            stars[cube[w, h, d]] += 1;
                        }
                        else
                        {
                            stars.Add(cube[w, h, d], 1);
                        }
                    }
                }
            }
        }

        int starsCount = 0;
        foreach (var star in stars)
        {
            starsCount += star.Value;
        }
        Console.WriteLine(starsCount);

        foreach (var star in stars.OrderBy(m => m.Key))
        {
            Console.WriteLine("{0} {1}", star.Key, star.Value);
        }
    }
}