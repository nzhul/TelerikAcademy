// 100/100 in bgcoder

using System;
using System.Linq;

class JoroTheRabbit
{
    static void Main()
    {
        string[] terrainTokens = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        int[] terrainNumbers = new int[terrainTokens.Length];
        for (int i = 0; i < terrainTokens.Length; i++)
        {
            terrainNumbers[i] = int.Parse(terrainTokens[i]);
        }
        int length = terrainNumbers.Length;
        int currentLength = 0;
        int maxLength = int.MinValue;
        for (int index = 0; index < length; index++)
        {
            for (int step = 1; step <= length; step++)
            {
                // we must start from the lowest element
                int innerIndex = index;
                //int index = Array.IndexOf(terrainNumbers, terrainNumbers.Min());
                while (true)
                {
                    int oldPositionValue = terrainNumbers[innerIndex];
                    innerIndex += step;
                    //step++;
                    currentLength++;
                    if (innerIndex >= length)
                    {
                        innerIndex -= length;
                    }
                    if (terrainNumbers[innerIndex] <= oldPositionValue)
                    {
                        //break
                        if (currentLength > maxLength)
                        {
                            maxLength = currentLength;
                        }
                        currentLength = 0;
                        break;
                    }
                }
            }
        }
        Console.WriteLine(maxLength);

    }
}