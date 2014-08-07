namespace AwesomeComputers.RAM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RAM : IRAM
    {
        int value;

        internal RAM(int amount)
        {
            Amount = amount;
        }

        int Amount { get; set; }

        public void SaveValue(int newValue)
        {
            value = newValue;
        }

        public int LoadValue()
        {
            return value;
        } 
    }
}
