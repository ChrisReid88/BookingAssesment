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
        Database db = new Database();
        Guest guest = new Guest();
        BindingList<Guest> bindingguest = new BindingList<Guest>(); 
       
        public BookingWindow()
        {
           InitializeComponent();
           lstGuest.ItemsSource = bindingguest;

        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (lstGuest.Items.Count < 4)
            {

                GuestDetails gd = new GuestDetails(guest, bindingguest);
                gd.ShowDialog();

                /*guest.Name = gd.txtGuestName.Text;
                guest.Age = int.Parse(gd.txtGuestAge.Text);
                guest.PassportNo = gd.txtGuestPpNumber.Text;
                lstGuest.Items.Add(guest.Name + " | " + guest.Age + " | " + guest.PassportNo);*/
                
            }
            else
            {
                MessageBox.Show("There is a maximum of 4 guests per booking.");
            }
        }
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            booking.Arrival_date = dtpArrival.SelectedDate.GetValueOrDefault();
            booking.Departure_date = dtpDeparture.SelectedDate.GetValueOrDefault();
            int stayPrice = guest.agePrice();
            int stay = booking.getDuration();
            int cost = stayPrice * stay;

            MessageBox.Show("Duration: " + booking.getDuration() + " Price of stay: " + cost);
        }

        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
           foreach (Guest guest in bindingguest)
           {
   
           }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
