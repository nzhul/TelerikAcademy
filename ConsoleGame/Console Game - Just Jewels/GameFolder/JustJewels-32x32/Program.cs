using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));
            char[] symbols = new char[] { '@', '#', '$', '%', '^', '\u2588' };
            Random rand = new Random();

            for (int r = 0; r < 32; r += 4)
            {
                for (int c = 0; c < 32; c += 4)
                {
                    string colorName = colorNames[rand.Next(colorNames.Length)];
                    ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName);
                    char symbol = symbols[rand.Next(symbols.Length)];
                    DrawCell(r, c, symbol, color);
                }
            }

            Console.WriteLine();
        }

        public static void DrawCell(int startingX, int startingY, char symbol, ConsoleColor color)
        {
            Console.ForegroundColor = color;

            for (int r = startingX; r < startingX + 3; r++)
            {
                for (int c = startingY; c < startingY + 3; c++)
                {
                    Console.SetCursorPosition(r, c);
                    Console.Write(symbol);
                }
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}