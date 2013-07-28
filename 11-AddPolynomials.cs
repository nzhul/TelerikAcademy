using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AddPolynomials
{
    static void Main()
    {
        decimal[] firstPolynomial = { 5, -1 };
        Console.Write("First Polynomial:           ");
        PrintPolynomial(firstPolynomial);

        decimal[] secondPolynomial = { 10, -5, 6 };
        Console.Write("Second Polynomial:           ");
        PrintPolynomial(secondPolynomial);

        int maxLenght = 0;
        if (firstPolynomial.Length > secondPolynomial.Length)
        {
            maxLenght = firstPolynomial.Length;
        }
        else
        {
            maxLenght = secondPolynomial.Length;
        }

        decimal[] result = new decimal[maxLenght];
        Console.WriteLine();

        Sum(firstPolynomial, secondPolynomial, result);

        Console.Write("Sum:                         ");
        PrintPolynomial(result);
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
}
