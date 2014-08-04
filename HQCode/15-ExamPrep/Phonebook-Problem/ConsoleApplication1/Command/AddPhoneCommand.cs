using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Command
{
    class AddPhoneCommand : IPhonebookCommand
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
            string str0 = arguments[0];
            var str1 = arguments.Skip(1).ToList();
            for (int i = 0; i < str1.Count; i++)
            {
                str1[i] = sanitizer.Sanitize(str1[i]);
            }

            bool flag = data.AddPhone(str0, str1);

            if (flag)
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
