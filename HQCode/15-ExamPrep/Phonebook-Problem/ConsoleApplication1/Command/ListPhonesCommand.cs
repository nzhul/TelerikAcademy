using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Command
{
    class ListPhonesCommand : IPhonebookCommand
    {
        private IPrinter printer;
        private IPhonebookRepository data;

        public ListPhonesCommand(IPhonebookRepository data, IPrinter printer)
        {
            this.printer = printer;
            this.data = data;
        }

        public void Execute(string[] arguments)
        {
            try
            {
                IEnumerable<Class1> entries = data.ListEntries(int.Parse(arguments[0]), int.Parse(arguments[1]));
                foreach (var entry in entries)
                {
                    printer.Print(entry.ToString());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                printer.Print("Invalid range");
            }
        }
    }
}
