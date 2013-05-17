
using System;
using System.Collections.Generic;
using System.Threading;

class FallingRocks
{
    struct Unit
    {
        public int x;
        public int y;
        public char symbol;
        public ConsoleColor color;
    }

    static void ResetBuffer()
    {
        Console.BufferHeight = Console.WindowHeight = 30;
        Console.BufferWidth = Console.WindowWidth = 60;
    }

    static void PrintAtPosition (int x, int y, char c, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(c);
        Console.ForegroundColor = color;
    }

    static void PrintStringAtPosition(int x, int y, string text, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(text);
        Console.ForegroundColor = color;
    }
    

    

    static void Main()
    {
        ResetBuffer();
        int livesCount = 5;
        int score = 0;

        Unit Dwarf = new Unit();
        Dwarf.x = Console.WindowWidth / 2;
        Dwarf.y = Console.WindowHeight - 1;
        Dwarf.symbol = '@';
        Dwarf.color = ConsoleColor.Yellow;

        Random randomGenerator = new Random();
        List<Unit> Rocks = new List<Unit>();

        while (true)
        {
            {
                // ADD ROCK
                Unit newRock = new Unit();
                newRock.color = ConsoleColor.Green; // Must be Random
                newRock.x = randomGenerator.Next(0, Console.WindowWidth - 1);
                newRock.y = 5; // 5 is the indent needed for displaying the score
                newRock.symbol = '#'; // Must be Random
                Rocks.Add(newRock);
                // ADD ROCK END
            }

            if (Console.KeyAvailable) // we check if there is any key pressed and only then we make action. That way the program keep working without waiting for user input
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable) { Console.ReadKey(true); } // We use that to clear the memory from remembering the next pressed key
                if (pressedKey.Key == ConsoleKey.LeftArrow) // Move Dwarf
                {
                    if (Dwarf.x - 1 >= 0)
                    {
                        Dwarf.x--;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (Dwarf.x < Console.WindowWidth - 2) // There is BUG in the last frame at right
                    {
                        Dwarf.x++;
                    }
                }
            }

            List<Unit> newList = new List<Unit>();
            for (int i = 0; i < Rocks.Count; i++)// Move Rocks
            {
                Unit oldRock = Rocks[i];
                Unit newRock = new Unit();
                newRock.x = oldRock.x;
                newRock.y = oldRock.y + 1;
                newRock.symbol = oldRock.symbol;
                newRock.color = oldRock.color;
                if (newRock.y == Dwarf.y && newRock.x == Dwarf.x) // Collision Detection
                {
                    livesCount--;
                    Rocks.Clear();
                    if (livesCount <= 0)
                    {
                        PrintStringAtPosition(43, 2, "GAME OVER", ConsoleColor.Red);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }

                }
                if (newRock.y < Console.WindowHeight) // we add the rock to the list only if it is on the playField!
                {
                    newList.Add(newRock);
                    score++;
                }
            }
            Rocks = newList;
            // Collision detection
            Console.Clear();
            // ReDraw All
            PrintAtPosition(Dwarf.x, Dwarf.y, Dwarf.symbol, Dwarf.color); // Draw the player
            foreach (var rock in Rocks)
            {
                PrintAtPosition(rock.x, rock.y, rock.symbol, rock.color);
            }
            // Show Score
            for (int i = 0; i < Console.WindowWidth; i++) // Score Divider
            {
                PrintAtPosition(i, 5, '-', ConsoleColor.Gray);
            }
            PrintStringAtPosition(10, 2, "Lives: " + livesCount);
            PrintStringAtPosition(20, 2, "Score: " + score);
            Thread.Sleep(150);
        }
    }
}
