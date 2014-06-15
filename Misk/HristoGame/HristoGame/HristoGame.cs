using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleGame
{
    class ConsoleGame
    {
        static int score = 0;
        static int gameFieldWidth;
        static int gameFieldHeight;
        // 1 is wall; 0 is path; 2 is Player
        static byte[,] gameField;
        static int pathEndX;
        static int pathEndY;
        static int[] playerCordinates = new int[2] { 0, 0 };
        static char playerSymbol = (char)9787;
        static double gameFieldPercentWidth = 0.6;
        static double gameFieldPercentHeight = 0.9;
        static double time = 50.00;
        static bool gamePause = false;

        private static void SaveScore(int score, string name)
        {
            StreamWriter writer = new StreamWriter(@"..\..\result.txt", true);

            using (writer)
            {
                writer.WriteLine("{0}-{1}", name, score);
            }
        }



        static void Main(string[] args)
        {
            GameSettings();
            GenerateField();
            DrawGameField();
            //vertical red line
            for (int i = 0; i < gameFieldHeight; i++)
            {
                Console.SetCursorPosition(gameFieldWidth + 1, i);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine('\u2588');
            }
            //horizontal red line
            Console.SetCursorPosition(gameFieldWidth + 2, 7);
            Console.WriteLine(new string('\u2580', 27));
            //Score
            Console.SetCursorPosition(gameFieldWidth + 2, 2);
            Console.ForegroundColor = ConsoleColor.Gray;
            //Commands
            Console.SetCursorPosition(gameFieldWidth + 2, 10);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" Commands: ");
            Console.SetCursorPosition(gameFieldWidth + 2, 12);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" P - Pause");
            Console.SetCursorPosition(gameFieldWidth + 2, 14);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" E - Exit");

            ThreadStart somemethod = new ThreadStart(Music);
            Thread somethread = new Thread(somemethod);
            somethread.Start();

            while (time >= 0.1) // apply logic here
            {
                //Score
                CheckForPressedKey();
                //Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(gameFieldWidth + 2, 2);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" Score: {0}", score);//!!!!!!!!!to be implemented


                time -= 0.1;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(gameFieldWidth + 2, 0);
                Console.WriteLine(" Remaining Time: {0:0:00}", time);
                score += 40;
                Thread.Sleep(100);

            }
            //somethread.Suspend();
            Console.ResetColor();
            Console.Clear();
            Console.SetCursorPosition(30, 4);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!!GAME OVER!!!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(30, 5);
            Console.Write("Enter your name: ");
            string usersName = Console.ReadLine();
            Console.SetCursorPosition(30, 6);
            SaveScore(score, usersName);
            PrintScore();
            Environment.Exit(0);
        }

        private static void CheckForPressedKey()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (pressedKey.Key == ConsoleKey.LeftArrow && gamePause == false)
                {
                    MovePlayer(0, -1);
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow && gamePause == false)
                {
                    MovePlayer(0, 1);
                }
                else if (pressedKey.Key == ConsoleKey.UpArrow && gamePause == false)
                {
                    MovePlayer(-1, 0);
                }
                else if (pressedKey.Key == ConsoleKey.DownArrow && gamePause == false)
                {
                    MovePlayer(1, 0);
                }
                else if (pressedKey.Key == ConsoleKey.E && gamePause == false)
                {
                    Console.Clear();
                    Console.WriteLine("Good bye!");
                    Environment.Exit(0);
                }
                else if (pressedKey.Key == ConsoleKey.P)
                {
                    if (gamePause)
                    {
                        gamePause = false;
                    }
                    else
                    {
                        gamePause = true;
                        while (gamePause)
                        {
                            CheckForPressedKey();
                        }
                    }
                }
            }
        }


        private static void MovePlayer(int rowChange, int colChange)
        {
            int newRowAfterMove = playerCordinates[0] + rowChange;
            int newColAfterMove = playerCordinates[1] + colChange;
            //TODO: add if its bonus
            if (newRowAfterMove >= 0 && newColAfterMove >= 0 && newRowAfterMove < gameFieldHeight && newColAfterMove < gameFieldWidth && gameField[newRowAfterMove, newColAfterMove] == 0)
            {
                Console.SetCursorPosition(playerCordinates[1], playerCordinates[0]);
                Console.Write(" ");
                playerCordinates[0] = newRowAfterMove;
                playerCordinates[1] = newColAfterMove;
                Console.SetCursorPosition(playerCordinates[1], playerCordinates[0]);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(playerSymbol);
            }
        }

        private static void GameSettings()
        {
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            gameFieldWidth = (int)(Console.WindowWidth * gameFieldPercentWidth);
            gameFieldHeight = (int)(Console.WindowHeight * gameFieldPercentHeight);
            gameField = new byte[gameFieldHeight, gameFieldWidth];
            Console.CursorVisible = false;

        }

        private static void DrawGameField()
        {
            for (int loopRow = 0; loopRow < gameFieldHeight; loopRow++)
            {
                for (int loopCol = 0; loopCol < gameFieldWidth; loopCol++)
                {
                    bool finish = false;
                    Console.SetCursorPosition(loopCol, loopRow);
                    Console.ResetColor();
                    if (gameField[loopRow, loopCol] == 0)
                    {
                        if (loopRow == pathEndY && loopCol == pathEndX)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.White;
                            finish = true;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                    }
                    if (loopCol == 0 && loopRow == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(playerSymbol);
                    }
                    else
                    {
                        if (finish)
                        {
                            Console.Write("#");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
            }
        }

        private static void GenerateField()
        {
            bool[,] visitedGameField = new bool[gameFieldHeight, gameFieldWidth];
            Random randomPicker = new Random();

            Stack<int> rowStack = new Stack<int>();
            Stack<int> colStack = new Stack<int>();

            int currentCelRow = 0;
            int currentCelCol = 0;
            int countVisits = 1;

            while (countVisits > 0)
            {

                if (!visitedGameField[currentCelRow, currentCelCol])
                {
                    visitedGameField[currentCelRow, currentCelCol] = true;
                }
                List<int[]> neighbours = GetNeighbours(currentCelRow, currentCelCol, visitedGameField);
                if (neighbours.Count > 0)
                {
                    //Pushing random cell to the stack
                    int[] randomCell = neighbours[randomPicker.Next(0, neighbours.Count)];
                    rowStack.Push(randomCell[0]);
                    colStack.Push(randomCell[1]);
                    currentCelCol = randomCell[1];
                    currentCelRow = randomCell[0];
                    List<int[]> neighboursToMakeUnavailable = GetNeighbours(currentCelRow, currentCelCol, visitedGameField);
                    if (neighboursToMakeUnavailable.Count > 1)
                    {
                        int[] randomtoUnavailable = neighboursToMakeUnavailable[randomPicker.Next(0, neighboursToMakeUnavailable.Count)];
                        visitedGameField[randomtoUnavailable[0], randomtoUnavailable[1]] = true;
                        gameField[randomtoUnavailable[0], randomtoUnavailable[1]] = 1;
                    }
                    if (currentCelCol > (gameFieldWidth / 4) && currentCelRow > (gameFieldHeight / 4))
                    {
                        pathEndX = currentCelCol;
                        pathEndY = currentCelRow;
                    }
                }
                else if (rowStack.Count > 0)
                {
                    currentCelCol = colStack.Pop();
                    currentCelRow = rowStack.Pop();
                }
                else
                {
                    countVisits = 0;
                }
            }
        }

        private static List<int[]> GetNeighbours(int currentCelRow, int currentCelCol, bool[,] visitedGameField)
        {
            int[][] possibilities = new int[4][] { new int[2] { 0, -1 }, new int[2] { -1, 0 }, new int[2] { 0, 1 }, new int[2] { 1, 0 } };

            List<int[]> neighbours = new List<int[]>();

            foreach (var cell in possibilities)
            {
                if ((currentCelCol + cell[1]) >= 0 && (currentCelCol + cell[1]) < gameFieldWidth && (currentCelRow + cell[0]) >= 0 && (currentCelRow + cell[0]) < gameFieldHeight && !visitedGameField[currentCelRow + cell[0], currentCelCol + cell[1]])
                {
                    neighbours.Add(new int[] { currentCelRow + cell[0], currentCelCol + cell[1] });
                }
            }

            return neighbours;
        }

        private static void PrintScore()
        {
            StreamReader reader = new StreamReader(@"..\..\result.txt");

            var items = new List<KeyValuePair<string, int>>();

            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    int indexOfDash = line.IndexOf('-');
                    StringBuilder name = new StringBuilder();
                    StringBuilder scoreString = new StringBuilder();
                    for (int i = 0; i < line.Length - 1; i++)
                    {
                        if (i < indexOfDash)
                        {
                            name.Append(line[i]);
                        }
                        else
                        {
                            scoreString.Append(line[i + 1]);
                        }
                    }
                    int currentScore = int.Parse(scoreString.ToString());
                    items.Add(new KeyValuePair<string, int>(name.ToString(), currentScore));
                    line = reader.ReadLine();
                }
                var sortedList = items.OrderByDescending(x => x.Value);
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("Top Score:");
                foreach (var pair in sortedList)
                {
                    Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
                }
            }

        }

        private async static void Music()
        {
            Console.Beep(659, 125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(523, 125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(784, 125);
            Thread.Sleep(375);
            Console.Beep(392, 125);
            Thread.Sleep(375);
            Console.Beep(523, 125);
            Thread.Sleep(250);
            Console.Beep(392, 125);
            Thread.Sleep(250);
            Console.Beep(330, 125);
            Thread.Sleep(250);
            Console.Beep(440, 125);
            Thread.Sleep(125);
            Console.Beep(494, 125);
            Thread.Sleep(125);
            Console.Beep(466, 125);
            Thread.Sleep(42);
            Console.Beep(440, 125);
            Thread.Sleep(125);
            Console.Beep(392, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(784, 125);
            Thread.Sleep(125);
            Console.Beep(880, 125);
            Thread.Sleep(125);
            Console.Beep(698, 125);
            Console.Beep(784, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(523, 125);
            Thread.Sleep(125);
            Console.Beep(587, 125);
            Console.Beep(494, 125);
            Thread.Sleep(125);
            Console.Beep(523, 125);
            Thread.Sleep(250);
            Console.Beep(392, 125);
            Thread.Sleep(250);
            Console.Beep(330, 125);
            Thread.Sleep(250);
            Console.Beep(440, 125);
            Thread.Sleep(125);
            Console.Beep(494, 125);
            Thread.Sleep(125);
            Console.Beep(466, 125);
            Thread.Sleep(42);
            Console.Beep(440, 125);
            Thread.Sleep(125);
            Console.Beep(392, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(784, 125);
            Thread.Sleep(125);
            Console.Beep(880, 125);
            Thread.Sleep(125);
            Console.Beep(698, 125);
            Console.Beep(784, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(523, 125);
            Thread.Sleep(125);
            Console.Beep(587, 125);
            Console.Beep(494, 125);
            Thread.Sleep(375);
            Console.Beep(784, 125);
            Console.Beep(740, 125);
            Console.Beep(698, 125);
            Thread.Sleep(42);
            Console.Beep(622, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(415, 125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Thread.Sleep(125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Console.Beep(587, 125);
            Thread.Sleep(250);
            Console.Beep(784, 125);
            Console.Beep(740, 125);
            Console.Beep(698, 125);
            Thread.Sleep(42);
            Console.Beep(622, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(698, 125);
            Thread.Sleep(125);
            Console.Beep(698, 125);
            Console.Beep(698, 125);
            Thread.Sleep(625);
            Console.Beep(784, 125);
            Console.Beep(740, 125);
            Console.Beep(698, 125);
            Thread.Sleep(42);
            Console.Beep(622, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(415, 125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Thread.Sleep(125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Console.Beep(587, 125);
            Thread.Sleep(250);
            Console.Beep(622, 125);
            Thread.Sleep(250);
            Console.Beep(587, 125);
            Thread.Sleep(250);
            Console.Beep(523, 125);
            Thread.Sleep(1125);
            Console.Beep(784, 125);
            Console.Beep(740, 125);
            Console.Beep(698, 125);
            Thread.Sleep(42);
            Console.Beep(622, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(415, 125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Thread.Sleep(125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Console.Beep(587, 125);
            Thread.Sleep(250);
            Console.Beep(784, 125);
            Console.Beep(740, 125);
            Console.Beep(698, 125);
            Thread.Sleep(42);
            Console.Beep(622, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(698, 125);
            Thread.Sleep(125);
            Console.Beep(698, 125);
            Console.Beep(698, 125);
            Thread.Sleep(625);
            Console.Beep(784, 125);
            Console.Beep(740, 125);
            Console.Beep(698, 125);
            Thread.Sleep(42);
            Console.Beep(622, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(415, 125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Thread.Sleep(125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Console.Beep(587, 125);
            Thread.Sleep(250);
            Console.Beep(622, 125);
            Thread.Sleep(250);
            Console.Beep(587, 125);
            Thread.Sleep(250);
            Console.Beep(523, 125);
            Thread.Sleep(625);
            Music();
        }
    }
}