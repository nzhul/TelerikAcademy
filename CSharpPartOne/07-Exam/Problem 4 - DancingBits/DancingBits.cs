using System;
using System.Text;

class DancingBits
{
    static void Main()
    {
        int k = Int32.Parse(Console.ReadLine());
        int n = Int32.Parse(Console.ReadLine());

        StringBuilder finalString = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            finalString.Append(Convert.ToString(int.Parse(Console.ReadLine()), 2));
        }
        finalString.Insert(0, 'R');
        finalString.Append('R');

        //Console.WriteLine(finalString);

        int dancingCount = 0;
        int equalCounter = 0;
        for (int i = 1; i < finalString.Length - 1; i++)
        {
            if (finalString[i] == finalString[i - 1])
            {
                equalCounter++;
            }
            else
            {
                equalCounter = 0;
            }

            if (equalCounter == k - 1)
            {
                if (i < finalString.Length - 1)
                {
                    if (finalString[i] != finalString[i + 1])
                    {
                        dancingCount++;
                    }
                }
            }
        }
        Console.WriteLine(dancingCount);
    }
}