using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCommon
{
    public class GameExceptions : Exception
    {
        public GameExceptions()
        {
        }
        public GameExceptions(string message)
            : base(message)
        {
        }
    }
}
