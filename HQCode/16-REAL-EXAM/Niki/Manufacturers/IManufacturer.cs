namespace AwesomeComputers.Manufacturers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AwesomeComputers.Computers;

    interface IManufacturer
    {
        Computer CreatePC(int cpuType, int coreCount, int ramSize, int hardCount, int hardCapacity);
        Computer CreateLaptop(int cpuType, int coreCount, int ramSize, int hardCount, int hardCapacity);
        Computer CreateServer(int cpuType, int coreCount, int ramSize, int hardCount, int hardCapacity);
    }
}
