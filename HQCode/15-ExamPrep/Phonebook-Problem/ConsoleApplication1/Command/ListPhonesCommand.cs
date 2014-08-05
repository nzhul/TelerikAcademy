using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Command
{
    public class ListPhonesCommand : IPhonebookCommand
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
                var entries = this.data.ListEntries(int.Parse(arguments[0]), int.Parse(arguments[1]));
                foreach (var entry in entries)
                {
                    this.printer.Print(entry.ToString());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                this.printer.Print("Invalid range");
            }
        }
    }
}
