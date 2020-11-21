using System.Collections.Generic;
using System.Linq;

namespace ParkingLotSystem
{
    using System;

    public class ParkingLot
    {
        private int parkingCapacity;

        public ParkingLot()
        {
            this.parkingCapacity = 10;
        }

        public ParkingLot(int parkingCapacity)
        {
            this.parkingCapacity = parkingCapacity;
        }

        public int ParkingCapacity
        {
            get { return parkingCapacity; }
        }
    }
}
