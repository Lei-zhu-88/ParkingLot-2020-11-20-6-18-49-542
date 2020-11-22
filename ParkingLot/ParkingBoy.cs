using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotSystem
{
    public class ParkingBoy
    {
        private readonly string name;
        public ParkingBoy()
        {
            this.name = null;
        }

        //public parkingboy(string name)
        //{
        //    this.name = name;
        //}

        public ParkingBoy(string name, List<ParkingLot> parkingLotList)
        {
            this.name = name;
            foreach (var parkingLot in parkingLotList)
            {
                BoyParkingLotList.Add(parkingLot);
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string ErrorMessage
        {
            get;
            set;
        }

        public List<string> UsedTicketList { get; set; } = new List<string>();
        public List<ParkingLot> BoyParkingLotList { get; set; } = new List<ParkingLot>();

        public string Park(string numberPlate, ParkingLot parkingLot)
        {
            if (numberPlate == null || parkingLot.ParkingCarsList.Contains(numberPlate))
            {
                return string.Empty;
            }

            if (parkingLot.ParkingCarsList.Count >= parkingLot.ParkingCapacity)
            {
                ErrorMessage = "Not enough position.";
                return string.Empty;
            }

            parkingLot.ParkingCarsList.Add(numberPlate);
            Random random = new Random();
            string parkingTicket = numberPlate + random.Next(100, 999).ToString();
            return parkingTicket;
        }

        public string Park(string numberPlate, List<ParkingLot> parkingLots)
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

        public string Fetch(string parkingTicket, ParkingLot parkingLot)
        {
            if (parkingTicket == null)
            {
                ErrorMessage = "Please provide your parking ticket.";
                return string.Empty;
            }

            var numberPlate = Decode(parkingTicket);

            if (!parkingLot.ParkingCarsList.Contains(numberPlate) || UsedTicketList.Contains(parkingTicket))
            {
                ErrorMessage = "Unrecognized parking ticket";
                return string.Empty;
            }

            parkingLot.ParkingCarsList.Remove(numberPlate);
            UsedTicketList.Add(parkingTicket);
            return numberPlate;
        }

        public string Decode(string parkingTicket)
        {
            return parkingTicket.Remove(parkingTicket.Length - 3);
        }

        public ParkingLot ChoseParkingLot(List<ParkingLot> parkingLots)
        {
            int parkingLotIndex = 0;
            foreach (var parkingLot in parkingLots)
            {
                if (parkingLot.IsFull)
                {
                    parkingLotIndex++;
                }
            }

            if (parkingLotIndex > parkingLots.Count - 1)
            {
                return null;
            }

            return parkingLots[parkingLotIndex];
        }

        public bool IsParkedCar(string numberPlate, List<ParkingLot> parkingLots)
        {
            foreach (var parkingLot in parkingLots)
            {
                if (parkingLot.ParkingCarsList.Contains(numberPlate))
                {
                    return true;
                }
            }

            return false;
        }
    }
}