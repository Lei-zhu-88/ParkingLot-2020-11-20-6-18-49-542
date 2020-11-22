using System;
using System.Collections.Generic;
using System.Text;
using ParkingLotSystem;

namespace ParkingLotTest
{
    using Xunit;
    public class SmartParkingBoyTest
    {
        [Fact]
        public void SmartParkingBoy_Should_park_cars_to_more_space_parkingLot_when_no_car()
        {
            //given
            var parkingLots = new List<ParkingLot>() { { new ParkingLot(2) }, { new ParkingLot(4) }, { new ParkingLot() } };
            var parkingBoy = new SmartParkingBoy();
            //when
            var numberPlate = "XX2345";
            var parkingTicket = parkingBoy.Park(numberPlate, parkingLots);
            var expectParkingLot = parkingLots[2];
            //then
            Assert.NotEmpty(parkingTicket);
            Assert.Contains<string>("XX2345", expectParkingLot.ParkingCarsList);
        }
    }
}
