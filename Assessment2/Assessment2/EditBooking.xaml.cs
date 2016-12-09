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
        //New instanceof database and guest
        private Database data = new Database();
        private Guest g = new Guest();

        //declaring a booking and customer to use for referencing
        private Booking booking;
        private Customer c;

        public EditBooking(Booking booking, Customer c, Guest guest)
        {
            InitializeComponent();
            this.booking = booking;
            this.c = c;
            this.g = guest;
        }

        //Used apply the changes of the booking
        private void btnBookingUpdate_Click(object sender, RoutedEventArgs e)
        {
           

            booking.Arrival_date = dtpArrivalEdit.SelectedDate.GetValueOrDefault();
            booking.Departure_date = dtpDepartureEdit.SelectedDate.GetValueOrDefault();
            data.DBConnect();
            data.EditBooking(booking.Arrival_date.ToString("yyyy-MM-dd"), booking.Departure_date.ToString("yyyy-MM-dd"));
            data.DBConnect();

        }


        private void cbbGuests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtEditGuestAge.IsEnabled = true;
            txtEditGuestName.IsEnabled = true;
            string selected = cbbGuests.SelectedItem.ToString();
            string[] item = selected.Split('|');
            txtEditGuestName.Text = item[0];
            txtEditGuestAge.Text = item[1];
            txtGuestPN.Text = item[2];

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (cbbGuests.SelectedItem == null)
            {
                MessageBox.Show("Please select a guest");
            }
            else
            {
                data.DBConnect();
                data.EditGuest(txtEditGuestName.Text, Int32.Parse(txtEditGuestAge.Text), txtGuestPN.Text);
                MessageBox.Show("Guest has been successfully changed.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (cbbGuests.SelectedItem == null)
            {
                MessageBox.Show("Please select a guest");
            }
            else
            {
                data.DBConnect();
                data.DeleteGuest(txtGuestPN.Text);

                MessageBox.Show("Guest successfully deleted.");
            }
        }

        private void btnUpdateExtras_Click(object sender, RoutedEventArgs e)
        {
            
            data.DBConnect();
            data.EditExtras(txtBreakfastDesc.Text, txtDinnerDesc.Text, txtCarHireName.Text, booking.HireStart.ToString("yyyy-MM-dd"), booking.HireEnd.ToString("yyyy-MM-dd"), Int32.Parse(lblBookingRef.Content.ToString()));
            MessageBox.Show("Extras successfully update");
            booking.TotalStayPrice = booking.TotalStayPrice + g.agePrice();
            booking.Cost = (booking.TotalStayPrice * booking.getDuration()) + booking.Breakfast + booking.Dinner + booking.CarHire;
        }

        private void btnUpdatedInvoice_Click(object sender, RoutedEventArgs e)
        {
            data.DBConnect();
            Customer c2 = data.SetCustomer(Int32.Parse(lblCustomerRef.Content.ToString()));

            //Get the car hire dates
            booking.HireStart = dtpHireStart.SelectedDate.GetValueOrDefault();
            booking.HireEnd = dtpHireEnd.SelectedDate.GetValueOrDefault();

            //Set number of guests and calculate the total price of the stay
            g.NoOfGuests = cbbGuests.Items.Count;  

            //Get the arrival and departure dates from the datepickers
            booking.Arrival_date = dtpArrivalEdit.SelectedDate.GetValueOrDefault();
            booking.Departure_date = dtpDepartureEdit.SelectedDate.GetValueOrDefault();

            //Calculating breakfast price by description box. (Needs changed)
            if (txtBreakfastDesc.Text != "")
            {
                booking.Breakfast = booking.GetBreakfast() * g.NoOfGuests;
                btnRemoveBreakfast.IsEnabled = true;
            }
            else
            {
                btnRemoveBreakfast.IsEnabled = false;
                booking.Breakfast = 0;
            }

            //Calculating Dinner price by description box. (Needs changed)
            if (txtDinnerDesc.Text != "")
            {
                booking.Dinner = booking.GetDinner() * g.NoOfGuests;
                btnRemoveDinner.IsEnabled = true;
            }
            else
            {
                btnRemoveDinner.IsEnabled = false;
                booking.Dinner = 0;
            }

            //Calculating car hire price by description box. (Needs changed)
            if (txtCarHireName.Text != "")
            {
                booking.CarHire = booking.getHireDuration() * 50;
                btnRemoveCarHire.IsEnabled = true;
            }
            else
            {
                btnRemoveCarHire.IsEnabled = false;
                booking.Dinner = 0;
            }

            MessageBox.Show(booking.getHireDuration() + "");

            //Calculating the price to stay
            booking.TotalStayPrice = booking.TotalStayPrice + g.agePrice();
            booking.Cost = (booking.TotalStayPrice * booking.getDuration()) + booking.Breakfast + booking.Dinner + booking.CarHire;

            //Create a new invoice and add the values to the labels on the window
            Invoice invoice = new Invoice(c, g, booking);

            invoice.lblCustRef.Content = this.lblCustomerRef.Content;
            invoice.lblCustName.Content = this.lblCustomerName.Content;
            invoice.lblCustAdd.Content = c2.Address;
            invoice.lblArrival.Content = booking.Arrival_date.ToString("dd-MM-yyyy").ToString();
            invoice.lblDeparture.Content = booking.Departure_date.ToString("dd-MM-yyyy").ToString();
            invoice.lblDuration.Content = booking.getDuration().ToString();
            invoice.lblGuests.Content = g.NoOfGuests.ToString();
            invoice.lblPriceOfStay.Content = "£" + (booking.TotalStayPrice * booking.getDuration()).ToString();
            invoice.lblExtras.Content = "£" + (booking.Breakfast + booking.Dinner + booking.CarHire).ToString();
            invoice.lblTotal.Content = "£" + booking.Cost;
            invoice.lblBreakfast.Content = "£" + booking.Breakfast.ToString();
            invoice.lblDinner.Content = "£" + booking.Dinner.ToString();
            invoice.lblCarHire.Content = "£" + booking.CarHire.ToString();
            invoice.lblCarHireDuration.Content = booking.getHireDuration().ToString();

            invoice.ShowDialog();
        }

        //Remove dinner description and disable the remove button
        private void btnRemoveDinner_Click(object sender, RoutedEventArgs e)
        {
            txtDinnerDesc.Text = "";
            btnRemoveDinner.IsEnabled = false;
        }

        //Remove breakfast description and disable the remove button
        private void btnRemoveBreakfast_Click(object sender, RoutedEventArgs e)
        {
            txtBreakfastDesc.Text = "";
            btnRemoveBreakfast.IsEnabled = false;
        }



    }
}