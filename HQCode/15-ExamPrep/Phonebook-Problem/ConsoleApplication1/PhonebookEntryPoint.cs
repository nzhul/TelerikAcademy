namespace Phonebook
{
    using System;
    using Phonebook.Command;

    public static class PhonebookEntryPoint
    {
        static void Main()
        {
            IPhonebookRepository data = new REPNew();
            IPrinter printer = new StringBuilderPrinter();
            IPhoneNumberSanitizer sanitizer = new PhoneNumberSanitizer();
            ICommandFactory commandFactory = new CommandFactoryWithLazyLoading(data, printer, sanitizer);

            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == "End" || userInput == null)
                {
                    // Error reading from console 
                    break;
                }

                // TODO: Extract command parsing -> Interpreter or just new Class
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

                IPhonebookCommand command = commandFactory.CreateCommand(k, strings.Length);
                command.Execute(strings);
            }
            Console.Write(printer.GetAllText());
        }
    }
}