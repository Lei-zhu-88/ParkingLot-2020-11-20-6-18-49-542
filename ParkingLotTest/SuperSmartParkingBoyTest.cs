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

        [Theory]
        [InlineData(1, 20, 50)]
        [InlineData(2, 4, 5)]
        public void More_test_cases_SuperSmartParkingBoy_Should_park_cars_to_more_positionRate_parkingLot(int parkingCapacity1, int parkingCapacity2, int parkingCapacity3)
        {
            //given
            var parkingLots = new List<ParkingLot>() { { new ParkingLot(parkingCapacity1) }, { new ParkingLot(parkingCapacity2) }, { new ParkingLot(parkingCapacity3) } };
            var superSmartParkingBoy = new SuperSmartParkingBoy();
            var parkingBoy = new ParkingBoy();
            //when
            for (int i = 0; i < 2; i++)
            {
                parkingBoy.Park(i.ToString(), parkingLots[1]);
                parkingBoy.Park(i.ToString(), parkingLots[2]);
            }

            var numberPlate = "XX2345";
            var parkingTicket = superSmartParkingBoy.Park(numberPlate, parkingLots);
            var expectParkingLot = parkingLots[0];
            //then
            Assert.NotEmpty(parkingTicket);
            Assert.Contains<string>("XX2345", expectParkingLot.ParkingCarsList);
        }
    }
}
