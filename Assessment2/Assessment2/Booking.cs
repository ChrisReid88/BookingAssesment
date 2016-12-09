using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Booking.cs
* 
*This class is used for creating the bookings and inherits 
 *from the Extras class
*
* Written by Chris Reid 1/12/16
*/

namespace Assessment2
{
    public class Booking : Extras
    {

        private DateTime arrival_date;
        private DateTime departure_date;
        private int bookingRef;
        private int customerRef;
        private int totalStayPrice;
        private int cost;


        //Property for manipulating booking reference
        public int BookingRef
        {
            get { return bookingRef; }
            set { bookingRef = value; }
        }
        //Property for manipulating customer reference
        public int CustomerRef
        {
            get { return bookingRef; }
            set { bookingRef = value; }
        }

        //Property for manipulating total stay price
        public int TotalStayPrice
        {
            get { return totalStayPrice; }
            set { totalStayPrice = value; }
        }

        //Property for manipulating arrival date
        public DateTime Arrival_date
        {
            get { return arrival_date; }
            set { arrival_date = value; }
        }

        //Property for manipulating the departure date
        public DateTime Departure_date
        {
            get { return departure_date; }
            set { departure_date = value; }
        }

        //Property for manipulating the total cost
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        //Method for calculating the duration of the stay
        public int getDuration()
        {
            double stayDuration = (departure_date - arrival_date).TotalDays;
            return Convert.ToInt32(stayDuration);
        }
        //return breakfast for duration
        public int GetBreakfast()
        {
           return Breakfast = (getDuration() * 5);
        }
        //return dinner for duration of stay
        public int GetDinner()
        {
            return Dinner = (getDuration() * 15);
        }
      
    }
}