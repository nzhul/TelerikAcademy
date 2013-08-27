using System;

class Slides
{
    static void Main()
    {
        string[] sizes = Console.ReadLine().Split();
        int width = int.Parse(sizes[0]);
        int height = int.Parse(sizes[1]);
        int depth = int.Parse(sizes[2]);
        string[, ,] cube = new string[width,height,depth];
        for (int h = 0; h < height; h++)
        {
            string[] lineFragment = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
            for (int d = 0; d < depth; d++)
            {
                string[] commands = lineFragment[d].Split(new char[] {'(',')' },StringSplitOptions.RemoveEmptyEntries);
                for (int w = 0; w < width; w++)
                {
                    cube[w,h,d] = commands[w];
                }
            }
        }
        string[] rawBallCoords = Console.ReadLine().Split();
        int ballW = int.Parse(Console.ReadLine());
        int ballD = int.Parse(Console.ReadLine());
        int ballH = 0;


    }
}
// H D W