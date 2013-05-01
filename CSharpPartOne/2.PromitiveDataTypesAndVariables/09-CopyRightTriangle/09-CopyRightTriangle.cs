// 9. Write a program that prints an isosceles triangle of 9 copyright symbols ©. 
// Use Windows Character Map to find the Unicode code of the © symbol. Note: the © symbol may be displayed incorrectly.


using System;
using System.Text; // We must use this library so we can use the ENCODING property

class CopyRightTriangle
{
    static void Main()
    {
        // The main idea behind this solution is to find the count of blank and filled cells in every row. Then create an string and Print it.
        Console.OutputEncoding = Encoding.Unicode;

        Console.WriteLine("Do you want to create a triangle?\nPlease enter the row count!");
        int rows = int.Parse(Console.ReadLine()); // This is the ammount of rows that we must print
        Console.WriteLine("Now Enter the Symbol that you want to use!");
        char symbol = char.Parse(Console.ReadLine());

        int cells = (rows * 2) - 1; // This is the count of cells that we must fill no mather with or without symbol
        int symbolIncrement = 1; // We need this variable to count the increment of the symbols for every next row
        int blankcount;
        int symbolcount;

        Console.WriteLine("Triangle made of {0}",symbol);
        for (int r = 0; r < rows; r++ )
        {                
            blankcount = cells - symbolIncrement; // Total Blank cells on the row
            symbolcount = cells - blankcount; // Total Symbol cells on the row

            string blankCells = new String(' ', blankcount / 2); // We Divide by 2 the total ammount of blank cells so the triangle is centered in the middle
            string fullCells = new String(symbol, symbolcount);

            Console.Write("{0}{1}", blankCells, fullCells); // We Print the blank and the full cells at once. The right side of the triangle is not fulled with blank characters but it can be if you wish: Console.Write("{0}{1}{0}", blank, full, blank);

            symbolIncrement = symbolIncrement +2; // The count of the symbols used in every next row is increased by 2
            Console.WriteLine(); // New line / Row
        }
        
    }
}

