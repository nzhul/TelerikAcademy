namespace AwesomeComputers.Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AwesomeComputers.HardDrive;
    using AwesomeComputers.MotherBoard;
    using AwesomeComputers.RAM;

    public class PC : Computer
    {
        public PC(ICPU cpu, IRAM ram, IVideoCard videoCard, RAID hardDriveRaid, IMotherboard motherBoard) 
            : base(cpu, ram, videoCard, hardDriveRaid, motherBoard)
        {
        }

        public void PlayGame(int guessNumber)
        {
            //TODO: Implement this stuff - copy and refactor the code from the original
            this.cpu.SaveRandomValueToTheRAM(1, 10);
            var number = this.ram.LoadValue();
            if (number + 1 != guessNumber + 1) this.videoCard.Draw(string.Format("You didn't guess the number {0}.", number));
            else this.videoCard.Draw("You win!");
        }
    }
}
