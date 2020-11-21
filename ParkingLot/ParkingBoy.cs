using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotSystem
{
    public class ParkingBoy
    {
        private List<string> usedTicketList = new List<string>();

        public string ErrorMessage
        {
            get;
            set;
        }

        public List<string> ParkingCarsList { get; set; } = new List<string>();

        public List<string> UsedTicketList
        {
            get { return usedTicketList; }
            set { usedTicketList = value; }
        }

        public string Park(string numberPlate, int parkingLotCapacity)
        {
            if (numberPlate == null || ParkingCarsList.Contains(numberPlate))
            {
                return string.Empty;
            }

            if (ParkingCarsList.Count >= parkingLotCapacity)
            {
                ErrorMessage = "Not enough position.";
                return string.Empty;
            }

            ParkingCarsList.Add(numberPlate);
            Random random = new Random();
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

