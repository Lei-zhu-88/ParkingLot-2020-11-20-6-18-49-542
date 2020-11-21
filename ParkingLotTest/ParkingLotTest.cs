using System;

namespace ParkingLotSystemTest
{
    using ParkingLotSystem;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Sould_return_something_when_park()
        {
            //given
            var parkingLotSystem = new ParkingLot();
            //when
            var numberPlate = "XX2345";
            //then
            Assert.NotNull(parkingLotSystem.Park(numberPlate));
        }

        [Fact]
        public void Return_a_parkingTicket_when_park()
        {
            //given
            var parkingLotSystem = new ParkingLot();
            //when
            var numberPlate = "XX2345";
            //then
            Assert.IsType<string>(parkingLotSystem.Park(numberPlate));
        }

        [Fact]
        public void A_parkingLot_should_contain_this_car_after_park()
        {
            //given
            var parkingLotSystem = new ParkingLot();
            //when
            var numberPlate = "XX2345";
            parkingLotSystem.Park(numberPlate);
            //then
            Assert.Contains<string>(numberPlate, parkingLotSystem.ParkingCarsList);
        }

        [Fact]
        public void Car_Should_be_fetched_according_to_parking_ticket()
        {
            //given
            var parkingLotSystem = new ParkingLot();
            //when
            var numberPlate = "XX2345";
            var parkingTicket = parkingLotSystem.Park(numberPlate);
            var actual = parkingLotSystem.Fetch(parkingTicket);
            //then
            Assert.Equal(numberPlate, actual);
        }

        [Fact]
        public void A_parkingLot_should_not_contain_this_car_after_fetched()
        {
            //given
            var parkingLotSystem = new ParkingLot();
            //when
            var numberPlate = "XX2345";
            var parkingTicket = parkingLotSystem.Park(numberPlate);
            var actual = parkingLotSystem.Fetch(parkingTicket);
            //then
            Assert.DoesNotContain(numberPlate, parkingLotSystem.ParkingCarsList);
        }

        [Fact]
        public void Car_Should_not_be_fetched_according_to_used_parking_ticket()
        {
            //given
            var parkingLotSystem = new ParkingLot();
            //when
            var numberPlate = "XX2345";
            var parkingTicket = parkingLotSystem.Park(numberPlate);
            parkingLotSystem.Fetch(parkingTicket);
            var actual = parkingLotSystem.Fetch(parkingTicket);
            //then
            Assert.Empty(actual);
        }

        [Fact]
        public void Car_Should_not_be_parked_if_no_position_in_parkinglot()
        {
            //given
            var parkingLot = new ParkingLot(0);
            //when
            var numberPlate = "XX2345";
            var actual = parkingLot.Park(numberPlate);
            //then
            Assert.Empty(actual);
        }

        [Fact]
        public void Car_Should_not_be_parked_if_parkinglot_is_full()
        {
            //given
            var parkingLot = new ParkingLot();
            //when
            var numberPlate = "XX2345";
            for (int i = 0; i < 10; i++)
            {
                parkingLot.Park(i.ToString());
            }

            var actual = parkingLot.Park(numberPlate);
            //then
            Assert.Empty(actual);
        }

        [Fact]
        public void Should_Return_no_parkingTicket_when_park_null_car()
        {
            //given
            var parkingLot = new ParkingLot();
            //when
            string numberPlate = null;
            var actual = parkingLot.Park(numberPlate);
            //then
            Assert.Empty(actual);
        }

        [Fact]
        public void Should_Return_no_parkingTicket_when_park_a_parked_car()
        {
            //given
            var parkingLot = new ParkingLot();
            //when
            string numberPlate = "XX2345";
            parkingLot.Park(numberPlate);
            var actual = parkingLot.Park(numberPlate);
            //then
            Assert.Empty(actual);
        }

        [Fact]
        public void ErrorMessage_Should_be_provided_When_wrong_ticket_is_given()
        {
            //given
            var parkingLot = new ParkingLot();
            //when
            var numberPlate = "XX2345";
            var parkingTicket = parkingLot.Park(numberPlate);
            parkingLot.Fetch("111111");
            var actual = parkingLot.ErrorMessage;
            var expect = "Unrecognized parking ticket";
            //then
            Assert.Equal(expect, actual);
        }

        [Fact]
        public void ErrorMessage_Should_be_provided_When_no_ticket_is_given()
        {
            //given
            var parkingLot = new ParkingLot();
            //when
            var numberPlate = "XX2345";
            var parkingTicket = parkingLot.Park(numberPlate);
            parkingLot.Fetch(null);
            var actual = parkingLot.ErrorMessage;
            var expect = "Please provide your parking ticket.";
            //then
            Assert.Equal(expect, actual);
        }
    }
}
