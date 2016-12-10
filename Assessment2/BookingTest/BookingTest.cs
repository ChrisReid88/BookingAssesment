using System;
using Assessment2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookingTest
{
    [TestClass]
    public class BookingTest
    {
        [TestMethod]
        public void GetDuration()
        {
            //arrange
            DateTime arrival = new DateTime(10 - 12 - 2016);
            DateTime Departure = new DateTime(15 - 12 - 2016);
            double expectedDuration = (Departure - arrival).TotalDays;
            Booking booking = new Booking();

            //act
            int duration = booking.getDuration();

            //assert
            Assert.AreEqual(expectedDuration, duration);
        }
    }
}
