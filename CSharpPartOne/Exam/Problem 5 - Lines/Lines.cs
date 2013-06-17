using System;


    class Lines
    {
        static void Main()
        {
            // Задачата не е решена!
            string[] binaries = new String[8];
            char[,] playField = new char[8, 8];

            for (int i = 0; i < 8; i++)
            {
                binaries[i] = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(8, '0');
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    playField[i, j] = binaries[i][j];
                }
            }
            int longestLine = 0;
            int longestLineCount = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (playField[i, j] == '1')
                    {
                        longestLine++;
                    }
                }
            }

        }
    }
