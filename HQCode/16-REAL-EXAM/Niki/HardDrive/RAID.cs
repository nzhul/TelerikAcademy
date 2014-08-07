namespace AwesomeComputers.HardDrive
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The idea is to have sepparate class that can hold a list of HardDrives.
    /// </summary>
    public class RAID
    {
        private List<HardDrive> hardDrivesList;

        public List<HardDrive> HardDrivesList
        {
            get { return hardDrivesList; }
            set { hardDrivesList = value; }
        }

        public RAID()
        {
            this.HardDrivesList = null;
        }

        public RAID(List<HardDrive> hardDriveList)
        {
            this.HardDrivesList = hardDriveList;
        }

        public void SaveData(int adress, string data)
        { 
            // Invoke the SaveDataMethod of all hard drives in the Raid Array
            for (int i = 0; i < HardDrivesList.Count; i++)
            {
                HardDrivesList[i].SaveData(adress, data);
            }
        }

        public void LoadData(int address)
        { 
            //  Invode LoadDataMethod from the first hard drive in the Raid Array
            if (HardDrivesList.Count <= 0)
            {
                throw new ArgumentException("No hard drive in the RAID array!");
            }
            HardDrivesList[0].LoadData(address);
        }

        public void AddHardDrive(HardDrive newDrive)
        {
            HardDrivesList.Add(newDrive);
        }

        public void RemoveHardDrive(HardDrive driveToRemove)
        {
            HardDrivesList.Remove(driveToRemove);
        }
    }
}
