// 07. Write a program that finds the greatest of given 5 variables.

using System;
using System.Linq;

class GreatestNumber
{
    static void Main()
    {
        // First Solution - using arrays and loops
        Console.Write("Enter the numbers count:");
        int readCount = int.Parse(Console.ReadLine());
        int[] numbersArr = new int[readCount];

        for (int i = 0; i < readCount; i++)
        {
            Console.Write("Number {0}: ", i + 1);
            numbersArr[i] = int.Parse(Console.ReadLine());
        }

        int greatestNumber = numbersArr.Max();
        Console.WriteLine("The Greatest number is: {0}", greatestNumber);



        // Second Solution - Using IFs
        // Write a program that finds the greatest of given 5 variables.

        Console.Write("Enter first number: ");
        double firstNumber = double.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        double secondNumber = double.Parse(Console.ReadLine());
        Console.Write("Enter third number: ");
        double thirdNumber = double.Parse(Console.ReadLine());
        Console.Write("Enter fourth number: ");
        double fourthNumber = double.Parse(Console.ReadLine());
        Console.Write("Enter fifth number: ");
        double fifthNumber = double.Parse(Console.ReadLine());

        double BiggestNumber = firstNumber;
        if (BiggestNumber < secondNumber)
        {
            BiggestNumber = secondNumber;
        }
        if (BiggestNumber < thirdNumber)
        {
            BiggestNumber = thirdNumber;
        }
        if (BiggestNumber < fourthNumber)
        {
            BiggestNumber = fourthNumber;
        }
        if (BiggestNumber < fifthNumber)
        {
            BiggestNumber = fifthNumber;
        }
        Console.WriteLine("The greatest variable is: {0}", BiggestNumber);
    }
}
