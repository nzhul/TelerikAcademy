using System;
using System.Threading;
using System.IO;
using GameCommon;
using System.Timers;
using System.Windows.Forms;
using System.Security;

namespace JustJewels
{
    class JustJewels
    {
        private const int PLAYFIELDWIDTH = 33;
        private const int PLAYFIELDHIGHT = 46;
        private const int SCOREFIELDWIDTH = 0;
        private const int SCOREFIELDHIGHT = 33;
        private const int PROGRESSBARWIDTH = 0;
        private const int PROGRESSBARHIGHT = 45;
        private const int MAXSCORE = 500;
        private const int TOPSCORECOUNT = 5;

        private const char CHARBASE = '\u2588';
        private const char CHARLIGHT = '\u2591';
        private const char CHARMEDIUM = '\u2592';
        private const char CHARDARK = '\u2593';

        private const string HIGHSCOREFILEPATH = @"..\..\HIGHSCOREs.txt";
        private const string GAMEFILEPATH = @"..\..\GAME.txt";

        private static bool selectionExist = false;
        private static int[] lastSelection = { -1, -1 };
        private static int cursorX = 0;
        private static int cursorY = 0;
        private static ConsoleColor[] colors = { ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Magenta };
        private static int escapeFlag = 0;
        private static PlayField playField = new PlayField();
        private static Player player = new Player();
        private static bool gameoverFlag = false;
        private static bool topscoreFlag = false;
        private static bool soundflag = false;


