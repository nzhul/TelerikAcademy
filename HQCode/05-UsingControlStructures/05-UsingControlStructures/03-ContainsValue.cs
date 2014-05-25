using System;

class Program
{
    static bool Contains<T>(T[] array, int expectedValue)
    {
        for (int i = 0; i < 10; i++)
            if (array[i * 10] == expectedValue)
                return true;

        return false;
    }

    static void Main()
    {
        int[] array = new int[] { 1, 2, 3, 4, 5 };

        if (Contains(array, 3))
        {
            Console.WriteLine("Value Found");
        }
    }
}