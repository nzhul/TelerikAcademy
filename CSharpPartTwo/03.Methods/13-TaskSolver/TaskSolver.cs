//13. Write a program that can solve these tasks:
//    Reverses the digits of a number
//    Calculates the average of a sequence of integers
//    Solves a linear equation a * x + b = 0
//            Create appropriate methods.
//            Provide a simple text-based menu for the user to choose which task to solve.
//            Validate the input data:
//    The decimal number should be non-negative
//    The sequence should not be empty
//    a should not be equal to 0

using System;

class TaskSolver
{
    static void Main()
    {
        Console.WriteLine("SELECT TASK TO SOLVE:");
        Console.Write("\u250c");
        Console.Write("----------------------------------------");
        Console.WriteLine("\u2510");
        Console.WriteLine("| 1. Reverse the digits of a number      |");
        Console.WriteLine("| 2. Calculate Average                   |");
        Console.WriteLine("| 3. Solve linear equation a * x + b = 0 |");
        Console.Write("\u2514");
        Console.Write("----------------------------------------");
        Console.WriteLine("\u2518");

        int input = int.Parse(Console.ReadLine());

        switch (input)
        {
            case 1:
                ReverseInput();
                break;
            case 2:
                AverageInput();
                break;
            case 3:
                EquationInput();
                break;
            default:
                Console.WriteLine("Invalid Input - Please Select 1, 2 or 3");
                break;
        }
    }

    static void EquationInput()
    {
        Console.Write("Enter a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        int b = int.Parse(Console.ReadLine());

        if (a == 0)
        {
            Console.WriteLine("A must not be equal to Zero!");
        }
        else
        {
            Console.WriteLine("Equation result is: {0}", CalcEquation(a, b));
        }
    }

    static double CalcEquation(int a, int b)
    {
        return (double)-b / a;
    }

    static void AverageInput()
    {
        Console.WriteLine("Enter the size of the sequence: ");
        int n = int.Parse(Console.ReadLine());
        if (n <= 0)
        {
            Console.WriteLine("The sequence must have atleast 1 or more elements!");
            return;
        }
        int[] sequence = new int[n];
        for (int i = 0; i < sequence.Length; i++)
        {
            Console.Write("Enter Element {0}: ", i);
            sequence[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("The Average of the sequence is: {0}", CalcAverage(sequence));
    }

    static double CalcAverage(int[] sequence)
    {
        double sum = 0;
        for (int i = 0; i < sequence.Length; i++)
        {
            sum += sequence[i];
        }

        return sum / sequence.Length;
    }

    static void ReverseInput()
    {
        Console.Write("Enter N: ");
        string number = Console.ReadLine();
        if (int.Parse(number) > 0)
        {
            Console.WriteLine("The Reversed N is: {0}", Reverse(number));
        }
        else
        {
            Console.WriteLine("The number must ne non-negative");
        }
    }

    static int Reverse(string number)
    {
        int[] digits = new int[number.Length];
        int numberInt = int.Parse(number);
        int i = 0;
        while (numberInt > 0)
        {
            int lastDigit = numberInt % 10;
            numberInt /= 10;
            digits[i] = lastDigit;
            i++;
        }

        int finalNumber = 0;
        for (int j = 0; j < digits.Length; j++)
        {
            finalNumber = finalNumber * 10 + digits[j];
        }
        return finalNumber;
    }
}
