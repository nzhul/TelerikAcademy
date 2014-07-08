// 80/100 in bgcoder

using System;

class Slides
{
    static void Main()
    {
        string[] sizes = Console.ReadLine().Split();
        int width = int.Parse(sizes[0]);
        int height = int.Parse(sizes[1]);
        int depth = int.Parse(sizes[2]);
        string[, ,] cube = new string[width, height, depth];
        for (int h = 0; h < height; h++)
        {
            string[] lineFragment = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
            for (int d = 0; d < depth; d++)
            {
                string[] commands = lineFragment[d].Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                for (int w = 0; w < width; w++)
                {
                    cube[w, h, d] = commands[w];
                }
            }
        }
        string[] rawBallCoords = Console.ReadLine().Split();
        int ballW = int.Parse(rawBallCoords[0]);
        int ballD = int.Parse(rawBallCoords[1]);
        int ballH = 0;
        int oldBallW = ballW;
        int oldBallD = ballD;
        int oldBallH = ballH;

        while (true)
        {
            oldBallW = ballW;
            oldBallD = ballD;
            oldBallH = ballH;
            string[] command = cube[ballW, ballH, ballD].Split();
            switch (command[0])
            {
                case "S":
                    // we are sliding
                    ballH++; // we must allways increase height when we slide
                    switch (command[1])
                    {
                        case "L":
                            ballW--;
                            break;
                        case "R":
                            ballW++;
                            break;
                        case "F":
                            ballD--;
                            break;
                        case "B":
                            ballD++;
                            break;
                        case "FL":
                            ballW--;
                            ballD--;
                            break;
                        case "FR":
                            ballD--;
                            ballW++;
                            break;
                        case "BL":
                            ballD++;
                            ballW--;
                            break;
                        case "BR":
                            ballD++;
                            ballW++;
                            break;
                        default:
                            break;
                    }
                    break;
                case "T":
                    // we are telerpoting
                    ballW = int.Parse(command[1]);
                    ballD = int.Parse(command[2]);
                    break;
                case "E":
                    // empty cell
                    ballH++;
                    break;
                case "B":
                    // basket
                    oldBallW = ballW;
                    oldBallD = ballD;
                    oldBallH = ballH;
                    Console.WriteLine("No");
                    Console.WriteLine("{0} {1} {2}", oldBallW, oldBallH, oldBallD);
                    return;
                //break;
                default:
                    break;
            }

            if (ballH == height)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("{0} {1} {2}", oldBallW, oldBallH, oldBallD);
                break;
            }

            if (ballW < 0 || ballW > width || ballD < 0 || ballD > depth)
            {
                Console.WriteLine("No");
                Console.WriteLine("{0} {1} {2}", oldBallW, oldBallH, oldBallD);
                break;
            }
            else if (ballH < 0 || ballH > height)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("{0} {1} {2}", oldBallW, oldBallH, oldBallD);
                break;
            }
        }

    }
}
// H D W

// left = width--
// right = width++
// back = depth++;
// front = depth--;