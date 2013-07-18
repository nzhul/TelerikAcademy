using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawCell(0, 0, '#', ConsoleColor.Red);
            DrawCell(5, 0, '@', ConsoleColor.Blue); ;
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