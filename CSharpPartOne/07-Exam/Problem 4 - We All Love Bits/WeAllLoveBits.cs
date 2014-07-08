using System;

    class WeAllLoveBits
    {
        static void Main()
        {

            // Задачата не е готова още !!!
            int n = Int32.Parse(Console.ReadLine());
            string[] binaries = new string[n];
            char[][] reversedBinaries = new char[n][];

            for (int i = 0; i < n; i++)
            {
                binaries[i] = Convert.ToString(Int32.Parse(Console.ReadLine()), 2);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < binaries[i].Length; j++)
                {
                    if (binaries[i][j] == '1')
                    {
                        reversedBinaries[i][j] = '0';
                    }
                    else
                    {
                        reversedBinaries[i][j] = '1';
                    }   
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < binaries[i].Length; j++)
                {
                    Console.Write(binaries[i][j]);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < binaries[i].Length; j++)
                {
                    Console.Write(reversedBinaries[i][j]);
                }
                Console.WriteLine();
            }

        }
    }
