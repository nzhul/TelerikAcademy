using System;

class CountChars
{
    static void Main()
    {
        string text = "1100010111101010110";
        char target = '0';

        int counter = 0;
        int index = -1;

        while (true)
        {
            index = text.IndexOf(target, index + 1);
            if (index == -1)
            {
                break;
            }
            counter++;
        }
        Console.WriteLine(counter);
    }
}