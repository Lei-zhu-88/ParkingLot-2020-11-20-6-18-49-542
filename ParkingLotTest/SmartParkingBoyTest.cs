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

        [Theory]
        [InlineData(1, 2, 4)]
        [InlineData(2, 4, 5)]
        public void SmartParkingBoy_Should_park_cars_to_more_space_parkingLot_with_cars(int parkingCapacity1, int parkingCapacity2, int parkingCapacity3)
        {
            //given
            var parkingLots = new List<ParkingLot>() { { new ParkingLot(parkingCapacity1) }, { new ParkingLot(parkingCapacity2) }, { new ParkingLot(parkingCapacity3) } };
            var smartParkingBoy = new SmartParkingBoy();
            var parkingBoy = new ParkingBoy();
            //when
            for (int i = 0; i < 2; i++)
            {
                parkingBoy.Park(i.ToString(), parkingLots[1]);
                parkingBoy.Park(i.ToString(), parkingLots[2]);
            }

            var numberPlate = "XX2345";
            var parkingTicket = smartParkingBoy.Park(numberPlate, parkingLots);
            var expectParkingLot = parkingLots[2];
            //then
            Assert.NotEmpty(parkingTicket);
            Assert.Contains<string>("XX2345", expectParkingLot.ParkingCarsList);
        }
    }
}
