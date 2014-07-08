using System;

class BitBall
{
    static void Main(string[] args)
    {
        string[] binariesTeam1 = new String[8];
        char[,] Team1 = new Char[8, 8];
        string[] binariesTeam2 = new String[8];
        char[,] Team2 = new Char[8, 8];
        char[,] collisionMatrix = new Char[8, 8];
        int Team1Score = 0;
        int Team2Score = 0;

        // Populate Team 1
        for (int i = 0; i < 8; i++)
        {
            binariesTeam1[i] = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(8, '0');
        }

        // Populate Team 2
        for (int i = 0; i < 8; i++)
        {
            binariesTeam2[i] = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(8, '0');
        }

        // Populate Team 1 Char Matrix
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (binariesTeam1[i][j] == '1')
                {
                    Team1[i, j] = 'T';
                }
                else
                {
                    Team1[i, j] = binariesTeam1[i][j];
                }
            }
        }
        // Populate Team 2 Char Matrix
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (binariesTeam2[i][j] == '1')
                {
                    Team2[i, j] = 'B';
                }
                else
                {
                    Team2[i, j] = binariesTeam2[i][j];
                }
            }
        }

        //Console.WriteLine();
        //// Display Team 1 Matrix
        //Console.WriteLine("Team 1 Matrix: ");
        //for (int i = 0; i < 8; i++)
        //{
        //    for (int j = 0; j < 8; j++)
        //    {
        //        Console.Write(Team1[i, j]);
        //    }
        //    Console.WriteLine();
        //}
        //Console.WriteLine();
        //Console.WriteLine("Team 2 Matrix: ");
        //// Display Team 2 Matrix
        //for (int i = 0; i < 8; i++)
        //{
        //    for (int j = 0; j < 8; j++)
        //    {
        //        Console.Write(Team2[i, j]);
        //    }
        //    Console.WriteLine();
        //}

        // COLLISION!!!

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (Team1[i, j] == 'T' && Team2[i, j] == 'B')
                {
                    // Collision!!!
                    // Remove the players
                    Team1[i, j] = '0';
                    Team2[i, j] = '0';
                }
                if (Team1[i, j] == 'T')
                {
                    collisionMatrix[i, j] = Team1[i, j];
                }
                else if (Team2[i, j] == 'B')
                {
                    collisionMatrix[i, j] = Team2[i, j];
                }
                else
                {
                    collisionMatrix[i, j] = '0';
                }
            }
        }

        //Console.WriteLine();
        //// Display Collision Matrix
        //for (int i = 0; i < 8; i++)
        //{
        //    for (int j = 0; j < 8; j++)
        //    {
        //        Console.Write(collisionMatrix[i, j]);
        //    }
        //    Console.WriteLine();
        //}

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (collisionMatrix[i, j] == 'T')
                {
                    int row = i;
                    while (row <= 8)
                    {
                        if (row + 1 >= 8)
                        {
                            Team1Score++;
                            break;
                        }
                        if (collisionMatrix[row + 1, j] == '0')
                        {
                            row++;
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else if (collisionMatrix[i, j] == 'B')
                {

                    int row = i;
                    while (row >= 0)
                    {
                        if (row - 1 < 0)
                        {
                            Team2Score++;
                            break;
                        }
                        if (collisionMatrix[row - 1, j] == '0')
                        {
                            row--;
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
        Console.WriteLine("{0}:{1}", Team1Score, Team2Score);

        //// Display the new Team Matrixes
        //// Display Team 1 Matrix
        //Console.WriteLine();
        //Console.WriteLine("Team 1 Matrix After Collision: ");
        //for (int i = 0; i < 8; i++)
        //{
        //    for (int j = 0; j < 8; j++)
        //    {
        //        Console.Write(Team1[i, j]);
        //    }
        //    Console.WriteLine();
        //}
        //Console.WriteLine();
        //Console.WriteLine("Team 2 Matrix After Collision: ");
        //// Display Team 2 Matrix
        //for (int i = 0; i < 8; i++)
        //{
        //    for (int j = 0; j < 8; j++)
        //    {
        //        Console.Write(Team2[i, j]);
        //    }
        //    Console.WriteLine();
        //}

        //Console.WriteLine();
        //// Display Collision Matrix
        //for (int i = 0; i < 8; i++)
        //{
        //    for (int j = 0; j < 8; j++)
        //    {
        //        Console.Write(collisionMatrix[i, j]);
        //    }
        //    Console.WriteLine();
        //}
    }
}
