namespace AwesomeComputers.HardDrive
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HardDrive
    {
        bool isInRaid;
        int capacity;
        Dictionary<int, string> data;

        internal HardDrive(int capacity, bool isInRaid)
        {
            this.isInRaid = isInRaid;
            this.capacity = capacity;
            this.data = new Dictionary<int, string>(capacity);
        }

        int Capacity
        {
            get
            {
                return capacity;
            }
        }
        
        public void SaveData(int addr,string newData)
        {
            this.data[addr] = newData;
        }
        public string LoadData(int address)
        {
            return this.data[address];
        }
    }
}
