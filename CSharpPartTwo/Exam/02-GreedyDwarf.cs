using System;

class GreedyDwarf
{
    static void Main()
    {
        string[] valley = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        int patternCount = int.Parse(Console.ReadLine());
        string[] patterns = new String[patternCount];
        bool[] visited = new bool[valley.Length];
        long bestPatternSum = long.MinValue;

        for (int i = 0; i < patterns.Length; i++)
        {
            patterns[i] = Console.ReadLine();
        }
        for (int i = 0; i < patterns.Length; i++)
        {
            string[] currentPattern = patterns[i].Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            long currentPatternSum = 0;
            int index = 0;
            int patternIndex = 0;
            // dokato ne sme na poseteno pole i sme vutre v valley - prodaljavame
            do
            {
                currentPatternSum += int.Parse(valley[index]);
                visited[index] = true;
                index += int.Parse(currentPattern[patternIndex]);
                patternIndex++;
                if (patternIndex == currentPattern.Length)
                {
                    patternIndex = 0;
                }
            } while (index >= 0 && index < valley.Length && visited[index] != true && patternIndex < currentPattern.Length);
            // Null the bool matrix
            Array.Clear(visited, 0, visited.Length);
            if (currentPatternSum > bestPatternSum)
            {
                bestPatternSum = currentPatternSum;
            }
        }
        Console.WriteLine(bestPatternSum);
    }
}
