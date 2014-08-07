namespace AwesomeComputers.Manufacturers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AwesomeComputers.Computers;
    using AwesomeComputers.HardDrive;
    using AwesomeComputers.RAM;
    using AwesomeComputers.MotherBoard;
    using AwesomeComputers.Battery;

    public class Manufacturer : IManufacturer
    {
        public Computer CreatePC(int cpuType, int coreCount, int ramSize, int hardCount, int hardCapacity)
        {
            IRAM ram = new RAM(ramSize);
            ICPU cpu;
            switch (cpuType)
            {
                case 32:
                    cpu = new CPU32(ram, coreCount);
                    break;
                case 64:
                    cpu = new CPU64(ram, coreCount);
                    break;
                case 128:
                    cpu = new CPU128(ram, coreCount);
                    break;
                default:
                    break;
            }
            IVideoCard videoCard = new ColorfulVideoCard();
            IMotherboard motherBoard = new MotherBoard();
            RAID hardDriveRaid = new RAID();
            for (int i = 0; i < hardCount; i++)
            {
                HardDrive currentHardDrive = new HardDrive(hardCapacity, true);
                hardDriveRaid.AddHardDrive(currentHardDrive);
            }
            Computer pc = new PC(cpu, ram, videoCard, hardDriveRaid, motherBoard);
            return pc;
        }

        public Computer CreateLaptop(int cpuType, int coreCount, int ramSize, int hardCount, int hardCapacity)
        {
            IRAM ram = new RAM(ramSize);
            ICPU cpu;
            switch (cpuType)
            {
                case 32:
                    cpu = new CPU32(ram, coreCount);
                    break;
                case 64:
                    cpu = new CPU64(ram, coreCount);
                    break;
                case 128:
                    cpu = new CPU128(ram, coreCount);
                    break;
                default:
                    break;
            }
            IVideoCard videoCard = new ColorfulVideoCard();
            IMotherboard motherBoard = new MotherBoard();
            RAID hardDriveRaid = new RAID();
            IBattery battery = new LaptopBattery();
            for (int i = 0; i < hardCount; i++)
            {
                HardDrive currentHardDrive = new HardDrive(hardCapacity, true);
                hardDriveRaid.AddHardDrive(currentHardDrive);
            }
            Computer laptop = new Laptop(cpu, ram, videoCard, hardDriveRaid, motherBoard, battery);
            return laptop;
        }

        public Computer CreateServer(int cpuType, int coreCount, int ramSize, int hardCount, int hardCapacity)
        {
            IRAM ram = new RAM(ramSize);
            ICPU cpu;
            switch (cpuType)
            {
                case 32:
                    cpu = new CPU32(ram, coreCount);
                    break;
                case 64:
                    cpu = new CPU64(ram, coreCount);
                    break;
                case 128:
                    cpu = new CPU128(ram, coreCount);
                    break;
                default:
                    break;
            }
            IVideoCard videoCard = new MonochromeVideoCard();
            IMotherboard motherBoard = new MotherBoard();
            RAID hardDriveRaid = new RAID();
            IBattery battery = new LaptopBattery();
            for (int i = 0; i < hardCount; i++)
            {
                HardDrive currentHardDrive = new HardDrive(hardCapacity, true);
                hardDriveRaid.AddHardDrive(currentHardDrive);
            }
            Computer server = new Server(cpu, ram, videoCard, hardDriveRaid, motherBoard);
            return server;
        }
    }
}
