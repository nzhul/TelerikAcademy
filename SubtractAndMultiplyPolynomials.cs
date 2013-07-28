using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SubtractAndMultiplyPolynomials
{
    static void Main()
    {
        decimal[] firstPolinomial = { 5, -1 };
        Console.Write("First polinomial:                 ");
        PrintPolynomial(firstPolinomial);

        decimal[] secondPolinomial = { 10, -5, 6 };
        Console.Write("Second polinomial:                ");
        PrintPolynomial(secondPolinomial);

        int maxLenght = 0;
        if (firstPolinomial.Length > secondPolinomial.Length)
        {
            maxLenght = firstPolinomial.Length;
        }
        else
        {
            maxLenght = secondPolinomial.Length;
        }

        decimal[] result = new decimal[maxLenght];
        Console.WriteLine();

        Sum(firstPolinomial, secondPolinomial, result);

        Console.Write("Sum:                              ");
        PrintPolynomial(result);

        SubtractPolynomials(firstPolinomial, secondPolinomial, result);

        Console.Write("Substraction:                     ");
        PrintPolynomial(result);

        decimal[] multiply = new decimal[firstPolinomial.Length + secondPolinomial.Length];

        MultiplyPolynomials(firstPolinomial, secondPolinomial, multiply);

        Console.Write("Multiplication:                  ");
        PrintPolynomial(multiply);
    }

    static void PrintPolynomial(decimal[] polynomial)
    {
        for (int i = polynomial.Length - 1; i >= 0; i--)
        {
            if (polynomial[i] != 0 && i != 0)
            {
                if (polynomial[i - 1] >= 0)
                {
                    Console.Write("{1}x^{0} +", i, polynomial[i]);
                }
                else
                {
                    Console.Write("{1}x^{0} ", i, polynomial[i]);
                }
            }
            else if (i == 0)
            {
                Console.Write("{0}", polynomial[i]);
            }
        }
        Console.WriteLine();
    }

    static void Sum(decimal[] firstPolynomial, decimal[] secondPolynomial, decimal[] result)
    {
        int minLenght = 0;
        int smallerPolynomial = 0;

        if (firstPolynomial.Length > secondPolynomial.Length)
        {
            minLenght = secondPolynomial.Length;
            smallerPolynomial = 2;
        }
        else
        {
            minLenght = firstPolynomial.Length;
            smallerPolynomial = 1;
        }
        for (int i = 0; i < minLenght; i++)
        {
            result[i] = firstPolynomial[i] + secondPolynomial[i];
        }
        for (int i = minLenght; i < result.Length; i++)
        {
            if (smallerPolynomial == 1)
            {
                result[i] = secondPolynomial[i];
            }
            else
            {
                result[i] = firstPolynomial[i];
            }
        }
    }

    static void SubtractPolynomials(decimal[] firstPolynomial, decimal[] secondPolynomial, decimal[] result)
    {
        int minLenght = 0;
        int smallerPolynomial = 0;

        if (firstPolynomial.Length > secondPolynomial.Length)
        {
            minLenght = secondPolynomial.Length;
            smallerPolynomial = 2;
        }
        else
        {
            minLenght = firstPolynomial.Length;
            smallerPolynomial = 1;
        }

        for (int i = 0; i < minLenght; i++)
        {
            result[i] = firstPolynomial[i] - secondPolynomial[i];
        }

        for (int i = minLenght; i < result.Length; i++)
        {
            if (smallerPolynomial == 1)
            {
                result[i] = secondPolynomial[i];
            }
            else
            {
                result[i] = firstPolynomial[i];
            }
        }
    }

    static void MultiplyPolynomials(decimal[] firstPolynomial, decimal[] secondPolynomial, decimal[] result)
    {
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = 0;
        }

        for (int i = 0; i < firstPolynomial.Length; i++)
        {
            for (int j = 0; j < secondPolynomial.Length; j++)
            {
                int position = i + j;
                result[position] += (firstPolynomial[i] * secondPolynomial[j]);
            }
        }
    }
}
