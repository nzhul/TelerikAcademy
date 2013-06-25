using System;

class Garden
{
    static void Main()
    {
        int tomatoSeeds = Int32.Parse(Console.ReadLine());
        int tomatoArea = Int32.Parse(Console.ReadLine());
        int cucumberSeeds = Int32.Parse(Console.ReadLine());
        int cucumberArea = Int32.Parse(Console.ReadLine());
        int potatoSeeds = Int32.Parse(Console.ReadLine());
        int potatoArea = Int32.Parse(Console.ReadLine());
        int carrotSeeds = Int32.Parse(Console.ReadLine());
        int carrotArea = Int32.Parse(Console.ReadLine());
        int cabbageSeeds = Int32.Parse(Console.ReadLine());
        int cabbageArea = Int32.Parse(Console.ReadLine());
        int beansSeeds = Int32.Parse(Console.ReadLine());
        int peshoArea = 250;

        double TotalCost = tomatoSeeds * 0.5 + cucumberSeeds * 0.4 + potatoSeeds * 0.25 + carrotSeeds * 0.6 + cabbageSeeds * 0.3 + beansSeeds * 0.4;
        int TotalArea = tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea;
        int areaLeft = peshoArea - TotalArea;
        Console.WriteLine("Total Cost: {0:F2}", TotalCost);
        if (areaLeft > 0)
        {
            // Print the Beans Area
            Console.WriteLine("Beans area: {0}", areaLeft);
        }
        else if (areaLeft == 0)
        {
            // No area for beans
            Console.WriteLine("No area for beans");
        }
        else if (areaLeft < 0)
        {
            // Insufficient area
            Console.WriteLine("Insufficient area");
        }
        
    }
}