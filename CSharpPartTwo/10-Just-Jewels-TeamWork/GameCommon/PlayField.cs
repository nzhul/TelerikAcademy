using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;

namespace GameCommon
{
    //The class present the playfield of the Game
    public class PlayField
    {
        private const char CHARBASE = '\u2588';
        private const char CHARLIGHT = '\u2591';
        private const char CHARMEDIUM = '\u2592';
        private const char CHARDARK = '\u2593';
        private const int ROW = 8;
        private const int COL = 8;
        private Box[,] boxes = new Box[ROW, COL];
        private static ConsoleColor[] colors = { ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Magenta };

        public PlayField()
        {
        }

        //Indexer for accessing the playfield content
        public Box this[int i, int j]
        {
            get
            {
                return this.boxes[i, j];
            }
            set
            {
                this.boxes[i, j] = value;
            }
        }

        public int GetLength(int ind)
        {
            if (ind == 0)
            {
                return boxes.GetLength(0);
            }
            else
            {
                return boxes.GetLength(1);
            }
        }

        //Initialize the playfield with lewels with random color
        public void InitPlayField(char symbol)
        {
            Random randColor = new Random();

            for (int i = 0; i < boxes.GetLength(0); i++)
            {
                for (int j = 0; j < boxes.GetLength(1); j++)
                {
                    Box box = new Box(i * 4 + 1, j * 4 + 1, symbol, colors[randColor.Next(0, colors.Length)]);
                    box.InitBox(symbol);
                    boxes[i, j] = box;
                }
            }
        }

        public bool isFull()
        {
            for (int y = 0; y < boxes.GetLength(0); y++)
            {
                for (int x = 0; x < boxes.GetLength(1); x++)
                {
                    if (boxes[x, y].Color == ConsoleColor.Black)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void DrawIfCursorPosition()
        {
            for (int i = 0; i < boxes.GetLength(0); i++)
            {
                for (int j = 0; j < boxes.GetLength(1); j++)
                {
                    if (boxes[i, j].isCursorPosition)
                    {
                        boxes[i, j].isCursorPosition = false;
                    }
                    boxes[i, j].DrawBox();
                }
            }
        }

        public void DrawPlayField()
        {
            for (int i = 0; i < boxes.GetLength(0); i++)
            {
                for (int j = 0; j < boxes.GetLength(1); j++)
                {
                    Console.SetCursorPosition(boxes[i, j].X + i, boxes[i, j].Y + j);
                    boxes[i, j].DrawBox();
                }
            }
        }

        public void DestroyJewels(bool[,] boxesToRemove)
        {
            Thread.Sleep(400); //TODO: Adjust Speed
            for (int y = 0; y < boxes.GetLength(0); y++)
            {
                for (int x = 0; x < boxes.GetLength(1); x++)
                {
                    if (boxesToRemove[x, y] == true)
                    {
                        this.boxes[x, y].InitBox(CHARDARK); // Dark-Shade
                        this.boxes[x, y].DrawBox();

                        Thread.Sleep(50);
                        this.boxes[x, y].InitBox(CHARMEDIUM);   // Medium-Shade
                        this.boxes[x, y].DrawBox();

                        Thread.Sleep(50);
                        this.boxes[x, y].InitBox(CHARLIGHT);   // Light-Shade
                        this.boxes[x, y].DrawBox();

                        Thread.Sleep(50);
                        boxes[x, y].Color = ConsoleColor.Black;

                        Thread.Sleep(50);
                        this.boxes[x, y].InitBox(CHARBASE); // Restore FULL BLOCK when BLACK!
                        this.boxes[x, y].DrawBox();
                    }
                }
            }
        }

    }
}
