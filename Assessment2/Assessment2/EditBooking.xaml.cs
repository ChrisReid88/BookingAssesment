using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assessment2
{
    /// <summary>
    /// Interaction logic for EditBooking.xaml
    /// </summary>
    public partial class EditBooking : Window
    {
        private Database data = new Database();
        private Booking booking;
        private Customer c;
        private Guest g = new Guest();
     
        public EditBooking(Booking booking, Customer c)
        {
            InitializeComponent();
            this.booking = booking;
            this.c = c;
         
        }

        private void btnBookingUpdate_Click(object sender, RoutedEventArgs e)
        {
            booking.Arrival_date = dtpArrivalEdit.SelectedDate.GetValueOrDefault();
            booking.Departure_date = dtpDepartureEdit.SelectedDate.GetValueOrDefault();
            data.DBConnect();
            data.EditBooking(booking.Arrival_date.ToString("yyyy-MM-dd"), booking.Departure_date.ToString("yyyy-MM-dd"));
            data.DBConnect();
            data.EditGuest(txtEditGuestName.Text, Int32.Parse(txtEditGuestAge.Text), txtGuestPN.Text);
        }

        private void cbbGuests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtEditGuestAge.IsEnabled = true;
            txtEditGuestName.IsEnabled = true;
            txtEditGuestName.SelectedItem 
            
        }


    }
}
