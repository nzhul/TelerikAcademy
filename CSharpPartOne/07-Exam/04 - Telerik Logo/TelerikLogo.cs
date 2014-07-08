using System;


    class TelerikLogo
    {
        static void Main()
        {
            int x = Int32.Parse(Console.ReadLine());
            int width = 3 * x - 2;
            char[,] matrix = new char[width,width];

            // Filling the whole matrix with dots '.'
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i,j] = '.';
                }
            }

            string directionLR = "right";
            string directionUD = "up";
            int startingRow = x / 2; // startingRow = 2 if x = 5
            int cols = 0;
            int rows = startingRow;
            // Filling with asterics
            do
            {
                if ((directionLR == "right" && directionUD == "up") && rows < 0)
                {
                    directionUD = "down";
                    rows += 2;
                }

                else if ((directionLR == "right" && directionUD == "down") && cols > (width - startingRow - 1) && !(cols + startingRow > width))
                {
                    directionLR = "left";
                    cols -= 2;
                }

                else if ((directionLR == "left" && directionUD == "down") && rows > width - 1)
                {
                    directionUD = "up";
                    rows -= 2;
                }
                else if ((directionLR == "left" && directionUD == "up") && cols < (0 + startingRow))
                {
                    directionLR = "right";
                    cols += 2;
                }


                matrix[rows, cols] = '*';

                if (directionLR == "right" && directionUD == "up")
                {
                    cols++;
                    rows--;
                }
                else if (directionLR == "right" && directionUD == "down")
                {
                    cols++;
                    rows++;
                }
                else if (directionLR == "left" && directionUD == "down")
                {
                    cols--;
                    rows++;
                }
                else if (directionLR == "left" && directionUD == "up")
                {
                    cols--;
                    rows--;
                }
            } while (!(cols >= width));

            // Display the matrix
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
