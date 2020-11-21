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
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            //when
            var numberPlate = "XX2345";
            //then
            Assert.NotNull(parkingBoy.Park(numberPlate, parkingLot.ParkingCapacity));
        }

        [Fact]
        public void Return_a_parkingTicket_when_park()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            //when
            var numberPlate = "XX2345";
            //then
            Assert.IsType<string>(parkingBoy.Park(numberPlate, parkingLot.ParkingCapacity));
        }

        [Fact]
        public void A_parkingLot_should_contain_this_car_after_park()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            //when
            string numberPlate = "XX2";
            var ticket = parkingBoy.Park(numberPlate, parkingLot.ParkingCapacity);
            //then
            Assert.NotEmpty(ticket);
            Assert.Contains<string>("XX2", parkingBoy.ParkingCarsList);
        }

        [Fact]
        public void Car_Should_be_fetched_according_to_parking_ticket()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            //when
            var numberPlate = "XX2345";
            var parkingTicket = parkingBoy.Park(numberPlate, parkingLot.ParkingCapacity);
            var actual = parkingBoy.Fetch(parkingTicket);
            //then
            Assert.Equal(numberPlate, actual);
        }

        [Fact]
        public void A_parkingLot_should_not_contain_this_car_after_fetched()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            //when
            var numberPlate = "XX2345";
            var parkingTicket = parkingBoy.Park(numberPlate, parkingLot.ParkingCapacity);
            var actual = parkingBoy.Fetch(parkingTicket);
            //then
            Assert.DoesNotContain(numberPlate, parkingBoy.ParkingCarsList);
        }

        [Fact]
        public void Car_Should_not_be_fetched_according_to_used_parking_ticket()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            //when
            var numberPlate = "XX2345";
            var parkingTicket = parkingBoy.Park(numberPlate, parkingLot.ParkingCapacity);
            parkingBoy.Fetch(parkingTicket);
            var actual = parkingBoy.Fetch(parkingTicket);
            //then
            Assert.Empty(actual);
        }

        [Fact]
        public void Car_Should_not_be_parked_if_no_position_in_parkinglot()
        {
            //given
            var parkingLot = new ParkingLot(0);
            var parkingBoy = new ParkingBoy();
            //when
            var numberPlate = "XX2345";
            var actual = parkingBoy.Park(numberPlate, parkingLot.ParkingCapacity);
            //then
            Assert.Empty(actual);
        }

        [Fact]
        public void Car_Should_not_be_parked_if_parkinglot_is_full()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            //when
            var numberPlate = "XX2345";
            for (int i = 0; i < 10; i++)
            {
                parkingBoy.Park(i.ToString(), parkingLot.ParkingCapacity);
            }

            var actual = parkingBoy.Park(numberPlate, parkingLot.ParkingCapacity);
            //then
            Assert.Empty(actual);
        }

        [Fact]
        public void Should_Return_no_parkingTicket_when_park_null_car()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            //when
            string numberPlate = null;
            var actual = parkingBoy.Park(numberPlate, parkingLot.ParkingCapacity);
            //then
            Assert.Empty(actual);
        }

        [Fact]
        public void Should_Return_no_parkingTicket_when_park_a_parked_car()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            //when
            string numberPlate = "XX2345";
            parkingBoy.Park(numberPlate, parkingLot.ParkingCapacity);
            var actual = parkingBoy.Park(numberPlate, parkingLot.ParkingCapacity);
            //then
            Assert.Empty(actual);
        }

        [Fact]
        public void ErrorMessage_Should_be_provided_When_wrong_ticket_is_given()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            //when
            var numberPlate = "XX2345";
            var parkingTicket = parkingBoy.Park(numberPlate, parkingLot.ParkingCapacity);
            parkingBoy.Fetch("111111");
            var actual = parkingBoy.ErrorMessage;
            var expect = "Unrecognized parking ticket";
            //then
            Assert.Equal(expect, actual);
        }

        [Fact]
        public void ErrorMessage_Should_be_provided_When_no_ticket_is_given()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            //when
            var numberPlate = "XX2345";
            var parkingTicket = parkingBoy.Park(numberPlate, parkingLot.ParkingCapacity);
            parkingBoy.Fetch(null);
            var actual = parkingBoy.ErrorMessage;
            var expect = "Please provide your parking ticket.";
            //then
            Assert.Equal(expect, actual);
        }

        [Fact]
        public void ErrorMessage_Should_be_provided_if_parkinglot_is_full()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            //when
            for (int i = 0; i < 10; i++)
            {
                parkingBoy.Park(i.ToString(), parkingLot.ParkingCapacity);
            }

            var numberPlate = "XX2345";
            parkingBoy.Park(numberPlate, parkingLot.ParkingCapacity);
            var actual = parkingBoy.ErrorMessage;
            var expect = "Not enough position.";
            //then
            Assert.Equal(expect, actual);
        }
    }
}
