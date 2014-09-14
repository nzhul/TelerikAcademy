namespace CableCompany
{
    using System;
    public class HouseConnection : IComparable<HouseConnection>
    {
        public int StartHouse { get; set; }
        public int EndHouse { get; set; }
        public int ConnectionLength { get; set; }

        public HouseConnection(int startHouse, int endHouse, int connectionLength)
        {
            this.StartHouse = startHouse;
            this.EndHouse = endHouse;
            this.ConnectionLength = connectionLength;
        }

        public int CompareTo(HouseConnection other)
        {
            int weightCompared = this.ConnectionLength.CompareTo(other.ConnectionLength);

            if (weightCompared == 0)
            {
                return this.StartHouse.CompareTo(other.StartHouse);
            }
            return weightCompared;
        }

        public override string ToString()
        {
            return String.Format("({0} {1}) -> {2}", this.StartHouse, this.EndHouse, this.ConnectionLength);
        }
    }
}
