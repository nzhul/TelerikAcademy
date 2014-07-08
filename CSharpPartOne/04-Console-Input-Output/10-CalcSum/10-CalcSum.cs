// 10. Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...


using System;

class CalcSum
{
    static void Main()
    {
        double startNumber = 1;
        double totalSum = 1;
        Console.WriteLine(startNumber);
        for (double j = 2; j <= 1000; j++)
        {
            startNumber = 1;
            if (j % 2 == 0)
            {
                startNumber = startNumber / j;
            }
            else
            {
                startNumber = -(startNumber / j);
            }
            Console.WriteLine(startNumber);

            totalSum = totalSum + startNumber;
        }
        Console.WriteLine("The Total sum is: {0}", totalSum);
    }
}