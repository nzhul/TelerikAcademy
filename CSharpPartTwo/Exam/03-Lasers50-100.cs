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
        int startW = int.Parse(rawStartPos[0]) - 1;
        int startH = int.Parse(rawStartPos[1]) - 1;
        int startD = int.Parse(rawStartPos[2]) - 1;

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


        while (true)
        {
            int nextW = startW + dirW;
            int nextH = startH + dirH;
            int nextD = startD + dirD;

            if (isInsideCube(nextW, nextH, nextD, cube))
            {
                if (cube[nextW, nextH, nextD] == false)
                {
                    cube[startW, startH, startD] = true;
                    startW = nextW;
                    startH = nextH;
                    startD = nextD;
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}", startW + 1, startH + 1, startD + 1);
                    break;
                }
            }
            // Reflection Occurs
            else
            {
                if (!(nextW >= 0 && nextW < width))
                {
                    dirW = -dirW;
                }
                if (!(nextH >= 0 && nextW < height))
                {
                    dirH = -dirH;
                }
                if (!(nextD >= 0 && nextD < depth))
                {
                    dirD = -dirD;
                }
            }
        }
    }

    static bool isInsideCube(int w, int h, int d , bool[,,] cube)
    {
        return w >= 0 && w < cube.GetLength(0) 
            && h >= 0 && h < cube.GetLength(1) 
            && d >= 0 && d < cube.GetLength(2);
    }
}
