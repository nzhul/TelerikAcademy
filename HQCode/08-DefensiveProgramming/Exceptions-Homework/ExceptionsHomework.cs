using System;
using System.Linq;
using System.Collections.Generic;

class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        return arr.Skip(startIndex).Take(count).ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (!(count <= str.Length))
            throw new ArgumentOutOfRangeException("count");

        return str.Substring(str.Length - count);
    }

    public static bool IsPrime(int number)
    {
        if (!(number > 0))
            throw new ArgumentOutOfRangeException("Number");

        for (int i = 2; i * i <= number; i++)
            if ((number % i) == 0)
                return false;

        return true;
    }

    static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        Action<int[], int, int> checkSubsequence = (arr, startIndex, count) =>
            Console.WriteLine(String.Join(" ", Subsequence(arr, startIndex, count)));

        checkSubsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        checkSubsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        checkSubsequence(new int[] { -1, 3, 2, 1 }, 0, 0);

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));

        try
        {
            Console.WriteLine(ExtractEnding("Hi", 100));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Action<int> checkPrime = (n) =>
            Console.WriteLine("{0} is prime: {1}", n, IsPrime(n));

        checkPrime(23);
        checkPrime(33);

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);

        decimal peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:P0}", peterAverageResult);
    }
}