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
    using Phonebook.Command;

    public static class PhonebookEntryPoint
    {
        private static IPhonebookRepository data = new REPNew(); // this works!

        static void Main()
        {

            IPrinter printer = new StringBuilderPrinter();
            IPhoneNumberSanitizer sanitizer = new PhoneNumberSanitizer();

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
                IPhonebookCommand command;
                if ((k.StartsWith("AddPhone")) && (strings.Length >= 2))
                {
                    command = new AddPhoneCommand(data, printer, sanitizer);

                }
                else if ((k == "ChangePhone") && (strings.Length == 2))
                {
                    command = new ChangePhoneCommand(data, printer, sanitizer);
                }
                else if ((k == "List") && (strings.Length == 2))
                {
                    command = new ListPhonesCommand(data, printer);
                }
                else
                {
                    throw new ArgumentException("Invalid command!");
                }
                command.Execute(strings);
            }
            Console.Write(printer.GetAllText());
        }
    }
}