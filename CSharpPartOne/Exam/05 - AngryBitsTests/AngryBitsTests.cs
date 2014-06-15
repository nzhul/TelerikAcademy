using System;


class AngryBits
{
    static void Main()
    {
        string[] binaries = new string[8];
        char[,] charBinaries = new char[8, 16];
        int[] birdPositions = { 9, 9, 9, 9, 9, 9, 9, 9 }; // We fill the matrix with 9ns so we can detect if there is bird in that column or not!
        string victory = "";
        int birdRow = 0;
        int birdCol = 0;

        for (int i = 0; i < 8; i++)
        {
            binaries[i] = Convert.ToString(ushort.Parse(Console.ReadLine()), 2).PadLeft(16, '0');
        }

        // use the string Array to populate 16x8 char matrix
        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 16; c++)
            {
                charBinaries[r, c] = binaries[r][c];
            }
        }


        // Determine the row position of every bird
        for (int i = 0; i <= 7; i++)
        {
            for (int j = 0; j <= 7; j++)
            {
                if (charBinaries[i, j] == '1')
                {
                    birdPositions[j] = i;
                }
            }
        }

        // Display the bird positions
        for (int i = 0; i <= 7; i++)
        {
            Console.Write(birdPositions[i]);
        }
        Console.Write(" :Bird Row Positions");
        Console.WriteLine();

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
        int score = 0;
        // THE MAIN LOOP!!!
        for (int birdCol1 = 7; birdCol1 >= 0; birdCol1--)
        {

            if (birdPositions[birdCol1] == 9) // if there is no bird in that column we return 0 as score
            {
                break;
            }

            birdRow = birdPositions[birdCol1];
            birdCol = birdCol1;
            charBinaries[birdRow, birdCol] = '0';
            byte direction = 1; // 1 for up and 2 for down
            int flightLength = -1; // This is kinda CHEAT because the flight must be shorter by 1 and i decided to subtract 1 at the begining
            int pigKills = 0;

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

                    score += flightLength * pigKills;
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
        }

        // Display The FinalField PlayField
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                Console.Write(charBinaries[i, j]);
            }
            Console.WriteLine();
        }

        // Check if the Playfield is empty or not
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                if (charBinaries[i, j] == '1')
                {
                    victory = "No";
                    break;
                }
                else
                {
                    victory = "Yes";
                }
            }
        }

        // Display the score
        Console.WriteLine("{0} {1}", score, victory);
    }

}