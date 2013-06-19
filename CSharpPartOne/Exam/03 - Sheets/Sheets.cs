using System;
using System.Collections.Generic;


class Sheets
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        int[] sheetA10Count = {1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1};
        List<int> remainingA = new List<int>(sheetA10Count);

        int currentClosest = GetClosest(n, sheetA10Count);
        //List<int> usedA = new List<int>();
        while (true)
        {
            //usedA.Add(GetClosest(n, sheetA10Count));
            remainingA.Remove(GetClosest(n, sheetA10Count));
            if (n - GetClosest(n, sheetA10Count) == 0)
            {
                break;
            }
            n = n - GetClosest(n, sheetA10Count);
        }

        // OUTPUT!!!
        foreach (var item in remainingA)
        {
            Console.WriteLine("A" + Array.IndexOf(sheetA10Count, item));
        }
    }

    static int GetClosest(int n, int[] sheetA10Count)
    {
        int closest = 0;
        int search = n;
        for (int i = 0; i < sheetA10Count.Length; i++)
        {
            if (Math.Abs(search - closest) > Math.Abs(sheetA10Count[i] - search))
            {
                closest = sheetA10Count[i];
            }
        }
        if (closest > n)
        {
            closest = sheetA10Count[Array.IndexOf(sheetA10Count, closest) + 1]; // Return the Lower A format if the closest number is bigger than N
        }
        return closest;
    }
}

//function getClosest($search, $arr) {
//   $closest = null;
//   foreach($arr as $item) {
//      if($closest == null || abs($search - $closest) > abs($item - $search)) {
//         $closest = $item;
//      }
//   }
//   return $closest;
//}
/*
 * 
 * 500 - 256 = 244 - 128 = 116 - 64 = 52 - 32 = 20 - 16 = 4 - 4 = 0
 * 
*/