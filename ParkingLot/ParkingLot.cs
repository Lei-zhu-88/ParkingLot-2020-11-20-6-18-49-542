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
            if (numberPlate == null || ParkingCarsList.Contains(numberPlate))
            {
                return string.Empty;
            }

            if (ParkingCarsList.Count >= this.parkingCapacity)
            {
                ErrorMessage = "Not enough position.";
                return string.Empty;
            }

            Random random = new Random();
            ParkingCarsList.Add(numberPlate);
            string parkingTicket = numberPlate + random.Next(100, 999).ToString();
            return parkingTicket;
        }

        public string Fetch(string parkingTicket)
        {
            if (parkingTicket == null)
            {
                ErrorMessage = "Please provide your parking ticket.";
                return string.Empty;
            }

            var numberPlate = Decode(parkingTicket);

            if (!ParkingCarsList.Contains(numberPlate) || UsedTicketList.Contains(parkingTicket))
            {
                ErrorMessage = "Unrecognized parking ticket";
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
