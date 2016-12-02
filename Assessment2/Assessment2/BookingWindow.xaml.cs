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
    /// Interaction logic for BookingWindow.xaml
    /// </summary>
    public partial class BookingWindow : Window
    {

        Booking booking = new Booking();
        Guest guest = new Guest();
      

        public BookingWindow()
        {
            InitializeComponent();
        }

        List<Guest> allguests = new List<Guest>();

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (lstGuest.Items.Count < 4)
            {                 
                GuestDetails gd = new GuestDetails();
                gd.ShowDialog();
                guest.Name = gd.txtGuestName.Text;
                guest.Age = int.Parse(gd.txtGuestAge.Text);
                guest.PassportNo = gd.txtGuestPpNumber.Text;
                lstGuest.Items.Add("Name: " + guest.Name + "| Age: " + guest.Age + "| Passport Number: " + guest.PassportNo);
                allguests.Add(guest);
            }
            else
            {
                MessageBox.Show("There is a maximum of 4 guests per booking.");

            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            dtpArrival.SelectedDate = booking.Arrival_date;
            dtpDeparture.SelectedDate = booking.Departure_date;

            MessageBox.Show("" +  booking.getCost());
        }

        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
