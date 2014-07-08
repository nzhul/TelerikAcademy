using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCommon
{
    //The class present a jewel from the play field
    public class Box
    {
        const char SYMBOL = '\u2588';
        private int x;
        private int y;
        char symbol;
        private ConsoleColor color;

        char[,] symbols = new char[3, 3];
        public bool isSelected;
        public bool isCursorPosition;

        public int X
        {
            get
            {
                if (x < 0)
                {
                    throw new GameExceptions("The Box 'X' coordinate is negative! It must be non-negative!");
                }
                return x;
            }
            set
            {
                if (x < 0)
                {
                    throw new GameExceptions("The Box 'X' coordinate is negative! It must be non-negative!");
                }
                x = value;
            }
        }
        public int Y
        {
            get
            {
                if (y < 0)
                {
                    throw new GameExceptions("The Box 'Y' coordinate is negative! It must be non-negative!");
                }
                return y;
            }
            set { y = value; }
        }

        public char Symbol
        {
            get { return symbol; }
            set
            {
                if (!Char.IsSymbol(value))
                {
                    throw new GameExceptions("The Box symbol is not a valid symbol!");
                }
                symbol = value;
            }
        }

        public ConsoleColor Color
        {
            get { return color; }
            set { color = value; }
        }

        public Box()
            : this(0, 0, SYMBOL, ConsoleColor.Black)
        {
        }

        public Box(int x, int y, char symbol, ConsoleColor color)
            : this(x, y, symbol, color, false, false)
        {
        }

        public Box(int x, int y, char symbol, ConsoleColor color, bool isSelected, bool isCursorPosition)
        {
            this.X = x;
            this.Y = y;
            this.Symbol = symbol;
            this.Color = color;
            this.isSelected = isSelected;
            this.isCursorPosition = isCursorPosition;
        }

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
                    Console.Write(symbols[i, j]);
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
}
