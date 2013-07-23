using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight = 50;
            Console.BufferWidth = Console.WindowWidth = 60;

            Box[,] playField = new Box[8, 8];

            for (int i = 0; i < playField.GetLength(0); i++)
            {
                for (int j = 0; j < playField.GetLength(1); j++)
                {
                    playField[i, j] = new Box(i * 4 + 1, j * 4 + 1, ConsoleColor.Yellow);
                    playField[i, j].InitBox('\u2588');
                    playField[i, j].DrawBox();
                }
            }

            int cursorX = 0;
            int cursorY = 0;
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
                    }
                    if (keyPressed.Key == ConsoleKey.RightArrow)
                    {
                        if (cursorX < 7)
                        {
                            cursorX++;
                        }
                    }
                    if (keyPressed.Key == ConsoleKey.UpArrow)
                    {
                        if (cursorY > 0)
                        {
                            cursorY--;
                        }
                    }
                    if (keyPressed.Key == ConsoleKey.DownArrow)
                    {
                        if (cursorY < 7)
                        {
                            cursorY++;
                        }
                    }
                    if (keyPressed.Key == ConsoleKey.Spacebar)
                    {
                        playField[cursorX, cursorY].boxState = 1; // isSelected
                        playField[cursorX, cursorY].DrawBox();
                    }
                    else
                    {
                        for (int i = 0; i < playField.GetLength(0); i++)
                        {
                            for (int j = 0; j < playField.GetLength(1); j++)
                            {
                                if (playField[i, j].boxState != 1)
                                {
                                    playField[i, j].boxState = 0;
                                }
                                playField[i, j].DrawBox();
                            }
                        }
                        playField[cursorX, cursorY].boxState = 2;
                        playField[cursorX, cursorY].DrawBox();
                    }




                }

                
            }
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
        this.boxState = 0; // 0 - not selected; 1 - isSelected; 2 - isCursor
    }

    public int x;
    public int y;
    public ConsoleColor color;
    public byte boxState;
    char[,] symbols = new char[3,3] ;

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

        switch (boxState)
        {
            case 0: // Not Selected
                Console.SetCursorPosition(this.x - 1, this.y - 1);
                Console.Write(' ');
                Console.SetCursorPosition(this.x + 3, this.y - 1);
                Console.Write(' ');
                Console.SetCursorPosition(this.x + 3, this.y + 3);
                Console.Write(' ');
                Console.SetCursorPosition(this.x - 1, this.y + 3);
                Console.Write(' ');
                break;
            case 1: // isSelected
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(this.x - 1, this.y - 1);
                Console.Write('\u250c');
                Console.SetCursorPosition(this.x + 3, this.y - 1);
                Console.Write('\u2510');
                Console.SetCursorPosition(this.x + 3, this.y + 3);
                Console.Write('\u2518');
                Console.SetCursorPosition(this.x - 1, this.y + 3);
                Console.Write('\u2514');
                break;
            case 2: // isCursor
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

        //if (isCursor)
        //{
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.SetCursorPosition(this.x - 1, this.y - 1);
        //    Console.Write('\u250c');
        //    Console.SetCursorPosition(this.x + 3, this.y - 1);
        //    Console.Write('\u2510');
        //    Console.SetCursorPosition(this.x + 3, this.y + 3);
        //    Console.Write('\u2518');
        //    Console.SetCursorPosition(this.x - 1, this.y + 3);
        //    Console.Write('\u2514');
        //}
        //else
        //{
        //    Console.SetCursorPosition(this.x - 1, this.y - 1);
        //    Console.Write(' ');
        //    Console.SetCursorPosition(this.x + 3, this.y - 1);
        //    Console.Write(' ');
        //    Console.SetCursorPosition(this.x + 3, this.y + 3);
        //    Console.Write(' ');
        //    Console.SetCursorPosition(this.x - 1, this.y + 3);
        //    Console.Write(' ');
        //}

        //if (isSelected)
        //{
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    Console.SetCursorPosition(this.x - 1, this.y - 1);
        //    Console.Write('\u250c');
        //    Console.SetCursorPosition(this.x + 3, this.y - 1);
        //    Console.Write('\u2510');
        //    Console.SetCursorPosition(this.x + 3, this.y + 3);
        //    Console.Write('\u2518');
        //    Console.SetCursorPosition(this.x - 1, this.y + 3);
        //    Console.Write('\u2514');
        //}
        //else
        //{
        //    Console.SetCursorPosition(this.x - 1, this.y - 1);
        //    Console.Write(' ');
        //    Console.SetCursorPosition(this.x + 3, this.y - 1);
        //    Console.Write(' ');
        //    Console.SetCursorPosition(this.x + 3, this.y + 3);
        //    Console.Write(' ');
        //    Console.SetCursorPosition(this.x - 1, this.y + 3);
        //    Console.Write(' ');
        //}
    }

    // Selected
}
