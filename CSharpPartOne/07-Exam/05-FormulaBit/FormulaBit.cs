using System;

class FormulaBit
{
    static void Main()
    {
        string[] binaries = new String[8];
        char[,] playField = new Char[8, 8];
        string direction = "down";
        int row = 7;
        int col = 0;

        for (int i = 0; i < 8; i++)
        {
            binaries[i] = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(8, '0');
        }

        // Populate the PlayField Matrix
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                playField[i, j] = binaries[i][j];
            }
        }

        // Display the starting PlayField
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(playField[i, j]);
            }
            Console.WriteLine();
        }

        while (true)
        {

            if (direction == "down" && playField[row, col] != '0')
            {
                direction = "left";
                row--;
                col--;
            }
            else if (direction == "left" && playField[row, col] != '0')
            {
                direction = "up";
                col++;
                row--;
            }
            else if (direction == "up" && playField[row, col] != '0')
            {
                direction = "left";
                row++;
                col--;
            }

            if (direction == "down")
            {
                row++;
            }
            else if (direction == "left")
            {
                col--;
            }
            else if (direction == "up")
            {
                row--;
            }
        }
    }
}