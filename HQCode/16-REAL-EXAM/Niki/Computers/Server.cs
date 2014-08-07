namespace AwesomeComputers.Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AwesomeComputers.RAM;
    using AwesomeComputers.HardDrive;
    using AwesomeComputers.MotherBoard;

    public class Server : Computer
    {
        public Server(ICPU cpu, IRAM ram, MonochromeVideoCard videoCard, RAID hardDriveRaid, MonochromeVideoCard motherBoard)
            : base(cpu, ram, videoCard, hardDriveRaid, motherBoard)
        {
        }

        public void ProcessRequest(int integerToProcess) 
        {
            int processResult = this.cpu.CalculateSquareNumber(integerToProcess);
            this.videoCard.Draw(processResult);
        }
    }
}
