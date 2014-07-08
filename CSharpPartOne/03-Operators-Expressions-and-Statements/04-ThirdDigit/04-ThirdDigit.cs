// 04. Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.

using System;

class ThirdDigit
{
    static void Main()
    {
        Console.Write("Please enter a number: ");
        int number = int.Parse(Console.ReadLine());
        int thirdDigit = (number / 100) % 10; // Example: 1732 / 100 = 17.32; 17.32 / 10 = 1.732 (As we can see the difference is .732 and if we divide by modulus % we can get the number)
        if (thirdDigit == 7)
        {
            Console.WriteLine("The third digits IS seven!");
        }
        else
        {
            Console.WriteLine("The third digit IS NOT seven.");
        }
    }
}
