using System;


class LongestSequence
{
    static void Main()
    {
        string[,] elements = 
        {
            {"ha", "fifi", "ho", "hi"},
            {"fo", "ha", "hi", "xx"},
            {"xxx", "ho", "ha", "xx"}
        };
        int currentSeq = 1;
        int bestSeq = int.MinValue;
        int bestSeqRow = 0;
        int bestSeqCol = 0;
        int bestSeqDirection = 0;

        for (int i = 0; i < elements.GetLength(0); i++)
        {
            for (int j = 0; j < elements.GetLength(1) - 1; j++)
            {
                if (elements[i, j] == elements[i, j + 1])
                {
                    currentSeq++;
                }
                else
                {
                    currentSeq = 1;
                }

                if (bestSeq > currentSeq)
                {
                    
                }
            }
        }


    }
}
