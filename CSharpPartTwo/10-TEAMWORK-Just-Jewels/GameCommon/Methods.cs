using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameCommon
{

    public class Methods
    {
        private const char PROGRESBAR_SYMBOL = '\u2591';    //'\u2588';        
        private const ConsoleColor PROGRESBAR_COLOR = ConsoleColor.White;


        //Set initial console size and title
        public static void Settings(int x, int y)
        {
            Console.SetWindowSize(x, y);
            Console.SetBufferSize(x, y);

            Console.CursorVisible = false;
            Console.Title = "Just Jewels";
        }

        //Show player name and his score
        public static void ScoreField(int x, int y, Player player)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("---------------------------------");
            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write("Player: {0}     ", player.Name);
            Console.SetCursorPosition(x + 1, y + 3);
            Console.Write("Score: {0}     ", player.Score);
            Console.SetCursorPosition(20, 35);
        }

        //Show sound On/Off
        public static void VisualizeSound(bool soundflag)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Console.WindowWidth - 11, Console.WindowHeight / 2 + 13);
            Console.Write("Sound: ");

            if (soundflag)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("On ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Off");
            }
        }

        //Load player name
        public static string LoadPlayer()
        {
            Console.Clear();
            string playerName = "";

            while ((playerName == "") || (playerName.Length > 13))
            {
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 3 - 2, Console.WindowHeight / 3 - 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("ENTER YOUR NAME: ");
                Console.SetCursorPosition(Console.WindowWidth / 3 - 2, Console.WindowHeight / 3);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("(max 13 symbols)");
                Console.SetCursorPosition(Console.WindowWidth / 3 - 2, Console.WindowHeight / 3 + 2);
                Console.ForegroundColor = ConsoleColor.White;
                Console.CursorVisible = true;
                playerName = Console.ReadLine();
            };
            Console.CursorVisible = false;
            return playerName;
        }

        //Draw a progress bar showing how near is the maximum score
        public static void DrawProgress(int score, int maxScore, int x, int y)
        {
            DrawProgress(score, maxScore, PROGRESBAR_SYMBOL, PROGRESBAR_COLOR, x, y);
        }
        public static void DrawProgress(int score, int maxScore, char progressBarCharacter, ConsoleColor color, int x, int y)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            double width = Console.WindowWidth - 1;
            int newWidth = (int)((width / maxScore) * score);
            string progress;
            if (score >= maxScore)
            {
                progress = new string(progressBarCharacter, Console.WindowWidth - 1);
            }
            else
            {
                progress = new string(progressBarCharacter, newWidth);
            }
            Console.SetCursorPosition(x, y);
            Console.Write(progress);
            Console.ForegroundColor = currentColor;
        }

        //Load player name
        public static void ShowTopScores(string HIGHSCOREFILEPATH)
        {
            //Get info about the players with the highest scores  
            List<Player> highScoreList = GetHighestScores(HIGHSCOREFILEPATH);

            int rowCounter = Console.WindowHeight / 3 - 1;
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 3 - 2, rowCounter);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("TOP SCORES ");

            string message = "No TOP scores!";
            rowCounter += 3;
            Console.SetCursorPosition(Console.WindowWidth / 3 - 2, rowCounter);
            Console.ForegroundColor = ConsoleColor.Cyan;

            if (highScoreList.Count != 0)
            {
                int playerCounter = 1;
                foreach (Player player in highScoreList)
                {
                    Console.CursorVisible = false;
                    message = playerCounter + ". " + player.Name + " " + player.Score;
                    Console.WriteLine(message);
                    rowCounter += 2;
                    Console.SetCursorPosition(Console.WindowWidth / 3 - 2, rowCounter);
                    playerCounter++;
                }
            }
            else
            {
                Console.WriteLine(message);
            }

            string messageMainMenu = "Press ESC for Main Menu!";
            Console.SetCursorPosition((Console.WindowWidth - messageMainMenu.Length) / 2, Console.WindowHeight - 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(messageMainMenu);
        }

        //Load the last saved game, player and score from a file        
        public static void LoadGame(string filePath, PlayField playField, Player player)
        {
            try
            {
                StreamReader reader = new StreamReader(filePath);
                using (reader)
                {
                    player.Name = reader.ReadLine();
                    player.Score = int.Parse(reader.ReadLine());

                    for (int i = 0; i < playField.GetLength(0); i++)
                    {
                        string line = reader.ReadLine();
                        string[] currentLine = line.Trim().Split(' ');
                        int counter = 0;
                        for (int j = 0; j < currentLine.Length; j += 4)
                        {
                            int x = int.Parse(currentLine[j]);
                            int y = int.Parse(currentLine[j + 1]);
                            char symbol = char.Parse(currentLine[j + 2]);
                            ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), currentLine[j + 3]);
                            Box box = new Box(x, y, symbol, color);
                            box.InitBox(symbol);
                            playField[i, counter] = box;
                            counter++;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.Clear();
                throw;
            }
        }

        //Save current game, player and score in a file
        public static void SaveGame(string filePath, PlayField playField, Player player)
        {
            try
            {
                StreamWriter writer = new StreamWriter(filePath);
                using (writer)
                {
                    writer.WriteLine(player.Name);
                    writer.WriteLine(player.Score);

                    for (int i = 0; i < playField.GetLength(0); i++)
                    {
                        for (int j = 0; j < playField.GetLength(1); j++)
                        {
                            writer.Write(playField[i, j].X + " ");
                            writer.Write(playField[i, j].Y + " ");
                            writer.Write(playField[i, j].Symbol + " ");
                            writer.Write(playField[i, j].Color + " ");
                        }
                        writer.WriteLine();
                    }
                }
            }
            catch (Exception)
            {
                Console.Clear();
                throw;
            }
        }

        //Save info about the players with the highest scores in a file
        public static void SaveHighestScores(string filePath, Player playerCurrent, int topScoreCount)
        {
            List<Player> highScoreList = new List<Player>();

            //Get info about the players with the highest scores  
            highScoreList = GetHighestScores(filePath);

            try
            {
                StreamWriter writer = new StreamWriter(filePath);
                using (writer)
                {
                    bool ifPlayerExist = false;
                    if (highScoreList.Count != 0)
                    {
                        foreach (Player player in highScoreList)
                        {
                            if (player.Name == playerCurrent.Name)
                            {
                                if (player.Score < playerCurrent.Score)
                                {
                                    player.Score = playerCurrent.Score;
                                }
                                ifPlayerExist = true;
                            }
                        }

                        if (!ifPlayerExist)
                        {
                            highScoreList.Add(new Player { Name = playerCurrent.Name, Score = playerCurrent.Score });
                        }

                        var sortedList = highScoreList.OrderByDescending(x => x.Score);
                        highScoreList = sortedList.ToList<Player>();

                        for (int i = 0; i < highScoreList.Count; i++)
                        {
                            if (i < topScoreCount)
                            {
                                writer.WriteLine(highScoreList[i].Name + " " + highScoreList[i].Score);
                            }
                        }
                    }
                    else
                    {
                        writer.WriteLine(playerCurrent.Name + " " + playerCurrent.Score);
                    }
                }

            }
            catch (Exception)
            {
                Console.Clear();
                throw;
            }
        }

        //Load info from a file about the players with the highest scores
        public static List<Player> GetHighestScores(string filePath)
        {
            List<Player> highScoreList = new List<Player>();
            try
            {
                if (File.Exists(filePath))
                {

                    StreamReader reader = new StreamReader(filePath);

                    using (reader)
                    {
                        highScoreList = new List<Player>();
                        string lineFile = reader.ReadLine();

                        while (lineFile != null)
                        {
                            string[] line = lineFile.Split(' ');
                            highScoreList.Add(new Player { Name = line[0], Score = int.Parse(line[1]) });

                            lineFile = reader.ReadLine();
                        }
                    }
                }
                return highScoreList;
            }
            catch (Exception)
            {
                Console.Clear();
                throw;
            }
        }

        //Draw the Main Menu of the Game
        public static void DrawMenu(string playerName, bool gameoverFlag)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Console.WindowWidth / 5, Console.WindowHeight / 3 - 3);
            Console.WriteLine("WELCOME TO JUST JEWELS!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Console.WindowWidth / 3 + 1, Console.WindowHeight / 3 - 1);
            Console.WriteLine("MAIN MENU");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(Console.WindowWidth / 3 - 1, Console.WindowHeight / 3 + 3);
            Console.WriteLine("N - New game");
            Console.SetCursorPosition(Console.WindowWidth / 3 - 1, Console.WindowHeight / 3 + 5);
            Console.WriteLine("L - Load game");
            int tmpHeight = 0;
            if ((playerName != "") && (!gameoverFlag))
            {
                Console.SetCursorPosition(Console.WindowWidth / 3 - 1, Console.WindowHeight / 3 + 7);
                Console.WriteLine("S - Save game");
                Console.SetCursorPosition(Console.WindowWidth / 3 - 1, Console.WindowHeight / 3 + 9);
                Console.WriteLine("ESC - Return to game");
                tmpHeight = 11;
            }
            else
            {
                tmpHeight = 7;
            }
            Console.SetCursorPosition(Console.WindowWidth / 3 - 1, Console.WindowHeight / 3 + tmpHeight);
            Console.WriteLine("T - Top scores");
            Console.SetCursorPosition(Console.WindowWidth / 3 - 1, Console.WindowHeight / 3 + tmpHeight + 2);
            Console.WriteLine("Q - Quit game");
        }

        public static int GetBoxesToRemove(bool[,] boxesToRemove)
        {
            int jewelCount = 0;

            for (int y = 0; y < boxesToRemove.GetLength(0); y++)
            {
                for (int x = 0; x < boxesToRemove.GetLength(1); x++)
                {
                    if (boxesToRemove[x, y])
                    {
                        jewelCount += 10;
                    }
                }
            }
            return jewelCount;
        }

        // This method checks if the boxesToRemove bool matrix is empty or not
        public static bool isEmpty(bool[,] boxesToRemove)
        {
            for (int y = 0; y < boxesToRemove.GetLength(0); y++)
            {
                for (int x = 0; x < boxesToRemove.GetLength(1); x++)
                {
                    if (boxesToRemove[x, y])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void DisplayCombo(int bonus, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            switch (bonus)
            {
                case 2:
                    Console.Beep(223, 35);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510\n    |D| |O| |U| |B| |L| |E|\n    \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518\n      \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \n      |C| |O| |M| |B| |O|\n      \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518");
                    break;
                case 3:
                    Console.Beep(223, 35);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510\n    |T| |R| |I| |P| |L| |E|\n    \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518\n      \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \n      |C| |O| |M| |B| |O|\n      \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518");
                    break;
                case 4:
                    Console.Beep(223, 35);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510\n    |Q| |U| |A| |D| |R| |O|\n    \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518\n      \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \n      |C| |O| |M| |B| |O|\n      \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518");
                    break;
                case 5:
                    Console.Beep(223, 35);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("    \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \n        |I| |M| |P| |O|\n        \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518\n      \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \n      |S| |I| |B| |L| |E|\n      \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518");
                    break;
                case 6:
                    Console.Beep(223, 35);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("    \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \n        |I| |M| |P| |O|\n        \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518\n      \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \n      |S| |I| |B| |L| |E|\n      \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("\u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510\n    |D| |O| |U| |B| |L| |E|\n    \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518\n      \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \u250c-\u2510 \n      |C| |O| |M| |B| |O|\n      \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518 \u2514-\u2518");
                    break;
            }
        }
    }
}
