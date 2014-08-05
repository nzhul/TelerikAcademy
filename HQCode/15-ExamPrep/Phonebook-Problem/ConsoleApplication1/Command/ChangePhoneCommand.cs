namespace Phonebook.Command
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class ChangePhoneCommand : IPhonebookCommand
    {
        private IPrinter printer;
        private IPhonebookRepository data;
        private IPhoneNumberSanitizer sanitizer;

        public ChangePhoneCommand(IPhonebookRepository data , IPrinter printer, IPhoneNumberSanitizer sanitizer) 
        {
            this.printer = printer;
            this.data = data;
            this.sanitizer = sanitizer;
        }

        public void Execute(string[] arguments)
        {
            var currentPhoneNumber = this.sanitizer.Sanitize(arguments[0]);
            var newPhoneNumber = this.sanitizer.Sanitize(arguments[1]);
            var phoneNumbersChanged = this.data.ChangePhone(currentPhoneNumber, newPhoneNumber);
            this.printer.Print(phoneNumbersChanged + " numbers changed");
        }
    }
}
