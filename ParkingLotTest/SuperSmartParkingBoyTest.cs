using System;
using System.Collections.Generic;
using System.Text;
using ParkingLotSystem;

namespace ParkingLotTest
{
    using Xunit;
    public class SuperSmartParkingBoyTest
    {
        [Fact]
        public void SuperSmartParkingBoy_Should_park_cars_to_more_positionRate_parkingLot()
        {
            //given
            var parkingLots = new List<ParkingLot>() { { new ParkingLot(4) }, { new ParkingLot(6) }, { new ParkingLot(2) } };
            var superSmartParkingBoy = new SuperSmartParkingBoy();
            var parkingBoy = new ParkingBoy();
            //when
            for (int i = 0; i < 2; i++)
            {
                parkingBoy.Park(i.ToString(), parkingLots[0]);
                parkingBoy.Park(i.ToString(), parkingLots[1]);
            }

            var numberPlate = "XX2345";
            var parkingTicket = superSmartParkingBoy.Park(numberPlate, parkingLots);
            var expectParkingLot = parkingLots[2];
            //then
            Assert.NotEmpty(parkingTicket);
            Assert.Contains<string>("XX2345", expectParkingLot.ParkingCarsList);
        }
    }
}
