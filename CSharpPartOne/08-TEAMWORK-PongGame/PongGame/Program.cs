using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PongGame
{
    class Program
    {
       static int firstPlayerPadSize = 10;
       static int secondPlayerPadSize = 10;
       static int ballPositionX = 5;
       static int ballPositionY = 5;
       static bool ballDirectionUp = true; // determines if the ball direction is up
       static bool ballDirectionRight = false;
       static int firstPlayerPosition = 0;
       static int secondPlayerPosition = 0;
       static int firstPlayerResult = 0;
       static int secondPlayerResult = 0;
       static Random randomGenerator = new Random();

        static void RemoveScrollBars() 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        static void DrawFirstPlayer()
        {
            for (int y = firstPlayerPosition; y < firstPlayerPosition + firstPlayerPadSize; y++)
            {
                PrintAtPosition(0, y, '|');
                PrintAtPosition(1, y, '|');
            }
        }

        static void PrintAtPosition(int x,int y,char symbol)
        {
 	        Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }

        static void DrawSecondPlayer()
        {
            for (int y = secondPlayerPosition; y < secondPlayerPosition + secondPlayerPadSize; y++)
            {
                PrintAtPosition(Console.BufferWidth - 1, y, '|');
                PrintAtPosition(Console.BufferWidth - 2, y, '|');
            }
        }

        static void SetInitialPositions()
        {
            firstPlayerPosition = Console.WindowHeight / 2 - firstPlayerPadSize / 2;
            secondPlayerPosition = Console.WindowHeight / 2 - secondPlayerPadSize / 2;
            SetBallAtTheMiddleOfTheGameField();
        }

        static void SetBallAtTheMiddleOfTheGameField()
        {
            ballPositionX = Console.WindowWidth / 2;
            ballPositionY = Console.BufferHeight / 2;
        }

        static void DrawBall()
        {
            PrintAtPosition(ballPositionX, ballPositionY, '0');
        }

        static void PrintResult()
        {
            Console.SetCursorPosition((Console.WindowWidth / 2) - 1, 0);
            Console.Write("{0}-{1}", firstPlayerResult, secondPlayerResult);
        }

        static void MoveFirstPlayerDown()
        {
            if (firstPlayerPosition + firstPlayerPadSize < Console.WindowHeight)
            {
                firstPlayerPosition++;
            }
        }

        static void MoveFirstPlayerUp()
        {
            if (firstPlayerPosition > 0)
            {
                firstPlayerPosition--;   
            }
        }

        static void MoveSecondPlayerDown()
        {
            if (secondPlayerPosition + secondPlayerPadSize < Console.WindowHeight)
            {
                secondPlayerPosition++;
            }
        }

        static void MoveSecondPlayerUp()
        {
            if (secondPlayerPosition > 0)
            {
                secondPlayerPosition--;
            }
        }

        static void SecondPlayerAIMove()
        {
            int randomNumber = randomGenerator.Next(0, 2);
            if (randomNumber == 0)
            {
                MoveSecondPlayerUp();
            }
            if (randomNumber == 1)
            {
                MoveSecondPlayerDown();
            }
        }

        static void MoveBall()
        {
            if (ballPositionY == 0)
            {
                ballDirectionUp = false;
            }
            if (ballPositionY == Console.WindowHeight - 1)
            {
                ballDirectionUp = true;
            }

            if (ballPositionX == Console.WindowWidth - 1)
            {
                SetBallAtTheMiddleOfTheGameField();
                ballDirectionRight = false;
                ballDirectionUp = true;
                firstPlayerResult++;
                Console.SetCursorPosition((Console.WindowWidth / 2) - 8, Console.WindowHeight / 2);
                Console.WriteLine("FIRST PLAYER WINS!");
                Console.ReadKey(); // Стопираме играта след загуба
                // TODO: second player loses
            }
            if (ballPositionX == 0)
            {
                SetBallAtTheMiddleOfTheGameField();
                ballDirectionRight = true;
                ballDirectionUp = true;
                secondPlayerResult++;
                Console.SetCursorPosition((Console.WindowWidth / 2) - 8, Console.WindowHeight / 2);
                Console.WriteLine("SECOND PLAYER WINS!");
                Console.ReadKey();// Стопираме играта след загуба
                // TODO: first player loses
            }

            if (ballPositionX < 3) // ХИЛКА PLAYER 1
            {
                if (ballPositionY >= firstPlayerPosition && ballPositionY < firstPlayerPosition + firstPlayerPadSize)
                {
                    ballDirectionRight = true;
                }
            }

            if (ballPositionX >= Console.WindowWidth - 3 - 1) // ХИЛКА PLAYER 2
            {
                if (ballPositionY >= secondPlayerPosition && ballPositionY < secondPlayerPosition + secondPlayerPadSize)
                {
                    ballDirectionRight = false;
                }
            }

            if (ballDirectionUp)
            {
                ballPositionY--;
            } 
            else
            {
                ballPositionY++;
            }
            if (ballDirectionRight)
            {
                ballPositionX++;
            }
            else
            {
                ballPositionX--;
            }
        }

        static void Main()
        {
            RemoveScrollBars();
            SetInitialPositions();
            while (true)
            {
                if (Console.KeyAvailable)
                { 
                    ConsoleKeyInfo keyinfo = Console.ReadKey();
                    if (keyinfo.Key == ConsoleKey.UpArrow)
                    {
                        MoveFirstPlayerUp();
                    }
                    if (keyinfo.Key == ConsoleKey.DownArrow)
                    {
                        MoveFirstPlayerDown();
                    }
                }
                SecondPlayerAIMove();
                MoveBall();
                Console.Clear();
                DrawFirstPlayer();
                DrawSecondPlayer();
                DrawBall();
                PrintResult();
                Thread.Sleep(30);
            }
        }
    }
}

/*                                                       
|________________________________________________________|
|                                                        |
|                       1 - 0                            |
|                                                        |
|*                                                      *|
|*                                                      *|
|*                                                      *|
|*                                                      *|
|*                                                      *|
|*                          *                           *|
|                                                        |
|                                                        |
|                                                        |
|                                                        |
|                                                        |
|________________________________________________________|_
                                                         |
*/