        static void Main()
        {
            try
            {
                //Call the Main menu
                Menu();
            }
            catch (ArgumentNullException) //The File is empty!No Game is saved!
            {
                Console.WriteLine("The Game File is empty! No Game is saved!");
                Thread.Sleep(3000);
            }
            catch (ArgumentException) //path is a zero-length string, contains only white space, or contains one or more invalid characters as defined by InvalidPathChars. 
            {
                Console.WriteLine("Game File Path is a zero-length string, contains only white space or invalid characters!");
                Thread.Sleep(3000);
            }

            catch (PathTooLongException) //The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. 
            {
                Console.WriteLine("The specified Game File path, file name, or both exceed the system-defined maximum length!");
                Thread.Sleep(3000);
            }
            catch (FileNotFoundException ex) //The file specified in path was not found. 
            {
                Console.WriteLine("The file:\n{0}\nwas not found!", ex.FileName);
                Thread.Sleep(3000);
            }
            catch (DirectoryNotFoundException) //The specified path is invalid (for example, it is on an unmapped drive). 
            {
                Console.WriteLine("The specified Game File Path is invalid!");
                Thread.Sleep(3000);
            }

            catch (IOException) //An I/O error occurred while opening the file.
            {
                Console.WriteLine("An I/O error occurred while opening the Game File!");
                Thread.Sleep(3000);
            }

            catch (UnauthorizedAccessException) //An I/O error occurred while opening the file.
            {
                Console.WriteLine("You don't have permissions to read/write in the Game File! or\nReadAllText-only Game File! or\nThis is a directory!");
                Thread.Sleep(3000);
            }
            catch (GameExceptions gex)
            {
                Console.WriteLine("Error:\n{0}", gex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unhandld Error:\n{0}.\n\nStackTrace: {1}", ex.Message, ex.StackTrace);
                Thread.Sleep(5000);
            }

        }

        //When the max scores are reached, show message and call the Main Menu
        private static void GameOver()
        {
            Methods.SaveHighestScores(HIGHSCOREFILEPATH, player, TOPSCORECOUNT);
            player = new Player();
            gameoverFlag = true;
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 3 - 2, Console.WindowHeight / 3);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LEVEL COMPLETE!");
            Console.SetCursorPosition(Console.WindowWidth / 11 - 1, Console.WindowHeight / 3 + 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You've reached the max score!");
            Thread.Sleep(2000);
            Console.CursorVisible = false;
            Menu();
        }

        private static void Engine()
        {

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            {
                                if ((cursorX > 0) && (!topscoreFlag))
                                {
                                    cursorX--;
                                    if (soundflag) { Console.Beep(400, 100); }
                                    ChangeCursorPosition();
                                }
                            }; break;
                        case ConsoleKey.RightArrow:
                            {
                                if ((cursorX < 7) && (!topscoreFlag))
                                {
                                    cursorX++;
                                    if (soundflag) { Console.Beep(400, 100); }
                                    ChangeCursorPosition();
                                }
                            }; break;
                        case ConsoleKey.UpArrow:
                            {
                                if ((cursorY > 0) && (!topscoreFlag))
                                {
                                    cursorY--;
                                    if (soundflag) { Console.Beep(400, 100); }
                                    ChangeCursorPosition();
                                }
                            }; break;
                        case ConsoleKey.DownArrow:
                            {
                                if ((cursorY < 7) && (!topscoreFlag))
                                {
                                    cursorY++;
                                    if (soundflag) { Console.Beep(400, 100); }
                                    ChangeCursorPosition();
                                }
                            }; break;
                        case ConsoleKey.Spacebar:
                            {
                                if (!topscoreFlag)
                                {
                                    if (soundflag) { Console.Beep(400, 100); }
                                    playField[cursorX, cursorY].isSelected = true;
                                    playField[cursorX, cursorY].DrawBox();
                                    selectionExist = true;
                                    lastSelection[0] = cursorX;
                                    lastSelection[1] = cursorY;
                                }
                            }; break;
                        case ConsoleKey.F1:
                            {
                                soundflag = !soundflag;
                                Methods.VisualizeSound(soundflag);
                            }; break;
                        //Call the Main Menu
                        case ConsoleKey.Escape:
                            {
                                topscoreFlag = false;
                                Menu();
                            }; break;
                    }
                }
            }
        }

        public static void ChangeCursorPosition()
        {
            if (selectionExist)
            {
                DoSwap(cursorX, cursorY);
            }

            playField.DrawIfCursorPosition();

            playField[cursorX, cursorY].isCursorPosition = true;
            playField[cursorX, cursorY].DrawBox();

            //Update the score field     
            Methods.ScoreField(SCOREFIELDWIDTH, SCOREFIELDHIGHT, player);

            //Draw a progress bar showing how near is the maximum score                                                        
            Methods.DrawProgress(player.Score, MAXSCORE, PROGRESSBARWIDTH, PROGRESSBARHIGHT);

            //If maximum score has reached, show game over and go to the Main Menu
            if (player.Score >= MAXSCORE)
            {
                GameOver();
            }
        }

        public static void DoSwap(int cursorX, int cursorY)
        {
            Swap(playField[lastSelection[0], lastSelection[1]], playField[cursorX, cursorY]);
            // If after the swap we don't have new combination - we swap again the jewels and by that - restore the previous positions
            // TODO: Here we can add some animation, because at the moment it looks like - there is no action at all            
            if (Methods.isEmpty(FindBoxesForRemove()))
            {
                Swap(playField[lastSelection[0], lastSelection[1]], playField[cursorX, cursorY]);
            }
            // If we have new combination - Run the FallDownAndGenerateNewJewels() method
            else
            {
                playField[cursorX, cursorY].isCursorPosition = false;
                playField[cursorX, cursorY].DrawBox();
                FallDownAndGenerateNewJewels();
            }
        }

        static void Swap(Box first, Box second)
        {
            int tempX = first.X;
            int tempY = first.Y;
            first.X = second.X;
            first.Y = second.Y;
            second.X = tempX;
            second.Y = tempY;

            selectionExist = false;
            first.isSelected = false;
            second.isSelected = false;
            first.DrawBox();
            second.DrawBox();

            Box tempJewel = playField[lastSelection[0], lastSelection[1]];
            playField[lastSelection[0], lastSelection[1]] = playField[cursorX, cursorY];
            playField[cursorX, cursorY] = tempJewel;
        }

        private static void FallDownAndGenerateNewJewels()
        {
            Random randColor = new Random();
            bool[,] boxesToRemove = new bool[8, 8];
            do
            {
                boxesToRemove = FindBoxesForRemove();

                // If there is anything in the bool matrix - we count the elements in it and then add 10 points for each jewel
                // We can implement bonus score system that can multiply the points if we have 6, 9 13 and so on - destroyed jewels.

                int jewelCount = Methods.GetBoxesToRemove(boxesToRemove);
                int bonus = 1;
                bonus = jewelCount / 30; // We may get exeption if bonus variable become zero (0)                
                player.Score += jewelCount * bonus;
                Methods.DisplayCombo(bonus, 4, 38);
                Methods.ScoreField(SCOREFIELDWIDTH, SCOREFIELDHIGHT, player);

                //Draw a progress bar showing how near is the maximum score                                                        
                Methods.DrawProgress(player.Score, MAXSCORE, PROGRESSBARWIDTH, PROGRESSBARHIGHT);

                playField.DestroyJewels(boxesToRemove);

                while (!playField.isFull())
                {
                    for (int y = playField.GetLength(0) - 2; y >= 0; y--) // very Important to be GetLength(0) - 2 becouse we dont want to check the last ROW!
                    {
                        if (soundflag) { Console.Beep(200, 30); }
                        for (int x = playField.GetLength(1) - 1; x >= 0; x--)
                        {
                            // If the current Jewels is not BLACK and the jewel beneath it is BLACK - DoSwap();
                            if (playField[x, y].Color != ConsoleColor.Black && playField[x, y + 1].Color == ConsoleColor.Black)
                            {
                                Thread.Sleep(50);
                                lastSelection[0] = x;
                                lastSelection[1] = y;
                                cursorX = x;
                                cursorY = y + 1;
                                Swap(playField[x, y], playField[x, y + 1]);
                            }
                            // If we are on the first row (y == 0) and the jewel is Black - we change his color and redraw it.
                            if (y == 0 && playField[x, y].Color == ConsoleColor.Black)
                            {
                                playField[x, y].Color = colors[randColor.Next(0, colors.Length)];
                                Thread.Sleep(30);
                                playField[x, y].InitBox(CHARLIGHT); // Light-Shade
                                playField[x, y].DrawBox();
                                Thread.Sleep(50);
                                playField[x, y].InitBox(CHARMEDIUM); // Medium-Shade
                                playField[x, y].DrawBox();
                                Thread.Sleep(50);
                                playField[x, y].InitBox(CHARDARK); // Dark-Shade 
                                playField[x, y].DrawBox();
                                Thread.Sleep(50);
                                playField[x, y].InitBox(CHARBASE); // Restore FULL BLOCK when BLACK!
                                playField[x, y].DrawBox();
                            }
                        }
                    }
                }
                // Set the bool matrix to False
                Array.Clear(boxesToRemove, 0, boxesToRemove.Length);

                //Draw a progress bar showing how near is the maximum score                
                Methods.DrawProgress(player.Score, MAXSCORE, PROGRESSBARWIDTH, PROGRESSBARHIGHT);

                //If maximum score has reached, show game over and go to the Main Menu
                if (player.Score >= MAXSCORE)
                {
                    GameOver();
                }

            } while (!Methods.isEmpty(FindBoxesForRemove()));
        }

        public static bool[,] FindBoxesForRemove()
        {
            int currentSeq = 1;
            int bestSeq = int.MinValue;
            int bestSeqX = 0;
            int bestSeqY = 0;
            int bestSeqDirection = 1; // 1 = horizontal; 2 = right
            bool finishFlag = false;
            bool[,] selectedCells = new bool[playField.GetLength(0), playField.GetLength(1)];

            do
            {
                // horizontal sequences - left to right
                for (int x = 0; x < playField.GetLength(0); x++)
                {
                    for (int y = 0; y < playField.GetLength(1) - 1; y++)
                    {
                        // If the colors of the jewels are equal and they haven't been selected yet - we add them to the sequence
                        if (playField[x, y].Color == playField[x, y + 1].Color && selectedCells[x, y] == false)
                        {
                            currentSeq++;
                        }
                        else
                        {
                            currentSeq = 1;
                        }

                        if (currentSeq > bestSeq)
                        {
                            bestSeq = currentSeq;
                            bestSeqX = x;
                            bestSeqY = y + 1;
                            bestSeqDirection = 1; // 1 = horizontal
                        }
                    }
                    currentSeq = 1;
                }

                // vertical sequences - top to down
                for (int y = 0; y < playField.GetLength(1); y++)
                {
                    for (int x = 0; x < playField.GetLength(0) - 1; x++)
                    {
                        if (playField[x, y].Color == playField[x + 1, y].Color && selectedCells[x, y] == false)
                        {
                            currentSeq++;
                        }
                        else
                        {
                            currentSeq = 1;
                        }

                        if (currentSeq > bestSeq)
                        {
                            bestSeq = currentSeq;
                            bestSeqY = y;
                            bestSeqX = x + 1;
                            bestSeqDirection = 2; // 2 = down
                        }
                    }
                    currentSeq = 1;
                }

                // Populate the bool matrix for selected cells only when the sequence length is longer than 2
                if (bestSeq >= 3)
                {
                    switch (bestSeqDirection)
                    {
                        case 1: // 1 = horizontal
                            for (int i = bestSeqY; i >= Math.Abs(bestSeq - bestSeqY - 1); i--)
                            {
                                selectedCells[bestSeqX, i] = true;
                            }
                            break;
                        case 2: // 2 = down
                            for (int i = bestSeqX; i >= Math.Abs(bestSeq - bestSeqX - 1); i--)
                            {
                                selectedCells[i, bestSeqY] = true;
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    finishFlag = true;
                }
                currentSeq = 1;
                bestSeq = int.MinValue;
                bestSeqX = 0;
                bestSeqY = 0;
                bestSeqDirection = 1; // 1 = horizontal; 2 = right
            } while (finishFlag == false);

            return selectedCells;
        }

        //The Main Menu of the Game       
        private static void Menu()
        {
            Methods.Settings(PLAYFIELDWIDTH, PLAYFIELDHIGHT);
            Methods.DrawMenu(player.Name, gameoverFlag);
            bool isCommand = false;

            while (!isCommand)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                switch (keyPressed.Key)
                {
                    //Load a new game
                    case ConsoleKey.N:
                        {
                            gameoverFlag = false;
                            player = new Player(Methods.LoadPlayer(), 0);
                            Console.Clear();
                            Console.SetWindowSize(PLAYFIELDWIDTH + 7, PLAYFIELDHIGHT);
                            Console.SetBufferSize(PLAYFIELDWIDTH + 7, PLAYFIELDHIGHT);
                            playField = new PlayField();
                            playField.InitPlayField(CHARBASE);
                            playField.DrawPlayField();
                            Methods.Settings(PLAYFIELDWIDTH, PLAYFIELDHIGHT);
                            Methods.VisualizeSound(soundflag);
                            FallDownAndGenerateNewJewels();
                            Methods.ScoreField(SCOREFIELDWIDTH, SCOREFIELDHIGHT, player);

                            //Draw a progress bar showing how near is the maximum score                                                        
                            Methods.DrawProgress(player.Score, MAXSCORE, PROGRESSBARWIDTH, PROGRESSBARHIGHT);

                            escapeFlag = 0;
                            Engine();
                            isCommand = true;
                        } break;

                    //Return to the game or go to the Menu
                    case ConsoleKey.Escape:
                        {
                            if ((player.Name != "") && !gameoverFlag)
                            {
                                if (escapeFlag == 0)
                                {
                                    Console.Clear();
                                    Console.SetWindowSize(PLAYFIELDWIDTH + 7, PLAYFIELDHIGHT);
                                    Console.SetBufferSize(PLAYFIELDWIDTH + 7, PLAYFIELDHIGHT);
                                    playField.DrawPlayField();
                                    Methods.Settings(PLAYFIELDWIDTH, PLAYFIELDHIGHT);
                                    Methods.ScoreField(SCOREFIELDWIDTH, SCOREFIELDHIGHT, player);

                                    //Draw a progress bar showing how near is the maximum score                                                        
                                    Methods.DrawProgress(player.Score, MAXSCORE, PROGRESSBARWIDTH, PROGRESSBARHIGHT);

                                    Engine();
                                    escapeFlag = 1;
                                }
                                else
                                {
                                    escapeFlag = 0;
                                    Menu();
                                }
                                isCommand = true;
                            }
                        }; break;

                    //Save the game in a file
                    case ConsoleKey.S:
                        {
                            if ((player.Name != "") && !gameoverFlag)
                            {
                                Methods.SaveHighestScores(HIGHSCOREFILEPATH, player, TOPSCORECOUNT);
                                Methods.SaveGame(GAMEFILEPATH, playField, player);

                                string saveMessage = "The Game has been saved!";
                                Console.SetCursorPosition((Console.WindowWidth - saveMessage.Length) / 2, Console.WindowHeight - 2);
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine(saveMessage);
                            }
                            isCommand = false;
                        }; break;

                    //Load a game from a file
                    case ConsoleKey.L:
                        {
                            gameoverFlag = false;
                            Console.Clear();
                            Console.SetWindowSize(PLAYFIELDWIDTH + 7, PLAYFIELDHIGHT);
                            Console.SetBufferSize(PLAYFIELDWIDTH + 7, PLAYFIELDHIGHT);
                            playField = new PlayField();
                            Methods.LoadGame(GAMEFILEPATH, playField, player);
                            playField.DrawPlayField();
                            Methods.Settings(PLAYFIELDWIDTH, PLAYFIELDHIGHT);
                            Methods.ScoreField(SCOREFIELDWIDTH, SCOREFIELDHIGHT, player);
                            Methods.VisualizeSound(soundflag);

                            //Draw a progress bar showing how near is the maximum score                                                        
                            Methods.DrawProgress(player.Score, MAXSCORE, PROGRESSBARWIDTH, PROGRESSBARHIGHT);

                            escapeFlag = 0;
                            Engine();
                            isCommand = true;
                        }; break;

                    case ConsoleKey.T:
                        {
                            topscoreFlag = true;
                            Methods.ShowTopScores(HIGHSCOREFILEPATH);
                            Engine();
                            //MessageBox.Show(message, "TOP SCORES!!!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        }; break;

                    //Quit the game
                    case ConsoleKey.Q:
                        {
                            Environment.Exit(0);
                            isCommand = true;
                        }; break;
                    default:
                        {
                            isCommand = false;
                        };
                        break;
                }
            }
        }

    }
}
