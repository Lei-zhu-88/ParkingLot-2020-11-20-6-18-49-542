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
            //Assert.IsType(parkingLotSystem.Park(numberPlate), String);
            //Assert.Contains(ParkingLotSystem.Parkinglot, numberPlate);
        }
    }
}
