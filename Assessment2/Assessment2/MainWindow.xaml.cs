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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database data = new Database();
        Customer c = new Customer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BookingWindow bw = new BookingWindow(c, data);
                c.Name = txtCustName.Text;
                c.Address = txtCustAddress.Text;
                bw.lblCustName.Content = txtCustName.Text;
                bw.lblCustAddress.Content = txtCustAddress.Text;
                data.DBConnect();
                data.InsertCustomer(c.Name, c.Address);
                bw.Show();
                this.Hide();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void btnEditCust_Click(object sender, RoutedEventArgs e)
        {

            data.DBConnect();
            Customer c2 = data.SetCustomer(Int32.Parse(txtEditCustP.Text));
            EditCustomer ec = new EditCustomer(c2);
            ec.txtEditCustRef.Text = txtEditCustP.Text;
            ec.txtEditCustName.Text = c2.Name;
            ec.txtEditCustAddress.Text = c2.Address;
            ec.ShowDialog();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            data.DBConnect();
            Customer c = data.SetCustomer(Int32.Parse(txtEditCustP.Text));
            BookingWindow bw = new BookingWindow(c, data);
            bw.lblCustName.Content = c.Name;
            bw.lblCustAddress.Content = c.Address;
            bw.Show();
            this.Hide();
        }

        private void txtEditCustP_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtEditCustP.Text != "")
            {
                btnLoad.IsEnabled = true;
                btnEditCust.IsEnabled = true;
            }
        }

        private void btnLoadBooking_Click(object sender, RoutedEventArgs e)
        {
            data.DBConnect();
            Booking booking = data.SetBooking(Int32.Parse(txtBookingReference.Text));
            Customer customer = data.SetCustomer(booking.CustomerRef);
            EditBooking eb = new EditBooking(booking, c);

            eb.lblBookingRef.Content = booking.BookingRef;
            eb.dtpArrivalEdit.SelectedDate = booking.Arrival_date;
            eb.dtpDepartureEdit.SelectedDate = booking.Departure_date;
            eb.lblCustomerName.Content = customer.Name;
            eb.lblCustomerRef.Content = customer.CustomerRef;

            data.DBConnect();
            eb.cbbGuests.ItemsSource = data.SetGuest(Int32.Parse(txtBookingReference.Text));

            eb.Show();
            this.Close();

        }


    }
}
