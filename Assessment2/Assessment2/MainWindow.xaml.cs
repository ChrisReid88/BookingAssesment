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
        //Creating new instances of classes
        Database data = new Database();
        Customer c = new Customer();
        Guest guest = new Guest();

        public MainWindow()
        {
            InitializeComponent();
        }

        //Creates a new booking, using the customer details added
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
         if (!(txtCustName.Text == "" && txtCustAddress.Text == ""))
            {
                //Creates new instance of booking window and assigns customer details rom textboxes to labels for reference.
                BookingWindow bw = new BookingWindow(c, data);
                c.Name = txtCustName.Text;
                c.Address = txtCustAddress.Text;
                bw.lblCustName.Content = txtCustName.Text;
                bw.lblCustAddress.Content = txtCustAddress.Text;

                //Inserts the customer details into database
                data.DBConnect();
                data.InsertCustomer(c.Name, c.Address);

                //Displays booking window and hides current window
                bw.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please insert new customer details to create a booking.");
            }
            
   
        }

        //Enables user to edit a customers details
        private void btnEditCust_Click(object sender, RoutedEventArgs e)
        {
            //Pulls customer details from the database using the customer reference number entered in textbox
            data.DBConnect();
            Customer c2 = data.SetCustomer(Int32.Parse(txtEditCustP.Text));

            //Creates a new 'edit customer' window and loads current customer values into the relevant textboxes, then displays the window 
            EditCustomer ec = new EditCustomer(c2);
            ec.txtEditCustRef.Text = txtEditCustP.Text;
            ec.txtEditCustName.Text = c2.Name;
            ec.txtEditCustAddress.Text = c2.Address;
            ec.ShowDialog();
        }


        //Loads a customer
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            //Pulls customer details from database using customer reference number entered
            data.DBConnect();
            Customer c = data.SetCustomer(Int32.Parse(txtEditCustP.Text));

            //Creates a new booking window and assigns the values from the customer query to labels on new booking window
            BookingWindow bw = new BookingWindow(c, data);
            bw.lblCustName.Content = c.Name;
            bw.lblCustAddress.Content = c.Address;

            //Opens the new booking window and hides current window
            bw.Show();
            this.Hide();
        }

        //Manipulates the  layout of edit customer section
        private void txtEditCustP_TextChanged(object sender, TextChangedEventArgs e)
        {
            //If text gets added to the edit customer textbox, relevant buttons are enabled
            if (txtEditCustP.Text != "")
            {
                btnLoad.IsEnabled = true;
                btnEditCust.IsEnabled = true;
                btnDeleteCustomer.IsEnabled = true;
            }
            else
            {
                btnLoad.IsEnabled = false;
                btnEditCust.IsEnabled = false;
                btnDeleteCustomer.IsEnabled = false;
            }
        }

        //Loads a booking based on booking reference entered enabling the user to edit it
        private void btnLoadBooking_Click(object sender, RoutedEventArgs e)
        {
            //Pull booking and customer details from database
            data.DBConnect();
            Booking booking = data.SetBooking(Int32.Parse(txtBookingReference.Text));
            Customer customer = data.SetCustomer(booking.CustomerRef);
            Extras extras = data.SetExtras(Int32.Parse(txtBookingReference.Text));

            //Create new 'edit booking' window and pass in classes
            EditBooking eb = new EditBooking(booking, c, guest);

            //Displays and sets the on the booking window to the values taken from the database
            eb.lblBookingRef.Content = booking.BookingRef;
            eb.dtpArrivalEdit.SelectedDate = booking.Arrival_date;
            eb.dtpDepartureEdit.SelectedDate = booking.Departure_date;
            eb.lblCustomerName.Content = customer.Name;
            eb.lblCustomerRef.Content = customer.CustomerRef;
            eb.txtDinnerDesc.Text = extras.DDesc;
            eb.txtBreakfastDesc.Text = extras.BDesc;
            eb.txtCarHireName.Text = extras.HireName;
            eb.dtpHireStart.SelectedDate = extras.HireStart;
            eb.dtpHireEnd.SelectedDate = extras.HireEnd;
 
            //Inserts list of guests taken from database into the combobox on the edit booking window
            data.DBConnect();
            eb.cbbGuests.ItemsSource = data.SetGuest(Int32.Parse(txtBookingReference.Text));

            //Show 'edit booking' window, close current window
            eb.Show();
            this.Close();
        }

        //Manipulate the layout of the 'edit booking' section
        private void txtBookingReference_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if text gets added to the textbox, enable the buttons associated with it
            if (txtBookingReference.Text != "")
            {
                btnDeleteBooking.IsEnabled = true;
                btnLoadBooking.IsEnabled = true;
            }
            else
            {
                btnDeleteBooking.IsEnabled = false;
                btnLoadBooking.IsEnabled = false;
            }
        }

        //Delete a booking(Extra measurements to ensure booking is not accidentally deleted)
        private void btnDeleteBooking_Click(object sender, RoutedEventArgs e)
        {
            //Display message box requesting confirmation of delete. Display yes or no buttons.
            MessageBoxResult mbresult = MessageBox.Show("Are you sure you wish to delete this booking?", "Confirm", MessageBoxButton.YesNo);
            if (mbresult == MessageBoxResult.Yes)
            {
                data.DBConnect();
                data.DeleteBooking(Int32.Parse(txtBookingReference.Text));

            }
        }

        //Delete a customer(Extra measurements to ensure booking is not accidentally deleted)
        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            //Display message box requesting confirmation of delete. Display yes or no buttons.
            MessageBoxResult mbresult = MessageBox.Show("Are you sure you wish to delete this booking?", "Confirm", MessageBoxButton.YesNo);
            if (mbresult == MessageBoxResult.Yes)
            {
                data.DBConnect();
                data.DeleteCustomer(Int32.Parse(txtEditCustP.Text));
            }
        }
    }
}
