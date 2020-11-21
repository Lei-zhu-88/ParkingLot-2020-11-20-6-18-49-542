using System;

namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void Sould_return_something_when_park()
        {
            //given
            var parkingLotSystem = new ParkingLotSystem();
            //when
            var numberPlate = "XX2345";
            //then
            Assert.NotNull(parkingLotSystem.Park(numberPlate));
        }

        [Fact]
        public void Return_a_parkingTicket_when_park()
        {
            //given
            var parkingLotSystem = new ParkingLotSystem();
            //when
            var numberPlate = "XX2345";
            //then
            Assert.IsType<string>(parkingLotSystem.Park(numberPlate));
            //Assert.Contains(ParkingLotSystem.Parkinglot, numberPlate);
        }

        [Fact]
        public void A_parkingLot_should_contain_this_car_after_park()
        {
            //given
            var parkingLotSystem = new ParkingLotSystem();
           //when
            var numberPlate = "XX2345";
            parkingLotSystem.Park(numberPlate);
            //then
            Assert.Contains<string>(numberPlate, parkingLotSystem.ParkingLot);
        }
    }
}
