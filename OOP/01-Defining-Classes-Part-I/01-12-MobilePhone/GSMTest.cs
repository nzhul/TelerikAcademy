using System;

class GSMTest
{
    public static void RunTest()
    {
        GSM[] testArray = new GSM[3];
        testArray[0] = new GSM("HTC Desire", "HTC", 450, "Gosheto", new Battery(BatteryType.LiIon, 350, 20), new Display(4, 250000));
        testArray[1] = new GSM("XPERIA", "SONY", 680, "Dimitrichka", new Battery(BatteryType.LiPoly, 560, 35), new Display(6, 450000));
        testArray[2] = new GSM("NOKIA 100", "NOKIA", 50, "Pesho", new Battery(BatteryType.NiMH, 450, 250), new Display(2, 2000));


        for (int i = 0; i < testArray.Length; i++)
        {
            Console.WriteLine(testArray[i]);
        }

        // Displaying the static Iphone
        Console.WriteLine(GSM.Iphone);
    }
}
