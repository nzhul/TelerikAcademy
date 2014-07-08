using System;


    class UKFlag
    {
        static void Main()
        {
            int n = Int32.Parse(Console.ReadLine());
            int innerDotsCount = (n / 2) - 1;
            int outerDotsCount = 0;

            for (int i = 0; i < n / 2; i++)
            {
                string drawInnerDots = new string('.', innerDotsCount);
                string drawOuterDots = new string('.', outerDotsCount);
                Console.WriteLine("{0}\\{1}|{1}/{0}",drawOuterDots, drawInnerDots);
                innerDotsCount--;
                outerDotsCount++;
            }

            string drawHyphen = new string('-', n / 2);
            Console.Write(drawHyphen);
            Console.Write("*");
            Console.Write(drawHyphen);
            Console.WriteLine();

            innerDotsCount++;
            outerDotsCount--;
            for (int i = n / 2; i > 0; i--)
            {
                string drawInnerDots = new string('.', innerDotsCount);
                string drawOuterDots = new string('.', outerDotsCount);
                Console.WriteLine("{0}/{1}|{1}\\{0}", drawOuterDots, drawInnerDots);
                innerDotsCount++;
                outerDotsCount--;
            }
        }
    }
