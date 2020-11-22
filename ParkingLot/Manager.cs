using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLotSystem
{
    public class Manager : ParkingBoy
    {
        public List<ParkingBoy> ParkingBoyList { get; set; } = new List<ParkingBoy>();
        public ParkingLot ManagedParkingLot { get; set; } = new ParkingLot();

        public void AddParkingBoy(ParkingBoy parkingBoy)
        {
            ParkingBoyList.Add(parkingBoy);
        }

        public string SendBoyPark(string numberPlate, string boyName)
        {
            var parkingBoy = ParkingBoyList.Where(boy => boy.Name == boyName).ElementAt(0);
            return parkingBoy.Park(numberPlate, parkingBoy.BoyParkingLotList);
        }

        public string SendBoyFetch(string numberPlate, string boyName)
        {
            var parkingBoy = ParkingBoyList.Where(boy => boy.Name == boyName).ElementAt(0);
            return parkingBoy.Fetch(numberPlate, parkingBoy.BoyParkingLotList);
        }
    }
}
