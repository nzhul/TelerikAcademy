namespace Phonebook
{
    using Phonebook.Command;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommandFactoryWithLazyLoading : ICommandFactory
    {
        private IPhonebookRepository data;
        private IPrinter printer;
        private IPhoneNumberSanitizer sanitizer;

        public CommandFactoryWithLazyLoading(IPhonebookRepository data, IPrinter printer, IPhoneNumberSanitizer sanitizer)
        {
            // TODO: Complete member initialization
            this.data = data;
            this.printer = printer;
            this.sanitizer = sanitizer;
        }
        public IPhonebookCommand CreateCommand(string commandName, int argumentsCount)
        {
            IPhonebookCommand command;
            if ((k.StartsWith("AddPhone")) && (argumentsCount >= 2))
            {
                command = new AddPhoneCommand(this.data, this.printer, this.sanitizer);

            }
            else if ((k == "ChangePhone") && (argumentsCount == 2))
            {
                command = new ChangePhoneCommand(this.data, this.printer, this.sanitizer);
            }
            else if ((k == "List") && (argumentsCount == 2))
            {
                command = new ListPhonesCommand(this.data, this.printer);
            }
            else
            {
                throw new ArgumentException("Invalid command!");
            }
        }
    }
}
