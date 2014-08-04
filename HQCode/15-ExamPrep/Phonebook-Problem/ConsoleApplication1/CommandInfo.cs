using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    public class CommandInfo
    {
        public string CommandName { get; set; }
        public IEnumerable<string> Arguments { get; set; }
    }
}
