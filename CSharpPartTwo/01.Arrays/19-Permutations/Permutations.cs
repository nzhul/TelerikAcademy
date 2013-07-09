using System;

class Permutations
{
    static void Main()
    {
        char[] elements = { 'a', 'b', 'c' };

        for (int i = 0; i < elements.Length; i++)
        {
            for (int j = 0; j < elements.Length; j++)
            {
                for (int z = 0; z < elements.Length; z++)
                {
                    if (elements[i] != elements[j] && elements[i] != elements[z] && elements[j] != elements[z] )
                    {
                        Console.WriteLine("{0}, {1}, {2}", elements[i], elements[j], elements[z]);
                    }
                }
            }
        }
    }
}