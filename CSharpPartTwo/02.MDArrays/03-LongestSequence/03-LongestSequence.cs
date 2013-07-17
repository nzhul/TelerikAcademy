using System;


class LongestSequence
{
    static void Main()
    {
        //string[,] elements = 
        //{
        //    {"ha", "fifi", "ho", "hi"},
        //    {"fo", "ha", "hi", "xx"},
        //    {"xxx", "ho", "ha", "xx"}
        //};
        string[,] elements = 
        {
            {"z", "xw", "xz", "xs"},
            {"xxx-", "f", "hi", "xx"},
            {"xxx", "ho", "x", "xx"},
            {"xxx", "ho", "ha", "x"}
        };
        int currentSeq = 1;
        int bestSeq = int.MinValue;
        int bestSeqRow = 0;
        int bestSeqCol = 0;
        string bestSeqDirection = "";

        // horizontal sequences - left to right
        for (int row = 0; row < elements.GetLength(0); row++)
        {
            for (int col = 0; col < elements.GetLength(1) - 1; col++)
            {
                if (elements[row, col] == elements[row, col + 1])
                {
                    currentSeq++;
                }
                else
                {
                    currentSeq = 1;
                }

                if (currentSeq > bestSeq)
                {
                    bestSeq = currentSeq;
                    bestSeqRow = row;
                    bestSeqCol = col;
                    bestSeqDirection = "horizontal";
                }
            }
            currentSeq = 1;
        }

        // vertical sequences - top to down
        for (int col = 0; col < elements.GetLength(1); col++)
        {
            for (int row = 0; row < elements.GetLength(0) - 1; row++)
            {
                if (elements[row, col] == elements[row + 1, col])
                {
                    currentSeq++;
                }
                else
                {
                    currentSeq = 1;
                }

                if (currentSeq > bestSeq)
                {
                    bestSeq = currentSeq;
                    bestSeqCol = col;
                    bestSeqRow = row;
                    bestSeqDirection = "down";
                }
            }
            currentSeq = 1;
        }

        // diagonal sequences - TLBR (top left to bottom right)
        for (int i = 0; i < elements.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < elements.GetLength(1) - 1; j++)
            {
                for (int row = i, col = j; row < elements.GetLength(0) - 1 && col < elements.GetLength(1) - 1; row++, col++) // За всеки елемент от матрицата пускаме нов цикъл 
                {                                                                                                            // който да върви по диагонал и да проверява дали елементите са еднакви.
                    if (elements[row, col] == elements[row + 1, col + 1])
                    {
                        currentSeq++;
                    }
                    else
                    {
                        currentSeq = 1;
                    }

                    if (currentSeq > bestSeq )
                    {
                        bestSeq = currentSeq;
                        bestSeqRow = row;
                        bestSeqCol = col;
                        bestSeqDirection = "TLBR"; // diagonal Top Left Bottom Down
                    }
                }
                currentSeq = 1;
            }
        }

        // diagonal sequences TRBL (top right to bottom left)
        for (int i = 0; i < elements.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < elements.GetLength(1); j++)
            {
                for (int row = i, col = j; row < elements.GetLength(0) - 1 && col > 0; row++, col--)
                {
                    if (elements[row, col] == elements[row + 1, col - 1])
                    {
                        currentSeq++;
                    }
                    else
                    {
                        currentSeq = 1;
                    }

                    if (currentSeq > bestSeq)
                    {
                        bestSeq = currentSeq;
                        bestSeqRow = row;
                        bestSeqCol = col;
                        bestSeqDirection = "TRBL";
                    }
                }
                currentSeq = 1;
            }
        }

        Console.WriteLine("Best Seq Count: {0}", bestSeq);
        Console.WriteLine("Best Seq Direction: {0}", bestSeqDirection);
        Console.WriteLine("Best Seq Row: {0}", bestSeqRow);
        Console.WriteLine("Best Seq Col: {0}", bestSeqCol);

        // TODO: да направя цветно отпечатване на реда!!!
        // в момента bestRow и bestCol не записват нужните позиции


    }
}