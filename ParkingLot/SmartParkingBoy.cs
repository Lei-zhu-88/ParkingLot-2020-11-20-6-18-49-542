using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLotSystem
{
    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy()
        {
        }

        public SmartParkingBoy(string name, List<ParkingLot> parkingLotList) : base(name, parkingLotList)
        {
        }

        public new string Park(string numberPlate, List<ParkingLot> parkingLots)
        {
            ParkingLot parkingLot = ChoseParkingLot(parkingLots);
            if (parkingLot == null)
            {
                ErrorMessage = "Not enough position.";
                return string.Empty;
            }

            if (numberPlate == null || IsParkedCar(numberPlate, parkingLots))
            {
                return string.Empty;
            }

            parkingLot.ParkingCarsList.Add(numberPlate);
            Random random = new Random();
            string parkingTicket = numberPlate + random.Next(100, 999).ToString();
            return parkingTicket;
        }

        public new ParkingLot ChoseParkingLot(List<ParkingLot> parkingLots)
        {
            int numberOfFullParkingLot = parkingLots.Where(parkingLot => parkingLot.LeftPosition == 0).Count();
            if (numberOfFullParkingLot == parkingLots.Count)
            {
                return null;
            }

            ParkingLot parkingLot = parkingLots.OrderByDescending(parkingLot => parkingLot.LeftPosition).ElementAt(0);
            return parkingLot;
        }
    }
}
