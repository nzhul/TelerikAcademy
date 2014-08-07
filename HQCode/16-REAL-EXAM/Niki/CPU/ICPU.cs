namespace AwesomeComputers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICPU
    {
        int CalculateSquareNumber();
        void SaveRandomValueToTheRAM(int min, int max);
    }
}
