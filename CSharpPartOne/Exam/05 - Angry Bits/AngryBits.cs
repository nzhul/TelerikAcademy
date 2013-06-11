using System;


class AngryBits
{
    static void Main()
    {
        string[] binaries = new string[8];
        char[,] charBinaries = new char[8, 16];

        for (int i = 0; i < 8; i++)
        {
            binaries[i] = Convert.ToString(ushort.Parse(Console.ReadLine()), 2).PadLeft(16, '0');
        }

        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 16; c++)
            {
                charBinaries[r, c] = binaries[r][c];
            }
        }

        // Display The Starting PlayField
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                Console.Write(charBinaries[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // Може да подавам Starting параметрите на birds като аргументи на метод.

        int birdStartingRow = 4; // starting from 0
        int currentCol = 7; // Трябва за използваме намаляващ цикъл.

        int birdRow = birdStartingRow;
        int birdCol = currentCol;
        charBinaries[birdRow, birdCol] = '0';
        byte direction = 1; // 1 for up and 2 for down
        int flightLength = 0;
        int pigKills = 0;
        int score = 0;

        do
        {
            flightLength++;

            // Change Direction
            if (birdRow < 0)
            {
                direction = 2; // Change direction to down
                birdRow += 2;
            }

            if (charBinaries[birdRow, birdCol] == '1' && birdCol > 7) // Тази проверка да се прави само ако се намираме в полето на прасетата.
            {
                // COLLISION!!!
                pigKills++; // Add 1 pig kill for the main target
                charBinaries[birdRow, birdCol] = '0'; // Remove the main pig

                if (birdRow > 0)
                {
                    if (charBinaries[birdRow - 1, birdCol - 1] == '1') // Check top left for pig
                    {
                        pigKills++;
                        charBinaries[birdRow - 1, birdCol - 1] = '0';// Remove the pig
                    }
                    if (charBinaries[birdRow - 1, birdCol] == '1') // Check top center for pig
                    {
                        pigKills++;
                        charBinaries[birdRow - 1, birdCol] = '0';// Remove the pig
                    }
                    if (birdCol < 15)
                    {
                        if (charBinaries[birdRow - 1, birdCol + 1] == '1') // Check top right for pig
                        {
                            pigKills++;
                            charBinaries[birdRow - 1, birdCol + 1] = '0';// Remove the pig
                        } 
                    }

                }

                if (charBinaries[birdRow, birdCol - 1] == '1') // Check middle left for pig
                {
                    pigKills++;
                    charBinaries[birdRow, birdCol - 1] = '0';// Remove the pig
                }
                if (birdCol < 15)
                {
                    if (charBinaries[birdRow, birdCol + 1] == '1') // Check middle right for pig
                    {
                        pigKills++;
                        charBinaries[birdRow, birdCol + 1] = '0';// Remove the pig
                    }
                }

                if (birdRow < 7)
                {
                    if (charBinaries[birdRow + 1, birdCol - 1] == '1') // Check down left for pig
                    {
                        pigKills++;
                        charBinaries[birdRow + 1, birdCol - 1] = '0';// Remove the pig
                    }
                    if (charBinaries[birdRow + 1, birdCol] == '1') // Check down center for pig
                    {
                        pigKills++;
                        charBinaries[birdRow + 1, birdCol] = '0';// Remove the pig
                    }
                    if (birdCol < 15)
                    {
                        if (charBinaries[birdRow + 1, birdCol + 1] == '1') // Check down right for pig
                        {
                            pigKills++;
                            charBinaries[birdRow + 1, birdCol + 1] = '0';// Remove the pig
                        }
                    }

                }

                score = flightLength * pigKills;
                break;
            }


            // Bird Movement
            if (direction == 1) // Up
            {
                birdCol++;
                birdRow--;
            }
            else if (direction == 2) // Down
            {
                birdCol++;
                birdRow++;
            }
        } while (birdRow <= 8 || birdCol <= 16);

        // Display The PlayField
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                Console.Write(charBinaries[i, j]);
            }
            Console.WriteLine();
        }
    }
}