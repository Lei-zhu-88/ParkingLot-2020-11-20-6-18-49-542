using System.Collections.Generic;
using System.Linq;

namespace ParkingLotSystem
{
    using System;

    public class ParkingLot
    {
        private List<string> parkingCarsList = new List<string>();
        private List<string> usedTicketList = new List<string>();

        private int parkingCapacity;

        public ParkingLot()
        {
            parkingCapacity = 10;
        }

        public ParkingLot(int parkingCapacity)
        {
            this.parkingCapacity = parkingCapacity;
        }

        public string ErrorMessage
        {
            get;
            set;
        }

        public List<string> ParkingCarsList
        {
            get { return parkingCarsList; }
            set { parkingCarsList = value; }
        }

        public List<string> UsedTicketList
        {
            get { return usedTicketList; }
            set { usedTicketList = value; }
        }

        public string Park(string numberPlate)
        {
            if (ParkingCarsList.Count >= this.parkingCapacity || numberPlate == null || ParkingCarsList.Contains(numberPlate))
            {
                return string.Empty;
            }

            Random random = new Random();
            ParkingCarsList.Add(numberPlate);
            string parkingTicket = numberPlate + random.Next(100, 999).ToString();
            return parkingTicket;
        }

        public string Fetch(string parkingTicket)
        {
            var numberPlate = Decode(parkingTicket);

            if (!ParkingCarsList.Contains(numberPlate))
            {
                ErrorMessage = "Unrecognized parking ticket";
            }

            if (UsedTicketList.Contains(parkingTicket))
            {
                return string.Empty;
            }

            ParkingCarsList.Remove(numberPlate);
            UsedTicketList.Add(parkingTicket);
            return numberPlate;
        }

        public string Decode(string parkingTicket)
        {
            if (parkingTicket.Length == 0 || ParkingCarsList.Count == 0)
            {
                return string.Empty;
            }

            return parkingTicket.Substring(0, ParkingCarsList[0].Length);
        }
    }
}
