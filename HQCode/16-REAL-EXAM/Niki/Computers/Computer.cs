namespace AwesomeComputers.Computers
{
    using System.Collections.Generic;
    using AwesomeComputers.Battery;
    using AwesomeComputers.HardDrive;
    using AwesomeComputers.MotherBoard;
    using AwesomeComputers.RAM;

    public abstract class Computer
    {
        private ICPU cpu;
        private IRAM ram;
        private IVideoCard videoCard;
        private RAID hardDriveRaid;
        private IMotherboard motherBoard;

        protected Computer(ICPU cpu, IRAM ram, IVideoCard videoCard, RAID hardDriveRaid, IMotherboard motherBoard)
        {
            this.cpu = cpu;
            this.ram = ram;
            this.videoCard = videoCard;
            this.hardDriveRaid = hardDriveRaid;
            this.motherBoard = motherBoard;
        }
    }
}
