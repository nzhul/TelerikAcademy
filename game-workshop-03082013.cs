using System;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        public static bool selectionExist = false;
        public static int[] lastSelection = { -1, -1 };
        public static int cursorX = 0;
        public static int cursorY = 0;
        public static int score = 25;

        static void Main(string[] args)
        {
            Settings();
            //ScoreField();

            Box[,] playField = InitPlayField();

            bool[,] boxesToRemove = FindBoxesForRemove(playField);
            DestroyJewels(playField, boxesToRemove);
            TestMatrix(boxesToRemove);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                    if (keyPressed.Key == ConsoleKey.LeftArrow)
                    {
                        if (cursorX > 0)
                        {
                            cursorX--;
                        }
                        if (selectionExist)
                        {
                            Swap(playField[lastSelection[0], lastSelection[1]], playField[cursorX, cursorY], playField);
                    }
                    }
                    if (keyPressed.Key == ConsoleKey.RightArrow)
                    {
                        if (cursorX < 7)
                        {
                            cursorX++;
                        }
                        if (selectionExist)
                        {
                            Swap(playField[lastSelection[0], lastSelection[1]], playField[cursorX, cursorY], playField);
                    }
                    }
                    if (keyPressed.Key == ConsoleKey.UpArrow)
                    {
                        if (cursorY > 0)
                        {
                            cursorY--;
                        }
                        if (selectionExist)
                        {
                            Swap(playField[lastSelection[0], lastSelection[1]], playField[cursorX, cursorY], playField);
                    }
                    }
                    if (keyPressed.Key == ConsoleKey.DownArrow)
                    {
                        if (cursorY < 7)
                        {
                            cursorY++;
                        }
                        if (selectionExist)
                        {
                            Swap(playField[lastSelection[0], lastSelection[1]], playField[cursorX, cursorY], playField);
                    }
                    }
                    if (keyPressed.Key == ConsoleKey.Spacebar)
                    {
                        playField[cursorX, cursorY].isSelected = true; // isSelected
                        playField[cursorX, cursorY].DrawBox();
                        selectionExist = true;
                        lastSelection[0] = cursorX;
                        lastSelection[1] = cursorY;
                    }
                    else
                    {
                        for (int i = 0; i < playField.GetLength(0); i++)
                        {
                            for (int j = 0; j < playField.GetLength(1); j++)
                            {
                                if (playField[i, j].isCursorPosition)
                                {
                                    playField[i, j].isCursorPosition = false;
                                }
                                playField[i, j].DrawBox();
                            }
                        }
                        playField[cursorX, cursorY].isCursorPosition = true;
                        playField[cursorX, cursorY].DrawBox();
                    }
                    // ScoreField(); - Here we can update the score field
                }
            }
        }

        private static void DestroyJewels(Box[,] playField, bool[,] boxesToRemove)
        {
            Thread.Sleep(500); //TODO: Adjust Speed
            for (int y = 0; y < playField.GetLength(0); y++)
            {
                for (int x = 0; x < playField.GetLength(1); x++)
                {
                    if (boxesToRemove[x, y] == true)
                    {
                        playField[x, y].color = ConsoleColor.Black;
                        Thread.Sleep(200); //TODO: Adjust Speed
                        playField[x, y].DrawBox();
                    }
                }
            }
        }

        private static void TestMatrix(bool[,] boxesToRemove)
        {
            Console.SetCursorPosition(0, 35);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < boxesToRemove.GetLength(0); i++)
            {
                for (int j = 0; j < boxesToRemove.GetLength(1); j++)
                {
                    if (boxesToRemove[j, i] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("T ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write("F ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static Box[,] InitPlayField()
        {
            Box[,] playField = new Box[8, 8];

            ConsoleColor[] colors = { ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Magenta };
            Random randColor = new Random();

            for (int i = 0; i < playField.GetLength(0); i++)
            {
                for (int j = 0; j < playField.GetLength(1); j++)
                {
                    playField[i, j] = new Box(i * 4 + 1, j * 4 + 1, colors[randColor.Next(0, colors.Length)]);
                    playField[i, j].InitBox('\u2588'); // Dark-Shade: \u2593; MediumShade: \u2592; LightShade: \u2591
                    playField[i, j].DrawBox();
                }
            }
            return playField;
        }

        private static void ScoreField()
        {
            Console.SetCursorPosition(0, 33);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("---------------------------------");
            Console.SetCursorPosition(1, 35);
            Console.Write("Score: {0}", score);
            Console.SetCursorPosition(20, 35);
        }

        private static void Settings()
        {
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight = 60; // 38 default
            Console.BufferWidth = Console.WindowWidth = 33;
            Console.Title = "Just Jewels";
        }



        static void Swap(Box first, Box second, Box[,] playField)
        {
            int tempX = first.x;
            int tempY = first.y;
            first.x = second.x;
            first.y = second.y;
            second.x = tempX;
            second.y = tempY;

            selectionExist = false;
            first.isSelected = false;
            second.isSelected = false;
            first.DrawBox();
            second.DrawBox();

            Box tempJewel = playField[lastSelection[0], lastSelection[1]];
            playField[lastSelection[0], lastSelection[1]] = playField[cursorX, cursorY];
            playField[cursorX, cursorY] = tempJewel;
        }

        public static bool[,] FindBoxesForRemove(Box[,] playField)
        {
            int currentSeq = 1;
            int bestSeq = int.MinValue;
            int bestSeqX = 0;
            int bestSeqY = 0;
            int bestSeqDirection = 1; // 1 = horizontal; 2 = right
            bool finishFlag = false;
            bool[,] selectedCells = new bool[playField.GetLength(0), playField.GetLength(1)];

            do
            {
                // horizontal sequences - left to right
                for (int x = 0; x < playField.GetLength(0); x++)
                {
                    for (int y = 0; y < playField.GetLength(1) - 1; y++)
                    {
                        // Ако цветовете им съвпадат и не са били селектирани вече - ги добавяме в редицата
                        if (playField[x, y].color == playField[x, y + 1].color && selectedCells[x, y] == false)
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
                            bestSeqX = x;
                            bestSeqY = y + 1;
                            bestSeqDirection = 1; // 1 = horizontal
                        }
                    }
                    currentSeq = 1;
                }

                // vertical sequences - top to down
                for (int y = 0; y < playField.GetLength(1); y++)
                {
                    for (int x = 0; x < playField.GetLength(0) - 1; x++)
                    {
                        if (playField[x, y].color == playField[x + 1, y].color && selectedCells[x, y] == false)
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
                            bestSeqY = y;
                            bestSeqX = x + 1;
                            bestSeqDirection = 2; // 2 = down
                        }
                    }
                    currentSeq = 1;
                }

                // Populate the bool matrix for selected cells only when the sequence length is longer than 2
                if (bestSeq >= 3)
                {
                    switch (bestSeqDirection)
                    {
                        case 1: // 1 = horizontal
                            for (int i = bestSeqY; i >= Math.Abs(bestSeq - bestSeqY - 1); i--)
                            {
                                selectedCells[bestSeqX, i] = true;
                            }
                            break;
                        case 2: // 2 = down
                            for (int i = bestSeqX; i >= Math.Abs(bestSeq - bestSeqX - 1); i--)
                            {
                                selectedCells[i, bestSeqY] = true;
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    finishFlag = true;
                }
                currentSeq = 1;
                bestSeq = int.MinValue;
                bestSeqX = 0;
                bestSeqY = 0;
                bestSeqDirection = 1; // 1 = horizontal; 2 = right
            } while (finishFlag == false);
            return selectedCells;
        }

      }
 }

class Box
{
    public Box(int x, int y, ConsoleColor color)
    {
        this.x = x;
        this.y = y;
        this.color = color;
        this.isSelected = false;
        this.isCursorPosition = false;
    }

    public int x;
    public int y;
    public ConsoleColor color;
    public bool isSelected;
    public bool isCursorPosition;
    char[,] symbols = new char[3, 3];

    public void InitBox(char symbol)
    {
        for (int i = 0; i < symbols.GetLength(0); i++)
        {
            for (int j = 0; j < symbols.GetLength(1); j++)
            {
                symbols[i, j] = symbol;
            }
        }
    }


    public void DrawBox()
    {

        Console.ForegroundColor = this.color;
        for (int i = 0; i < this.symbols.GetLength(0); i++)
        {
            for (int j = 0; j < this.symbols.GetLength(1); j++)
            {
                Console.SetCursorPosition(this.x + i, this.y + j);
                Console.Write(this.symbols[i, j]);
            }
        }

        switch (this.isSelected)
        {
            case false: // Not Selected 
                Console.SetCursorPosition(this.x + 1, this.y - 1);
                Console.Write(' ');
                Console.SetCursorPosition(this.x + 3, this.y + 1);
                Console.Write(' ');
                Console.SetCursorPosition(this.x + 3, this.y);
                Console.Write(' ');
                Console.SetCursorPosition(this.x + 3, this.y + 2);
                Console.Write(' ');
                Console.SetCursorPosition(this.x + 1, this.y + 3);
                Console.Write(' ');
                Console.SetCursorPosition(this.x - 1, this.y + 1);
                Console.Write(' ');
                Console.SetCursorPosition(this.x - 1, this.y);
                Console.Write(' ');
                Console.SetCursorPosition(this.x - 1, this.y + 2);
                Console.Write(' ');
                break;
            case true: // isSelected
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(this.x + 3, this.y + 1);
                Console.Write('|');
                Console.SetCursorPosition(this.x + 3, this.y);
                Console.Write('|');
                Console.SetCursorPosition(this.x + 3, this.y + 2);
                Console.Write('|');
                Console.SetCursorPosition(this.x - 1, this.y + 1);
                Console.Write('|');
                Console.SetCursorPosition(this.x - 1, this.y);
                Console.Write('|');
                Console.SetCursorPosition(this.x - 1, this.y + 2);
                Console.Write('|');
                break;
        }

        switch (isCursorPosition)
        {
            case false: // Not Selected
                Console.SetCursorPosition(this.x - 1, this.y - 1);
                Console.Write(' ');
                Console.SetCursorPosition(this.x + 3, this.y - 1);
                Console.Write(' ');
                Console.SetCursorPosition(this.x + 3, this.y + 3);
                Console.Write(' ');
                Console.SetCursorPosition(this.x - 1, this.y + 3);
                Console.Write(' ');
                break;
            case true: // isSelected
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(this.x - 1, this.y - 1);
                Console.Write('\u250c');
                Console.SetCursorPosition(this.x + 3, this.y - 1);
                Console.Write('\u2510');
                Console.SetCursorPosition(this.x + 3, this.y + 3);
                Console.Write('\u2518');
                Console.SetCursorPosition(this.x - 1, this.y + 3);
                Console.Write('\u2514');
                break;
        }
    }
}
