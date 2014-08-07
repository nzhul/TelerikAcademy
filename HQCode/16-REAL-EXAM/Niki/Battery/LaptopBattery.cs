namespace AwesomeComputers.Battery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LaptopBattery : IBattery
    {
        private int percentagePower;

        public LaptopBattery() 
        {
            this.PercentagePower = 50;
        }

        public int PercentagePower
        {
            get { return this.percentagePower; }
            private set { this.percentagePower = value; }
        }

        public void Charge(int percentage)
        {
            this.PercentagePower += percentage;

            if (this.PercentagePower > 100) 
            {
                this.PercentagePower = 100;
            }

            if (this.PercentagePower < 0) 
            {
                this.PercentagePower = 0;
            }
        }
    }
}
