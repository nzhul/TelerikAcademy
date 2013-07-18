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
            Cell asd = new Cell(4, 3, '#', ConsoleColor.Green);
            asd.DrawCell();
        }
    }

    public class Cell
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }

        public Cell(int width, int height, char symbol, ConsoleColor color)
        {
            this.Width = width;
            this.Height = height;
            this.Symbol = symbol;
            this.Color = color;
        }

        public void DrawCell()
        {
            Console.ForegroundColor = Color;

            for (int r = 0; r < Height; r++)
            {
                Console.WriteLine(new string(this.Symbol, Width));
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}

//int[,][,] matrix = new int[8,8][,];
//[10:20:25] alexander_tri: tova trqbva da ti e sintaksira
//[10:20:44] alexander_tri: i posle obhojdash elementite ot matricata s 2 for cikula i za vsqka stoinost si suzdavash vutreshna matrica

//for (int r = 0; r < matrix.GetLength(0); r++)
//[10:21:43] alexander_tri: for c ----/-- -/--
//[10:21:57] alexander_tri: matrix[r,c] = new int[3,3];
//[10:22:06] alexander_tri: ili 4/4.. kakto iskash

//znachi pravish si 2 poleta width i heighth, moje edno za simvol i edno za cvqt.. posle override-vash .ToString() za da znae kak da se risuva i taka