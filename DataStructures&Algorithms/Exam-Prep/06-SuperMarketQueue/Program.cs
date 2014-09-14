namespace SuperMarketQueue
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using Wintellect.PowerCollections;
    internal class Program
    {
        private static void Main()
        {
            var superQueue = new SuperQueue();
            var command = Console.ReadLine();

            while (!command.Contains("End"))
            {
                superQueue.CommandParse(command);
                command = Console.ReadLine();
            }

            Console.WriteLine(superQueue.Output);
        }
    }

    public class SuperQueue
    {
        private const string OK = "OK";
        private const string Error = "Error";
        private readonly BigList<string> internalList = new BigList<string>();
        private readonly Dictionary<string, int> nameList = new Dictionary<string, int>();
        private readonly StringBuilder outputBuilder = new StringBuilder();

        public string Output
        {
            get
            {
                return this.outputBuilder.ToString();   
            }
        }

        public string Append(string name)
        {
            this.internalList.Add(name);
            this.AddToDictionary(name);
            return OK;
        }

        public string Insert(int position, string name)
        {
            if (position <= this.internalList.Count)
            {
                this.AddToDictionary(name);
                this.internalList.Insert(position, name);
                return OK;
            }

            return Error;
        }

        public int Find(string name)
        {
            if (this.nameList.ContainsKey(name))
            {
                return this.nameList[name];
            }
            return 0;
        }

        public string Serve(int count)
        {
            if (this.internalList.Count >= count)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < count; i++)
                {
                    sb.Append(this.internalList[i]);
                    sb.Append(" ");
                    this.nameList[this.internalList[i]]--;
                }

                this.internalList.RemoveRange(0, count);

                return sb.ToString().TrimEnd();
            }

            return Error;
        }

        public void CommandParse(string command)
        {
            var commandSplit = command.Split(' ');
            var commandName = commandSplit[0];

            switch (commandName)
            {
                case "Append":
                    this.outputBuilder.AppendLine(this.Append(commandSplit[1]));
                    break;
                case "Find":
                    this.outputBuilder.AppendLine(this.Find(commandSplit[1]).ToString(CultureInfo.InvariantCulture));
                    break;
                case "Insert":
                    this.outputBuilder.AppendLine(this.Insert(int.Parse(commandSplit[1]), commandSplit[2]));
                    break;
                case "Serve":
                    this.outputBuilder.AppendLine(this.Serve(int.Parse(commandSplit[1])));
                    break;
                default:
                    break;
            }
        }

        private void AddToDictionary(string name)
        {
            if (this.nameList.ContainsKey(name))
            {
                this.nameList[name]++;
            }
            else
            {
                this.nameList.Add(name, 1);
            }
        }
    }
}
