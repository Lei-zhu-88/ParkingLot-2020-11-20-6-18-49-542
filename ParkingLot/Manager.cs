using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotSystem
{
    public class Manager : ParkingBoy
    {
        public List<ParkingBoy> ParkingBoyList { get; set; } = new List<ParkingBoy>();

        public void AddParkingBoy(ParkingBoy parkingBoy)
        {
            ParkingBoyList.Add(parkingBoy);
        }
    }
}
