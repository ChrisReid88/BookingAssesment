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
            booking.BookingRef = 0;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (lstGuest.Items.Count < 4)
            {
                GuestDetails gd = new GuestDetails(guest, bindingguest, c, booking);
                gd.ShowDialog();
            }
            else
            {
                MessageBox.Show("There is a maximum of 4 guests per booking.");
            }
            btnEdit.IsEnabled = true;
        }



        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!(lstGuest.SelectedIndex == -1))
            {
                GuestDetails gd = new GuestDetails(guest, bindingguest, c, booking);
                string selected = lstGuest.SelectedItem.ToString();
                string[] item = selected.Split(' | ');

                data.EditGuest(item[0], Int32.Parse(item[1]), item[2]);
                gd.txtGuestName.Text = item[0];
                gd.txtGuestAge.Text = item[1];
                gd.txtGuestPpNumber.Text = item[2];
                gd.btnGuestAdd.Content = "Amend Guest";
                gd.ShowDialog();
                MessageBox.Show(item[2]);
            }
            else
            {
                MessageBox.Show("Please select a guest");
            }
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            btnAdd.IsEnabled = true;
            booking.Arrival_date = dtpArrival.SelectedDate.GetValueOrDefault();
            booking.Departure_date = dtpDeparture.SelectedDate.GetValueOrDefault();
            int stayPrice = guest.agePrice();
            int stay = booking.getDuration();
            int cost = stayPrice * stay;
            data.DBConnect();
            data.InsertCustomer(c.Name, c.Address);
            data.InsertBooking(booking.Arrival_date, booking.Departure_date,c.CustomerRef);
        }
    }
}
