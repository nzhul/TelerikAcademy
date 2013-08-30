using System;

class Lazers
{
    static void Main()
    {
        string[] rawSizes = Console.ReadLine().Split();
        int width = int.Parse(rawSizes[0]);
        int height = int.Parse(rawSizes[1]);
        int depth = int.Parse(rawSizes[2]);

        string[] rawStartPos = Console.ReadLine().Split();
        int startW = int.Parse(rawStartPos[0]);
        int startH = int.Parse(rawStartPos[1]);
        int startD = int.Parse(rawStartPos[2]);

        string[] rawDirs = Console.ReadLine().Split();
        int dirW = int.Parse(rawDirs[0]);
        int dirH = int.Parse(rawDirs[1]);
        int dirD = int.Parse(rawDirs[2]);

        bool[,,] cube = new bool[width,height,depth];
        // Set the edges - true (burned) - HEIGHT
        for (int h = 0; h < height; h++)
        {
            // set height edge
            cube[0, h, 0] = true;
            cube[width - 1, h, 0] = true;
            cube[0, h, depth - 1] = true;
            cube[width - 1, h, depth - 1] = true;
        }
        // Set the edges - true (burned) - Width
        for (int w = 0; w < width; w++)
        {
            // set width edge
            cube[w, 0, 0] = true;
            cube[w, height - 1, 0] = true;
            cube[w, 0, depth - 1] = true;
            cube[w, height - 1, depth - 1] = true;
        }
        // Set the edges - true (burned) - Width
        for (int d = 0; d < depth; d++)
        {
            // set width edge
            cube[0, 0, d] = true;
            cube[0, height - 1, d] = true;
            cube[width - 1, height - 1, d] = true;
            cube[width - 1, 0, d] = true;
        }
        Console.WriteLine();


        while (true)
        {
            if (dirW == 1)
            {
                startW++;
            }
            else if (dirW == -1)
            {
                startW--;
            }

            if (dirH == 1)
            {
                startH++;
            }
            else if (dirH == -1)
            {
                startH--;
            }

            if (dirD == 1)
            {
                startD++;
            }
            else if (dirD == -1)
            {
                startD--;
            }
            // Burn the box
            cube[startW, startH, startD] = true;
            // Check for reflection
            if (startD <= 0)
            {

            }
        }
    }
}
