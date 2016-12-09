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

        private void ckbBreakfast_Checked(object sender, RoutedEventArgs e)
        {
            if (ckbBreakfast.IsChecked == true)
            {
                booking.Breakfast = (booking.getDuration() * 5) * guest.NoOfGuests;
            }
        }

        private void ckbDinner_Checked(object sender, RoutedEventArgs e)
        {
            if (ckbDinner.IsChecked == true)
            {
                booking.Dinner = (booking.getDuration() * 15) * guest.NoOfGuests;
            }
        }

        private void ckbCar_Checked(object sender, RoutedEventArgs e)
        {
            if (ckbCar.IsChecked == true)
            {
                booking.CarHire = 50;
            }
        }

        private void lstGuest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstGuest.SelectedIndex >= 0)
            {
                guest.selected = lstGuest.SelectedItem.ToString();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (lstGuest.Items.Count < 4)
            {
                GuestDetails gd = new GuestDetails(guest, bindingguest, c, booking);
                gd.ShowDialog();
                booking.TotalStayPrice = booking.TotalStayPrice + guest.agePrice();
                MessageBox.Show(c.Name);
            }
            else
            {
                MessageBox.Show("There is a maximum of 4 guests per booking.");
            }
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!(lstGuest.SelectedIndex == -1))
            {
                EditGuest eg = new EditGuest(guest, bindingguest);

                string[] item = guest.selected.Split('|');
                eg.txtEditName.Text = item[0];
                eg.txtEditAge.Text = item[1];
                eg.txtEditPp.Text = item[2];
                //data.SetGuest(item[0], Int32.Parse(item[1]), item[2]);
                eg.ShowDialog();
                bindingguest.RemoveAt(lstGuest.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Please select a guest");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!(lstGuest.SelectedIndex == -1))
            {
                string selected = lstGuest.SelectedItem.ToString();
                string[] item = selected.Split('|');
                data.DeleteGuest(item[2]);
                bindingguest.RemoveAt(lstGuest.SelectedIndex);
            }
        }

        private void Invoice_Click(object sender, RoutedEventArgs e)
        {
            guest.NoOfGuests = lstGuest.Items.Count;
            booking.Cost = (booking.TotalStayPrice * booking.getDuration()) + booking.Breakfast + booking.Dinner + booking.CarHire;

            booking.Arrival_date = dtpArrival.SelectedDate.GetValueOrDefault();
            booking.Departure_date = dtpDeparture.SelectedDate.GetValueOrDefault();

            Invoice invoice = new Invoice(c, guest, booking);
            invoice.lblCustRef.Content = c.CustomerRef.ToString();
            invoice.lblCustName.Content = c.Name;
            invoice.lblCustAdd.Content = c.Address;
            invoice.lblArrival.Content = booking.Arrival_date.ToString("dd-MM-yyyy").ToString();
            invoice.lblDeparture.Content = booking.Departure_date.ToString("dd-MM-yyyy").ToString();
            invoice.lblDuration.Content = booking.getDuration().ToString();
            invoice.lblGuests.Content = guest.NoOfGuests.ToString();
            invoice.lblPriceOfStay.Content = "£"+(booking.TotalStayPrice* booking.getDuration()).ToString();
            invoice.lblExtras.Content = "£" + (booking.Breakfast + booking.Dinner + booking.CarHire).ToString();
            invoice.lblTotal.Content = "£" + booking.Cost;
            invoice.lblBreakfast.Content = "£" + booking.Breakfast.ToString();
            invoice.lblDinner.Content = "£" + booking.Dinner.ToString();
            invoice.lblCarHire.Content = "£" + booking.CarHire.ToString();

            invoice.ShowDialog();
        }

    

        private void btnNewBooking_Click(object sender, RoutedEventArgs e)
        {
            booking.Arrival_date = dtpArrival.SelectedDate.GetValueOrDefault();
            booking.Departure_date = dtpDeparture.SelectedDate.GetValueOrDefault();
            btnAdd.IsEnabled = true;
            btnNewBooking.IsEnabled = false;
            dtpArrival.IsEnabled = true;
            dtpDeparture.IsEnabled = true;
            data.DBConnect();
            data.InsertBooking(booking.Arrival_date.ToString("yyyy-MM-dd"), booking.Departure_date.ToString("yyyy-MM-dd"), c.CustomerRef);
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

    
 

    }
}
