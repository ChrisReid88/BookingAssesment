using System;
using Assessment2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookingTest
{
    [TestClass]
    public class GetBreakfastTest
    {
        [TestMethod]
        public void GetBreakfast()
        {
            //arrange
            Booking booking = new Booking();
            booking.Arrival_date = new DateTime(10 - 12 - 2016);
            booking.Departure_date = new DateTime(15 - 12 - 2016);
            int dep = Convert.ToInt32(booking.Arrival_date);
            int arr = Convert.ToInt32(booking.Departure_date);
            int expectedResult = 5 * booking.getDuration();

            //act
            int breakfastPrice = booking.GetBreakfast();

            //Assert
            Assert.AreEqual(expectedResult, breakfastPrice);






        }
    }
}
