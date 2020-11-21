using System.Collections.Generic;

namespace ParkingLot
{
    using System;
    public class ParkingLotSystem
    {
        private List<string> parkingLot = new List<string>();
        public List<string> ParkingLot
        {
            get { return parkingLot; }
            set { parkingLot = value; }
        }

        public string Park(string numberPlate)
        {
            ParkingLot.Add(numberPlate);
             return DateTime.Now.ToString();
        }
    }
}
