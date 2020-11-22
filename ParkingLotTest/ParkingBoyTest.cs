using System;
using System.Collections.Generic;
using ParkingLotSystem;

namespace ParkingLotSystemTest
{
    using Xunit;

    public class ParkingBoyTest
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
            Assert.NotNull(parkingBoy.Park(numberPlate, parkingLot));
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
            Assert.IsType<string>(parkingBoy.Park(numberPlate, parkingLot));
        }

        [Fact]
        public void A_parkingLot_should_contain_this_car_after_park()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            //when
            string numberPlate = "XX2";
            var ticket = parkingBoy.Park(numberPlate, parkingLot);
            //then
            Assert.NotEmpty(ticket);
            Assert.Contains<string>("XX2", parkingLot.ParkingCarsList);
        }

        [Fact]
        public void Car_Should_be_fetched_according_to_parking_ticket()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            //when
            var numberPlate = "XX2345";
            var parkingTicket = parkingBoy.Park(numberPlate, parkingLot);
            var actual = parkingBoy.Fetch(parkingTicket, parkingLot);
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
            var parkingTicket = parkingBoy.Park(numberPlate, parkingLot);
            var actual = parkingBoy.Fetch(parkingTicket, parkingLot);
            //then
            Assert.DoesNotContain(numberPlate, parkingLot.ParkingCarsList);
        }

        [Fact]
        public void Car_Should_not_be_fetched_according_to_used_parking_ticket()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            //when
            var numberPlate = "XX2345";
            var parkingTicket = parkingBoy.Park(numberPlate, parkingLot);
            parkingBoy.Fetch(parkingTicket, parkingLot);
            var actual = parkingBoy.Fetch(parkingTicket, parkingLot);
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
            var actual = parkingBoy.Park(numberPlate, parkingLot);
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
                parkingBoy.Park(i.ToString(), parkingLot);
            }

            var actual = parkingBoy.Park(numberPlate, parkingLot);
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
            var actual = parkingBoy.Park(numberPlate, parkingLot);
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
            parkingBoy.Park(numberPlate, parkingLot);
            var actual = parkingBoy.Park(numberPlate, parkingLot);
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
            var parkingTicket = parkingBoy.Park(numberPlate, parkingLot);
            parkingBoy.Fetch("111111", parkingLot);
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
            var parkingTicket = parkingBoy.Park(numberPlate, parkingLot);
            parkingBoy.Fetch(null, parkingLot);
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
                parkingBoy.Park(i.ToString(), parkingLot);
            }

            var numberPlate = "XX2345";
            parkingBoy.Park(numberPlate, parkingLot);
            var actual = parkingBoy.ErrorMessage;
            var expect = "Not enough position.";
            //then
            Assert.Equal(expect, actual);
        }

        [Fact]
        public void ParkingBoy_Should_park_cars_to_parkingLots_in_sequence()
        {
            //given
            var parkingLots = new List<ParkingLot>() { { new ParkingLot(2) }, { new ParkingLot() } };
            var parkingBoy = new ParkingBoy();
            //when
            for (int i = 0; i < 2; i++)
            {
                parkingBoy.Park(i.ToString(), parkingLots);
            }

            var numberPlate = "XX2345";
            var parkingTicket = parkingBoy.Park(numberPlate, parkingLots);
            var actualParkingLot = parkingLots[1];
            //then
            Assert.NotEmpty(parkingTicket);
            Assert.Contains<string>("XX2345", actualParkingLot.ParkingCarsList);
        }

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
