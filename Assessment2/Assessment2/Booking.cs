using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    class Booking
    {

        private DateTime arrival_date;
        private DateTime departure_date;
        private int booking_id = 0;

        public Guest guest;

        public int Booking_id
        {
            get { return booking_id; }
            set { booking_id = value; }
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

        public int getBookingId()
        {
            return booking_id++;
        }

        public int getDuration()
        {
            double stayDuration = (departure_date - arrival_date).TotalDays;
            return Convert.ToInt32(stayDuration);
        }
        /*public int getCost()
        {
            int ageprice = agePrice();
            int totalnights = getDuration();
            return ageprice * totalnights;*/

    }
}