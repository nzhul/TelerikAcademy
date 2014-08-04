namespace Phonebook
{
    using System;
    using System.Data;
    using System.Data.Odbc;
    using System.Data.Sql;
    using System.Data.SqlTypes;
    using System.Collections.Generic;
    using System.Net.Mail;
    using System.Net.Sockets;
    using System.Net.Mime;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

        public static class PhonebookEntryPoint
        {
            private const string Code = "+359";

            private static IPhonebookRepository data = new REPNew(); // this works!
            private static StringBuilder input = new StringBuilder();

            static void Main()
            {
                while (true)
                {
                    string userInput = Console.ReadLine();
                    if (userInput == "End" || userInput == null)
                    {
                        // Error reading from console 
                        break;
                    }

                    int i = userInput.IndexOf('('); if (i == -1) { Console.WriteLine("error!"); Environment.Exit(0); }
                    
                    string k = userInput.Substring(0, i);
                    if (!userInput.EndsWith(")"))
                    {
                        Main();
                    }
                    string s = userInput.Substring(i + 1, userInput.Length - i - 2);
                    string[] strings = s.Split(',');
                    for (int j = 0; j < strings.Length; j++)
                    {
                        strings[j] = strings[j].Trim();
                    }

                    if ((k.StartsWith("AddPhone")) && (strings.Length >= 2))
                    {
                        Cmd("AddPhone", strings);
                    }
                    else if ((k == "ChangePhone") && (strings.Length == 2))
                    {
                        Cmd("ChangePhone", strings);
                    }
                    else if ((k == "List") && (strings.Length == 2))
                    {
                        Cmd("List", strings);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }
                Console.Write(input);
            }

            private static void Cmd(string cmd, string[] strings)
            {

                if (cmd == "AddPhone") // first command
                {
                    string str0 = strings[0]; 
                    var str1 = strings.Skip(1).ToList();
                    for (int i = 0; i < str1.Count; i++)
                    {
                        str1[i] = conv(str1[i]);
                    }

                    bool flag = data.AddPhone(str0, str1);

                    if (flag)
                    {
                        Print("Phone entry created.");
                    }
                    else
                    {
                        Print("Phone entry merged");
                    }
                }
                else if (cmd == "ChangePhone") // second command
                {
                    Print("" + data.ChangePhone(conv(strings[0]), conv(strings[1])) + " numbers changed");
                }
                else // third command (List)
                    try
                    {
                        IEnumerable<Class1> entries = data.ListEntries(int.Parse(strings[0]), int.Parse(strings[1]));
                        foreach (var entry in entries)
                        {
                            Print(entry.ToString());
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Print("Invalid range");
                    }
            }
            private static string conv(string num)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i <= input.Length; i++)
                {
                    sb.Clear(); foreach (char ch in num) if (char.IsDigit(ch) || (ch == '+')) sb.Append(ch);
                    if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
                    { sb.Remove(0, 1); sb[0] = '+'; }
                    while (sb.Length > 0 && sb[0] == '0') sb.Remove(0, 1);

                    if (sb.Length > 0 && sb[0] != '+') sb.Insert(0, Code);
                    sb.Clear();
                    foreach (char ch in num) if (char.IsDigit(ch) || (ch == '+')) sb.Append(ch);
                    if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
                    { sb.Remove(0, 1); sb[0] = '+'; }

                    while (sb.Length > 0 && sb[0] == '0') sb.Remove(0, 1);
                    if (sb.Length > 0 && sb[0] != '+') sb.Insert(0, Code);
                    sb.Clear();
                    foreach (char ch in num) if (char.IsDigit(ch) || (ch == '+')) sb.Append(ch);
                    if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')

                    { sb.Remove(0, 1); sb[0] = '+'; }
                    while (sb.Length > 0 && sb[0] == '0') sb.Remove(0, 1);
                    if (sb.Length > 0 && sb[0] != '+') sb.Insert(0, Code);
                }
                return sb.ToString();
            }
            private static void Print(string text)
            {
                input.AppendLine(text);
            }
        }
}