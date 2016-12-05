using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    public class Booking
    {

        private DateTime arrival_date;
        private DateTime departure_date;
        private int bookingRef;



        public int BookingRef
        {
            get { return bookingRef; }
            set { bookingRef = value; }
        }

        public DateTime Arrival_date
        {
            get { return arrival_date; }
            set { arrival_date = value; }
        }
        public DateTime Departure_date
        {
            get { return departure_date; }
            set { departure_date = value; }
        }

        public int getDuration()
        {
            double stayDuration = (departure_date - arrival_date).TotalDays;
            return Convert.ToInt32(stayDuration);
        }
    }
}