using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



        public int BookingRef
        {
            get { return bookingRef; }
            set { bookingRef = value; }
        }
        public int CustomerRef
        {
            get { return bookingRef; }
            set { bookingRef = value; }
        }


        public int TotalStayPrice
        {
            get { return totalStayPrice; }
            set { totalStayPrice = value; }
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

        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public int getDuration()
        {
            double stayDuration = (departure_date - arrival_date).TotalDays;
            return Convert.ToInt32(stayDuration);
        }
    }
}