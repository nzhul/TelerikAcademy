namespace AwesomeComputers.Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AwesomeComputers.Battery;
    using AwesomeComputers.HardDrive;
    using AwesomeComputers.MotherBoard;
    using AwesomeComputers.RAM;

    public class Laptop : Computer
    {
        private LaptopBattery battery;

        public Laptop(ICPU cpu, IRAM ram, IVideoCard videoCard, RAID hardDriveRaid, IMotherboard motherBoard, IBattery battery)
            : base(cpu, ram, videoCard, hardDriveRaid, motherBoard)
        {
            this.battery = battery;
        }

        public void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);
            this.videoCard.Draw(string.Format("Battery status: {0}", this.battery.PercentagePower));
        }
    }
}
