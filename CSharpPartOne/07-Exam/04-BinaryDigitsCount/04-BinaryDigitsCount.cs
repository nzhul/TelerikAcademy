using System;


    class BinaryDigitsCount
    {
        static void Main()
        {
            byte b = byte.Parse(Console.ReadLine());
            uint n = uint.Parse(Console.ReadLine());
            string[] binaries = new string[n];
            uint zeroCount = 0;
            uint oneCount = 0;
            string currentString = "";

            for (int i = 0; i < n; i++)
            {
                currentString = Convert.ToString(uint.Parse(Console.ReadLine()), 2);
                binaries[i] = currentString;
            }

            for (int i = 0; i < binaries.Length; i++)
            {
                switch (b)
                {
                    case 1:
                        for (int z = 0; z < binaries[i].Length; z++)
                        {
                            if (binaries[i][z] == '1')
                            {
                                oneCount++;
                            }
                        }
                        Console.WriteLine(oneCount);
                        oneCount = 0;
                        break;
                    case 0:
                        for (int z = 0; z < binaries[i].Length; z++)
                        {
                            if (binaries[i][z] == '0')
                            {
                                zeroCount++;
                            }
                        }
                        Console.WriteLine(zeroCount);
                        zeroCount = 0;
                        break;
                    default:
                        break;
                }
            }
        }
    }