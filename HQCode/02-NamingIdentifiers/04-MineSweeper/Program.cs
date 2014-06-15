using System;
using System.Linq;
using System.Collections.Generic;

namespace Minesweeper
{
    public class Mine
    {
        public class Player
        {
            string name;
            int score;

            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }

            public int Points
            {
                get
                {
                    return score;
                }
                set
                {
                    score = value;
                }
            }

            public Player()
            {
                return;
            }

            public Player(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }
        }

        static void Main()
        {
            string command = string.Empty;
            char[,] field = MakeField();
            char[,] mines = MakeMines();
            int cellsOpened = 0;
            bool isGameOver = false;
            List<Player> champions = new List<Player>(6);
            int row = 0;
            int col = 0;
            bool isFirstMove = true;
            const int ТotalCells = 35;
            bool allCellsOpened = false;

            do
            {
                if (isFirstMove)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                                      " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    PrintField(field);
                    isFirstMove = false;
                }
                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out col) &&
                        row < field.GetLength(0) && col < field.GetLength(1))
                    {
                        command = "turn";
                    }
                }
                switch (command)
                {
                    case "top":
                        PrintScoreBoard(champions);
                        break;
                    case "restart":
                        field = MakeField();
                        mines = MakeMines();
                        PrintField(field);
                        isGameOver = false;
                        isFirstMove = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                MakeMove(field, mines, row, col);
                                cellsOpened++;
                            }
                            if (cellsOpened == ТotalCells)
                            {
                                allCellsOpened = true;
                            }
                            else
                            {
                                PrintField(field);
                            }
                        }
                        else
                        {
                            isGameOver = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }
                if (isGameOver)
                {
                    PrintField(mines);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
                                  "Daj si niknejm: ", cellsOpened);
                    string playerName = Console.ReadLine();
                    Player player = new Player(playerName, cellsOpened);
                    if (champions.Count < 5)
                    {
                        champions.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < player.Points)
                            {
                                champions.Insert(i, player);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }
                    champions.Sort((Player p1, Player p2) => p2.Name.CompareTo(p1.Name));
                    champions.Sort((Player p1, Player p2) => p2.Points.CompareTo(p1.Points));
                    PrintScoreBoard(champions);

                    field = MakeField();
                    mines = MakeMines();
                    cellsOpened = 0;
                    isGameOver = false;
                    isFirstMove = true;
                }
                if (allCellsOpened)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    PrintField(mines);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    Player player = new Player(name, cellsOpened);
                    champions.Add(player);
                    PrintScoreBoard(champions);
                    field = MakeField();
                    mines = MakeMines();
                    cellsOpened = 0;
                    allCellsOpened = false;
                    isFirstMove = true;
                }
            } while (command != "exit");

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void PrintScoreBoard(List<Player> scoreBoard)
        {
            Console.WriteLine("\nTo4KI:");
            if (scoreBoard.Count > 0)
            {
                for (int i = 0; i < scoreBoard.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii",
                        i + 1, scoreBoard[i].Name, scoreBoard[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void MakeMove(char[,] field, char[,] mines, int row, int col)
        {
            char neighbourMinesCount = GetNeighbourMinesCount(mines, row, col);

            mines[row, col] = neighbourMinesCount;
            field[row, col] = neighbourMinesCount;
        }

        private static void PrintField(char[,] field)
        {
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);

                for (int col = 0; col < cols; col++)
                {
                    Console.Write("{0} ", field[row, col]);
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] MakeField()
        {
            int rows = 5;
            int cols = 10;

            char[,] field = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = '?';
                }
            }

            return field;
        }

        private static char[,] MakeMines()
        {
            int rows = 5;
            int cols = 10;

            char[,] field = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = '-';
                }
            }

            List<int> randomNumbers = new List<int>();

            Random randomGenerator = new Random();
            while (randomNumbers.Count < 15)
            {
                int randomNumber = randomGenerator.Next(50);
                if (!randomNumbers.Contains(randomNumber))
                {
                    randomNumbers.Add(randomNumber);
                }
            }

            foreach (int i2 in randomNumbers)
            {
                int row = (i2 % cols);
                int col = (i2 / cols);

                if (row == 0 && i2 != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                field[col, row - 1] = '*';
            }

            return field;
        }

        private static void smetki(char[,] field)
        {
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (field[row, col] != '*')
                    {
                        field[row, col] = GetNeighbourMinesCount(field, row, col);
                    }
                }
            }
        }

        private static char GetNeighbourMinesCount(char[,] field, int row, int col)
        {
            int count = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    count++;
                }
            }
            if (row + 1 < rows)
            {
                if (field[row + 1, col] == '*')
                {
                    count++;
                }
            }
            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    count++;
                }
            }
            if (col + 1 < cols)
            {
                if (field[row, col + 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}