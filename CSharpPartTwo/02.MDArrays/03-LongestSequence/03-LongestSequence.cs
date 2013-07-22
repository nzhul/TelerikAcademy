// 03. We are given a matrix of strings of size N x M. Sequences in 
//the matrix we define as sets of several neighbor elements located on the 
//same line, column or diagonal. Write a program that finds the longest sequence of equal 
//strings in the matrix. 

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
        //string[,] elements = 
        //{
        //    {"u", "z", "s", "g",},
        //    {"o", "q", "g", "v"},
        //    {"v", "g", "q", "i"},
        //    {"g", "w", "h", "p",}
        //};
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
                    bestSeqCol = col + 1;
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
                    bestSeqRow = row + 1;
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
                        bestSeqRow = row + 1;
                        bestSeqCol = col + 1;
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
                        bestSeqRow = row + 1;
                        bestSeqCol = col - 1;
                        bestSeqDirection = "TRBL";
                    }
                }
                currentSeq = 1;
            }
        }

        // Populate the bool matrix for selected cells
        bool[,] selectedCells = new bool[elements.GetLength(0), elements.GetLength(1)];
        switch (bestSeqDirection)
        {
            case "horizontal":
                for (int i = bestSeqCol; i >= Math.Abs(bestSeq - bestSeqCol - 1); i--)
                {
                    selectedCells[bestSeqRow, i] = true;
                }
                break;
            case "down":
                for (int i = bestSeqRow; i >= Math.Abs(bestSeq - bestSeqRow - 1); i--)
                {
                    selectedCells[i, bestSeqCol] = true;
                }
                break;
            case "TLBR":
                for (int row = bestSeqRow, col = bestSeqCol; row >= Math.Abs(bestSeq - bestSeqRow - 1) && col >= Math.Abs(bestSeq - bestSeqCol - 1); row--, col--) // 1 obsht cikal trqbva row-- col--
                {
                    selectedCells[row, col] = true;
                }
                break;
            case "TRBL":
                for (int row = bestSeqRow, col = bestSeqCol; row >= Math.Abs(bestSeq - bestSeqRow - 1); row--, col++) // 1 obsht cikal trqbva row-- col--
                {
                    selectedCells[row, col] = true;
                }
                break;
            default:
                break;
        }

        for (int i = 0; i < elements.GetLength(0); i++)
        {
            for (int j = 0; j < elements.GetLength(1); j++)
            {
                if (selectedCells[i, j] == true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("{0, 4} ", elements[i, j]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    // Print Without color
                    Console.Write("{0, 4} ", elements[i, j]);
                }
            }
            Console.WriteLine();
        }
    }
}