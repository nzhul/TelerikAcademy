using System;
using System.Linq;

    class MissCat
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] cats = new int[10];
            int currentVote;

            for (int i = 0; i < n; i++)
			{
                currentVote = int.Parse(Console.ReadLine());
                cats[currentVote - 1]++;
			}
            int maxCat = Array.IndexOf(cats, cats.Max()) + 1;

            Console.WriteLine(maxCat);
        }
    }