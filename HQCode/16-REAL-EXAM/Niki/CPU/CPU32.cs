namespace AwesomeComputers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AwesomeComputers.RAM;

    public class CPU32 : ICPU
    {
        private IRAM ram;
        static private Random Random = new Random();
        private byte numberOfCores;

        public CPU32(IRAM ram, int coreCount)
        {
            this.ram = ram;
            this.NumberOfCores = coreCount;
        }

        public byte NumberOfCores
        {
            get
            {
                return numberOfCores;
            }
            set
            {
                this.numberOfCores = value;
            }
        }


        public int CalculateSquareNumber()
        {
            int valueFromTheRam = this.ram.LoadValue();
            if (valueFromTheRam < 0)
            {
                throw new ArgumentException("Number too low.");
            }
            else if (valueFromTheRam > 500)
            {
                throw new ArgumentException("Number too high.");
                // TODO:  Catch the exception and draw it with the video card
            }
            else
            {
                return valueFromTheRam * 2;
                // TODO: use this later at the rendering: string.Format("Square of {0} is {1}.", valueFromTheRam, value)
            }
        }

        public void SaveRandomValueToTheRAM(int min, int max)
        {
            int randomNumber = Random.Next(0, 1000);
            this.ram.SaveValue(randomNumber);
        }
    }
}
