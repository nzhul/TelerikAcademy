using System;
using System.Collections.Generic;
namespace _02_3D_Labyrinth
{
    class Program
    {
        static void Main()
        {
            // 100/100 - BGCoder
            string startPositionAsString = Console.ReadLine();
            var startPositionParts = startPositionAsString.Split(' ');
            var startCell = new Cell<int>(
                    int.Parse(startPositionParts[0]),
                    int.Parse(startPositionParts[1]),
                    int.Parse(startPositionParts[2]),
                    0);

            string dimentionsAsString = Console.ReadLine();
            var dimentionParts = dimentionsAsString.Split(' ');
            var l = int.Parse(dimentionParts[0]);
            var r = int.Parse(dimentionParts[1]);
            var c = int.Parse(dimentionParts[2]);

            var labyrinth = new char[l, r, c];
            var used = new HashSet<Cell<int>>();
            for (int x = 0; x < l; x++)
            {
                for (int y = 0; y < r; y++)
                {
                    string line = Console.ReadLine();
                    for (int z = 0; z < c; z++)
                    {
                        // line[z]
                        labyrinth[x, y, z] = line[z];
                        if (labyrinth[x, y, z] == '#')
                        {
                            used.Add(new Cell<int>(x, y, z, -1));
                        }
                    }
                }
            }
            Queue<Cell<int>> queue = new Queue<Cell<int>>();
            queue.Enqueue(startCell);
            used.Add(startCell);

            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();

                // Left -> col--
                if (cell.Column > 0)
                {
                    var newCell = new Cell<int>(cell.Level, cell.Row, cell.Column - 1, cell.QueueLevel + 1);

                    if (!used.Contains(newCell))
                    {
                        queue.Enqueue(newCell);
                        used.Add(newCell);
                    }
                }

                // Right -> col++
                if (cell.Column < c - 1)
                {
                    var newCell = new Cell<int>(cell.Level, cell.Row, cell.Column + 1, cell.QueueLevel + 1);

                    if (!used.Contains(newCell))
                    {
                        queue.Enqueue(newCell);
                        used.Add(newCell);
                    }
                }

                // Back -> row--
                if (cell.Row > 0)
                {
                    var newCell = new Cell<int>(cell.Level, cell.Row - 1, cell.Column, cell.QueueLevel + 1);

                    if (!used.Contains(newCell))
                    {
                        queue.Enqueue(newCell);
                        used.Add(newCell);
                    }
                }

                // Forward -> row++
                if (cell.Row < r - 1)
                {
                    var newCell = new Cell<int>(cell.Level, cell.Row + 1, cell.Column, cell.QueueLevel + 1);

                    if (!used.Contains(newCell))
                    {
                        queue.Enqueue(newCell);
                        used.Add(newCell);
                    }
                }

                // if(U) -> level++
                if (labyrinth[cell.Level, cell.Row, cell.Column] == 'U')
                {
                    if (cell.Level == l - 1)
                    {
                        Console.WriteLine(cell.QueueLevel + 1);
                        Environment.Exit(0);
                    }
                    else
                    {
                        var newCell = new Cell<int>(cell.Level + 1, cell.Row, cell.Column, cell.QueueLevel + 1);

                        if (!used.Contains(newCell))
                        {
                            queue.Enqueue(newCell);
                            used.Add(newCell);
                        }
                    }
                }

                // if(D) -> level--
                if (labyrinth[cell.Level, cell.Row, cell.Column] == 'D')
                {
                    if (cell.Level == 0)
                    {
                        Console.WriteLine(cell.QueueLevel + 1);
                        Environment.Exit(0);
                    }
                    else
                    {
                        var newCell = new Cell<int>(cell.Level - 1, cell.Row, cell.Column, cell.QueueLevel + 1);

                        if (!used.Contains(newCell))
                        {
                            queue.Enqueue(newCell);
                            used.Add(newCell);
                        }
                    }
                }
            }
        }
    }

    class Cell<T>
    {

        public Cell(T level, T row, T column, int queueLevel)
        {
            this.Level = level;
            this.Row = row;
            this.Column = column;
            this.QueueLevel = queueLevel;
        }

        public T Level { get; set; }
        public T Row { get; set; }
        public T Column { get; set; }
        public int QueueLevel { get; set; }

        public override bool Equals(object obj)
        {
            var otherCell = obj as Cell<T>;
            if (otherCell == null)
            {
                return false;
            }

            return this.Level.Equals(otherCell.Level)
                && this.Row.Equals(otherCell.Row)
                && this.Column.Equals(otherCell.Column);
        }

        public override int GetHashCode()
        {
            return this.Level.GetHashCode() ^
                this.Row.GetHashCode() ^
                this.Column.GetHashCode();
        }

    }
}
