using System;
using System.Text;

    class FallDown
    {
        static void Main()
        {
            string[] binaries = new string[8];
            int[] columnFullCount = new int[8];

            for (int i = 0; i < 8; i++)
            {
                binaries[i] = Convert.ToString(byte.Parse(Console.ReadLine()), 2).PadLeft(8, '0');
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (binaries[i][j] == '1')
	                {
                        columnFullCount[j]++;
	                }
                }
            }

            char[,] newBinaries = new char[8,8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (columnFullCount[j] >= 8 - i) // if there is no space left
                    {
                        newBinaries[i, j] = '1';
                    }
                    else
                    { 
                        newBinaries[i, j] = '0';
                    }
                }
            }

            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write(newBinaries[i, j]);
            //    }
            //    Console.WriteLine();
            //}

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    builder.Append(newBinaries[i, j]);
                }
                Console.WriteLine(Convert.ToInt32(builder.ToString(), 2));
                builder.Clear();
            }
        }
    }