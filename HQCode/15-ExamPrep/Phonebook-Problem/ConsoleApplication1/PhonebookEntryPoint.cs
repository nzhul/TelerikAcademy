namespace Phonebook
{
    using System;
    using System.Linq;
    using Phonebook.Command;

    public static class PhonebookEntryPoint
    {
        internal static void Main()
        {
            IPhonebookRepository data = new PhonebookRepositoryWithDictionary();
            IPrinter printer = new StringBuilderPrinter();
            IPhoneNumberSanitizer sanitizer = new PhoneNumberSanitizer();
            ICommandFactory commandFactory = new CommandFactoryWithLazyLoading(data, printer, sanitizer);
            ICommandParser commandParser = new CommandParser();
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == "End" || userInput == null)
                {
                    break;
                }

                var commandInfo = commandParser.Parse(userInput);
                IPhonebookCommand command = commandFactory.CreateCommand(commandInfo.CommandName, commandInfo.Arguments.Count());
                command.Execute(commandInfo.Arguments.ToArray());
            }

            printer.Accept(new ConsolePrinterVisitorWithNewLine());
        }
    }
}