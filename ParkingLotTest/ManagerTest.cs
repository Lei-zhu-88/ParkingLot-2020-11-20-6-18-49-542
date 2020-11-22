using System;
using System.Collections.Generic;
using System.Text;
using ParkingLotSystem;

namespace ParkingLotTest
{
    using Xunit;
    public class ManagerTest
    {
        [Fact]
        public void Manager_Should_able_to_Add_all_kinds_of_parkingboys_to_his_list()
        {
            //given
            var superSmartParkingBoy = new SuperSmartParkingBoy();
            var smartParkingBoy = new SmartParkingBoy();
            var parkingBoy = new ParkingBoy();
            var manager = new Manager();

            //when
            manager.AddParkingBoy(parkingBoy);
            manager.AddParkingBoy(smartParkingBoy);
            manager.AddParkingBoy(superSmartParkingBoy);
            //then
            Assert.Contains<ParkingBoy>(parkingBoy, manager.ParkingBoyList);
            Assert.Contains<ParkingBoy>(smartParkingBoy, manager.ParkingBoyList);
            Assert.Contains<ParkingBoy>(superSmartParkingBoy, manager.ParkingBoyList);
        }
    }
}
