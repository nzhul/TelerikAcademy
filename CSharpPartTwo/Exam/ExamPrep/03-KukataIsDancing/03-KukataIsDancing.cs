// 100/100 in bgcoder

using System;


class KukataDance
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] lines = new string[n];
        string[,] PlayField =
        {
            {"RED", "BLUE", "RED"},
            {"BLUE", "GREEN", "BLUE"},
            {"RED", "BLUE", "RED"}
        };

        for (int i = 0; i < n; i++)
        {
            int row = 1;
            int col = 1;
            bool up = true;
            bool right = false;
            bool down = false;
            bool left = false;
            lines[i] = Console.ReadLine();
            for (int j = 0; j < lines[i].Length; j++)
            {
                switch (lines[i][j])
                {
                    case 'L':
                        if (up)
                        {
                            up = false;
                            right = false;
                            down = false;
                            left = true;
                        }
                        else if (right)
                        {
                            up = true;
                            right = false;
                            down = false;
                            left = false;
                        }
                        else if (down)
                        {
                            up = false;
                            right = true;
                            down = false;
                            left = false;
                        }
                        else if (left)
                        {
                            up = false;
                            right = false;
                            down = true;
                            left = false;
                        }
                        break;
                    case 'R':
                        if (up)
                        {
                            up = false;
                            right = true;
                            down = false;
                            left = false;
                        }
                        else if (right)
                        {
                            up = false;
                            right = false;
                            down = true;
                            left = false;
                        }
                        else if (down)
                        {
                            up = false;
                            right = false;
                            down = false;
                            left = true;
                        }
                        else if (left)
                        {
                            up = true;
                            right = false;
                            down = false;
                            left = false;
                        }
                        break;
                    case 'W':
                        if (up)
                        {
                            if (row > 0)
                            {
                                row--;
                            }
                            else
                            {
                                row = 2;
                            }
                        }
                        else if (right)
                        {
                            if (col < 2)
                            {
                                col++;
                            }
                            else
                            {
                                col = 0;
                            }
                        }
                        else if (down)
                        {
                            if (row < 2)
                            {
                                row++;
                            }
                            else
                            {
                                row = 0;
                            }
                        }
                        else if (left)
                        {
                            if (col > 0)
                            {
                                col--;
                            }
                            else
                            {
                                col = 2;
                            }
                        }
                        break;
                }
            }
            Console.WriteLine(PlayField[row, col]);
        }

    }
}