namespace AwesomeComputers
{
    using System;
    using System.Collections.Generic;
    using AwesomeComputers.Manufacturers;
    using AwesomeComputers.Computers;

    class Main
    {
        public static void main()
        {
            // Sorry, guys ... i'v almost made the whole infrastructure of the project, but didn't have enough time to completely implement the actual application.
            // I know that this is the easy part when you have reasonable infrastructure, but the time was not nearly enough for this.
            // The Project do not compile because i didn't have time to implement the new infrastructure, but i think that it is close enough
            // May be 30-40 more minutes will be enough to complete it.

            Manufacturer Dell = new Manufacturer();
            Manufacturer HP = new Manufacturer();
            Manufacturer Lenovo = new Manufacturer();

            Computer userPC;
            Computer userServer;
            Computer userLaptop;

            int cpuType;
            int coreCount;
            int ramSize;
            int hardsCount;
            int hardsCapacity;

            var manufacturer = Console.ReadLine();

            switch (manufacturer)
            {
                case "HP":
                    cpuType = 32;
                    coreCount = 2;
                    ramSize = 2;
                    hardsCount = 1;
                    hardsCapacity = 500;
                    userPC = HP.CreatePC(cpuType, coreCount, ramSize, hardsCount, hardsCapacity);

                    cpuType = 32;
                    coreCount = 4;
                    ramSize = 32;
                    hardsCount = 2;
                    hardsCapacity = 1000;
                    userServer = HP.CreateServer(cpuType, coreCount, ramSize, hardsCount, hardsCapacity);

                    cpuType = 64;
                    coreCount = 2;
                    ramSize = 4;
                    hardsCount = 1;
                    hardsCapacity = 500;
                    userLaptop = HP.CreateLaptop(cpuType, coreCount, ramSize, hardsCount, hardsCapacity);
                    break;

                case "Dell":
                    cpuType = 64;
                    coreCount = 4;
                    ramSize = 8;
                    hardsCount = 1;
                    hardsCapacity = 1000;
                    userPC = Dell.CreatePC(cpuType, coreCount, ramSize, hardsCount, hardsCapacity);

                    cpuType = 64;
                    coreCount = 8;
                    ramSize = 64;
                    hardsCount = 2;
                    hardsCapacity = 2000;
                    userServer = Dell.CreateServer(cpuType, coreCount, ramSize, hardsCount, hardsCapacity);

                    cpuType = 32;
                    coreCount = 4;
                    ramSize = 8;
                    hardsCount = 1;
                    hardsCapacity = 1000;
                    userLaptop = Dell.CreateLaptop(cpuType, coreCount, ramSize, hardsCount, hardsCapacity);
                    break;

                case "Lenovo":
                    cpuType = 64;
                    coreCount = 2;
                    ramSize = 4;
                    hardsCount = 1;
                    hardsCapacity = 2000;
                    userPC = Lenovo.CreatePC(cpuType, coreCount, ramSize, hardsCount, hardsCapacity);

                    cpuType = 128;
                    coreCount = 2;
                    ramSize = 8;
                    hardsCount = 2;
                    hardsCapacity = 500;
                    userServer = Lenovo.CreateServer(cpuType, coreCount, ramSize, hardsCount, hardsCapacity);

                    cpuType = 64;
                    coreCount = 2;
                    ramSize = 16;
                    hardsCount = 1;
                    hardsCapacity = 1000;
                    userLaptop = Lenovo.CreateLaptop(cpuType, coreCount, ramSize, hardsCount, hardsCapacity);
                    break;
                default:
                        throw new ArgumentException("Invalid manufacturer!");
                    break;
            }

            while (true)
            {
                var command = Console.ReadLine();
                if (command == null) 
                { 
                    goto end; 
                }
                if (command.StartsWith("Exit")) 
                { 
                    goto end; 
                }

                var commandLine = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (commandLine.Length != 2)
                {
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }

                var commandName = commandLine[0];
                var commandValue = int.Parse(commandLine[1]);


                if (commandName == "Charge") 
                { 
                    userLaptop.ChargeBattery(commandValue); 
                }
                else if (commandName == "Process")
                {
                     userServer.Process(commandValue);
                } 
                else if (commandName == "Play")
                {
                    userPC.Play(commandValue);
                } 

                continue; 
                Console.WriteLine("Invalid command!");
            }
            end:;
        }
    }
}
