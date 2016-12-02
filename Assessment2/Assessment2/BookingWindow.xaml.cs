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


namespace Assessment2
{
    /// <summary>
    /// Interaction logic for BookingWindow.xaml
    /// </summary>
    public partial class BookingWindow : Window
    {

        Booking booking = new Booking();
        Database db = new Database();


        public BookingWindow()
        {
            InitializeComponent();
        }

        List<Guest> allguests = new List<Guest>();
        Guest guest;

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (lstGuest.Items.Count < 4)
            {

                GuestDetails gd = new GuestDetails();
                gd.ShowDialog();

                guest = new Guest();
                guest.Name = gd.txtGuestName.Text;
                guest.Age = int.Parse(gd.txtGuestAge.Text);
                guest.PassportNo = gd.txtGuestPpNumber.Text;

                allguests.Add(guest);
            }
            else
            {
                MessageBox.Show("There is a maximum of 4 guests per booking.");

            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //dtpArrival.SelectedDate = booking.Arrival_date;
            //dtpDeparture.SelectedDate = booking.Departure_date;
            booking.Arrival_date = dtpArrival.SelectedDate.GetValueOrDefault();
            booking.Departure_date = dtpDeparture.SelectedDate.GetValueOrDefault();
            MessageBox.Show("" + booking.getDuration() + " " + booking.getCost());
        }

        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach (Guest g in allguests)
            {
                MessageBox.Show(" " + guest.Name);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            db.DBConnect();
            db.Insert();
            
        }
    }
}
