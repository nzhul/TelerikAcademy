using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Command
{
    public class AddPhoneCommand : IPhonebookCommand
    {
        private IPrinter printer;
        private IPhonebookRepository data;
        private IPhoneNumberSanitizer sanitizer;

        public AddPhoneCommand(IPhonebookRepository data, IPrinter printer, IPhoneNumberSanitizer sanitizer)
        {
            this.printer = printer;
            this.data = data;
            this.sanitizer = sanitizer;
        }

        public void Execute(string[] arguments)
        {
            string name = arguments[0];
            var phoneNumbers = arguments.Skip(1).ToList();
            for (int i = 0; i < phoneNumbers.Count; i++)
            {
                phoneNumbers[i] = sanitizer.Sanitize(phoneNumbers[i]);
            }

            bool phoneEntryCreated = data.AddPhone(name, phoneNumbers);

            if (phoneEntryCreated)
            {
                printer.Print("Phone entry created.");
            }
            else
            {
                printer.Print("Phone entry merged");
            }
        }
    }
}
