//02. Write a program that reads two arrays from the console and compares them element by element.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        Console.Write("Arrays length: ");
        int n = Int32.Parse(Console.ReadLine());
        int[] FirstArray = new int[n];
        int[] SecondArray = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("FirstArray[{0}] = ", i);
            FirstArray[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n; i++)
        {
            Console.Write("SecondArray[{0}] = ", i);
            SecondArray[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine();
        for (int i = 0; i < n; i++)
        {
            bool isEqual = FirstArray[i] == SecondArray[i];
            Console.WriteLine("FirstArray[{0}] = {1} Compare to SecondArray[{0}] = {2} --> {3}", i, FirstArray[i], SecondArray[i], isEqual);
        }
    }
}
