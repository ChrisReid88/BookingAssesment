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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;


namespace Assessment2
{
    /// <summary>
    /// Interaction logic for BookingWindow.xaml
    /// </summary>
    public partial class BookingWindow : Window
    {
        Booking booking = new Booking();
        private Customer c;
        private Database data;
        Guest guest = new Guest();

        BindingList<Guest> bindingguest = new BindingList<Guest>();

        public BookingWindow(Customer c, Database data)
        {
            InitializeComponent();
            lstGuest.ItemsSource = bindingguest;
            this.c = c;
            this.data = data;
            booking.Arrival_date = dtpArrival.SelectedDate.GetValueOrDefault();
            booking.Departure_date = dtpDeparture.SelectedDate.GetValueOrDefault();


        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (lstGuest.Items.Count < 4)
            {
                
                GuestDetails gd = new GuestDetails(guest, bindingguest, c);
                gd.ShowDialog();
            }
            else
            {
                MessageBox.Show("There is a maximum of 4 guests per booking.");
            }
        }

        private void btnCalculate_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            int stayPrice = guest.agePrice();
            int stay = booking.getDuration();
            int cost = stayPrice * stay;

            MessageBox.Show("Duration: " + booking.getDuration() + " Price of stay: " + cost);
        }

        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var queryAllguests = from guest in bindingguest
                                 select guest;

            foreach (Guest guest in queryAllguests)
            {
                MessageBox.Show("" + guest);
            }
        }

        private void btnCalculate(object sender, RoutedEventArgs e)
        {

            booking.Arrival_date = dtpArrival.SelectedDate.GetValueOrDefault();
            booking.Departure_date = dtpDeparture.SelectedDate.GetValueOrDefault();
            //data.InsertBooking(booking.Arrival_date, booking.Departure_date);

        }
    }
}
