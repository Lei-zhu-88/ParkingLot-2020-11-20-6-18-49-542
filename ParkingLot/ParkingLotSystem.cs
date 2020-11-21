using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    using System;

    public class ParkingLotSystem
    {
        private List<string> parkingLot = new List<string>();
        private List<string> usedTicketList = new List<string>();

        public List<string> ParkingLot
        {
            get { return parkingLot; }
            set { parkingLot = value; }
        }

        public List<string> UsedTicketList
        {
            get { return usedTicketList; }
            set { usedTicketList = value; }
        }

        public string Park(string numberPlate)
        {
            Random random = new Random();
            ParkingLot.Add(numberPlate);
            string parkingTicket = numberPlate + random.Next(100, 999).ToString();
            return parkingTicket;
        }

        public string Fetch(string parkingTicket)
        {
            var numberPlate = Decode(parkingTicket);

            if (!ParkingLot.Contains(numberPlate))
            {
                Console.WriteLine("No excite this car");
            }

            if (UsedTicketList.Contains(parkingTicket))
            {
                return string.Empty;
            }

            ParkingLot.Remove(numberPlate);
            UsedTicketList.Add(parkingTicket);
            return numberPlate;
        }

        public string Decode(string parkingTicket)
        {
            if (parkingTicket.Length == 0 || ParkingLot.Count == 0)
            {
                return string.Empty;
            }

            return parkingTicket.Substring(0, ParkingLot[0].Length);
        }
    }
}
