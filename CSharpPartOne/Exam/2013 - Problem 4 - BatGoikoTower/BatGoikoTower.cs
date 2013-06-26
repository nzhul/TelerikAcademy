using System;


class BatGoikoTower
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        int outerDots = n - 1;
        int innerDots = 0;
        int dashRow = 1;
        int dashIncrement = 2;

        for (int i = 0; i < n; i++)
        {

            string drawOuterDots = new String('.', outerDots);
            string drawInnerDots = new String('.', innerDots);
            string drawInnerDashes = new String('-', innerDots);
            Console.Write(drawOuterDots);
            Console.Write("/");
            if (i == dashRow)
            {
                Console.Write(drawInnerDashes);
                dashRow += dashIncrement;
                dashIncrement++;
            }
            else
            {
                Console.Write(drawInnerDots);
            }
            Console.Write("\\");
            Console.WriteLine(drawOuterDots);

            outerDots--;
            innerDots += 2;
        }
    }
}