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

      ConsoleColor[] colors = { ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Magenta };
      Random randColor = new Random();

      for (int i = 0; i < playField.GetLength(0); i++) {
        for (int j = 0; j < playField.GetLength(1); j++) {
          playField[i, j] = new Box(i * 4 + 1, j * 4 + 1, colors[randColor.Next(0, colors.Length)]);
          playField[i, j].InitBox('\u2588');
          playField[i, j].DrawBox();
        }
      }

      int cursorX = 0;
      int cursorY = 0;
      while (true) {
        if (Console.KeyAvailable) {
          ConsoleKeyInfo keyPressed = Console.ReadKey(true);
          if (keyPressed.Key == ConsoleKey.LeftArrow) {
            if (cursorX > 0) {
              cursorX--;
            }
          }
          if (keyPressed.Key == ConsoleKey.RightArrow) {
            if (cursorX < 7) {
              cursorX++;
            }
          }
          if (keyPressed.Key == ConsoleKey.UpArrow) {
            if (cursorY > 0) {
              cursorY--;
            }
          }
          if (keyPressed.Key == ConsoleKey.DownArrow) {
            if (cursorY < 7) {
              cursorY++;
            }
          }
          if (keyPressed.Key == ConsoleKey.Spacebar) {
            playField[cursorX, cursorY].isSelected = true; // isSelected
            playField[cursorX, cursorY].DrawBox();
          }
          else {
            for (int i = 0; i < playField.GetLength(0); i++) {
              for (int j = 0; j < playField.GetLength(1); j++) {
                //if (playField[i, j].isSelected) {
                //  playField[i, j].isSelected = false;
                //  playField[i, j].DrawBox();
                //}
                if (playField[i, j].isCursorPosition) {
                     playField[i, j].isCursorPosition = false;
                }
                playField[i, j].DrawBox();
              }
            }
            playField[cursorX, cursorY].isCursorPosition = true;
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
    this.isSelected = false; // 0 - not selected; 1 - isSelected; 2 - isCursor
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
    for (int i = 0; i < symbols.GetLength(0); i++) {
      for (int j = 0; j < symbols.GetLength(1); j++) {
        symbols[i, j] = symbol;
      }
    }
  }


  public void DrawBox()
  {

    Console.ForegroundColor = this.color;
    for (int i = 0; i < this.symbols.GetLength(0); i++) {
      for (int j = 0; j < this.symbols.GetLength(1); j++) {
        Console.SetCursorPosition(this.x + i, this.y + j);
        Console.Write(this.symbols[i, j]);
      }
    }

    // da go napravq s if i da izpolzvam CLEAR ' ' samo na edno mqsto
    switch (this.isSelected) {
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
      Console.ForegroundColor = ConsoleColor.Red;
      Console.SetCursorPosition(this.x + 1, this.y - 1);
      Console.Write('+');
      Console.SetCursorPosition(this.x + 3, this.y + 1);
      Console.Write('+');
      Console.SetCursorPosition(this.x + 1, this.y + 3);
      Console.Write('+');
      Console.SetCursorPosition(this.x - 1, this.y + 1);
      Console.Write('+');
      //Console.Write("WZ");
      break;
    }

    switch (isCursorPosition) {
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
