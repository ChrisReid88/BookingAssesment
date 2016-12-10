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
        //Creating a new booking and guest. Declaring private classes to be passed into
        Booking booking = new Booking();
        private Customer c;
        private DatabaseFacade data;
        Guest guest = new Guest();

        //Binding list to store all guest and be binded with a listbox
        BindingList<Guest> bindingguest = new BindingList<Guest>();

        public BookingWindow(Customer c, DatabaseFacade data)
        {
            InitializeComponent();
            // bind the list to the listbox

            lstGuest.ItemsSource = bindingguest;
            this.c = c;
            this.data = data;

        }

        //Calculating the price of breakfast added to the booking
        private void ckbBreakfast_Checked(object sender, RoutedEventArgs e)
        {
            //if breakfast is checked, breakfast = (duration * price) * number of guests
            if (ckbBreakfast.IsChecked == true)
            {
                booking.Breakfast = (booking.getDuration() * 5) * guest.NoOfGuests;
            }
        }
        //Calculating the price of breakfast added to the booking
        private void ckbDinner_Checked(object sender, RoutedEventArgs e)
        {
            //if dinner is checked, breakfast = (duration * price) * number of guests
            if (ckbDinner.IsChecked == true)
            {
                booking.Dinner = (booking.getDuration() * 15) * guest.NoOfGuests;
            }
        }

        //Adding on car hire to booking
        private void ckbCar_Checked(object sender, RoutedEventArgs e)
        {
            //If car hire is checked, price = £50
            if (ckbCar.IsChecked == true)
            {
                booking.CarHire = 50;
            }
        }

        //If a change in selection is made in the listbox
        private void lstGuest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Convert to string and store in selected
            if (lstGuest.SelectedIndex >= 0)
            {
                guest.selected = lstGuest.SelectedItem.ToString();
            }
        }

        //Adds a guest to the listbox
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //if the listbox has less than 4 guests in it
            if (lstGuest.Items.Count < 4)
            {
                //create new 'Guest Detail' window and pass in guest, binding list, customer and booking
                GuestDetails gd = new GuestDetails(guest, bindingguest, c, booking);

                //Show 'guest details' window
                gd.ShowDialog();

                //Calculate the total price of the the stay for all guests.
                booking.TotalStayPrice = booking.TotalStayPrice + guest.agePrice();
            }
            else
            {
                //If there are 4 guests in the listbox display this message
                MessageBox.Show("There is a maximum of 4 guests per booking.");
            }
            //Enable buttons to delete and edit customers that have been added into the listbox
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;

        }

        //Edit guest on the new booking page
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //If the listbox has items in it
            if (!(lstGuest.SelectedIndex == -1))
            {
                // Create a new 'Edit guest' window and pass in the guest and bindinglist
                EditGuest eg = new EditGuest(guest, bindingguest);

                //Split the string into different items using the delimiter '|'(name, age, passport number)
                string[] item = guest.selected.Split('|');

                //Display the item in the corresonding textbox on the 'Edit guest' page
                eg.txtEditName.Text = item[0];
                eg.txtEditAge.Text = item[1];
                eg.txtEditPp.Text = item[2];

                //Show 'edit gues' window and remove the currently selected item from the list/listbox
                eg.ShowDialog();
                bindingguest.RemoveAt(lstGuest.SelectedIndex);
            }
            else
            {
                //If no selection has been made, show this message
                MessageBox.Show("Please select a guest");
            }
        }


        //Deletes a guest from the listbox, list and database based on the selected item in the list
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //if there are items in the list
            if (!(lstGuest.SelectedIndex == -1))
            {
                //Store selected item as string and split with delimiter
                string selected = lstGuest.SelectedItem.ToString();
                string[] item = selected.Split('|');

                //Delete from database and remove from list
                data.DeleteGuest(item[2]);
                bindingguest.RemoveAt(lstGuest.SelectedIndex);
            }
        }

        //Creates and populates an invoice
        private void Invoice_Click(object sender, RoutedEventArgs e)
        {


            //count number of guest
            guest.NoOfGuests = lstGuest.Items.Count;

            //if checkbox breakfast is checked, calculate the price of breakfast * number of guests
            if (ckbBreakfast.IsChecked == true)
            {
                booking.Breakfast = booking.GetBreakfast() * guest.NoOfGuests;
            }
            else
            {
                booking.Breakfast = 0;
            }

            //if checkbox ddinner is checked, calculate the price of breakfast * number of guests
            if (ckbDinner.IsChecked == true)
            {
                booking.Dinner = booking.GetDinner() * guest.NoOfGuests;
            }
            else
            {
                booking.Dinner = 0;
            }

            //Calculate the cost of the whole booking
            booking.Cost = (booking.TotalStayPrice * booking.getDuration()) + booking.Breakfast + booking.Dinner + booking.CarHire;

            //Get the duration of the car hire
            booking.CarHire = booking.getHireDuration() * 50;

            //Get the arrival and departure dates from the datepickers
            booking.Arrival_date = dtpArrival.SelectedDate.GetValueOrDefault();
            booking.Departure_date = dtpDeparture.SelectedDate.GetValueOrDefault();

            //Create a new invoice and add the values to the labels on the window
            Invoice invoice = new Invoice(c, guest, booking);

            invoice.lblCustRef.Content = c.CustomerRef.ToString();
            invoice.lblCustName.Content = c.Name;
            invoice.lblCustAdd.Content = c.Address;
            invoice.lblArrival.Content = booking.Arrival_date.ToString("dd-MM-yyyy").ToString();
            invoice.lblDeparture.Content = booking.Departure_date.ToString("dd-MM-yyyy").ToString();
            invoice.lblDuration.Content = booking.getDuration().ToString() + " nights";
            invoice.lblGuests.Content = guest.NoOfGuests.ToString();
            invoice.lblPriceOfStay.Content = "£" + (booking.TotalStayPrice * booking.getDuration()).ToString();
            invoice.lblExtras.Content = "£" + (booking.Breakfast + booking.Dinner + booking.CarHire).ToString();
            invoice.lblTotal.Content = "£" + booking.Cost;
            invoice.lblBreakfast.Content = "£" + booking.Breakfast.ToString();
            invoice.lblDinner.Content = "£" + booking.Dinner.ToString();
            invoice.lblCarHire.Content = "£" + booking.CarHire.ToString();
            invoice.lblPricePerNight.Content = "£" + booking.TotalStayPrice.ToString();
            invoice.lblCarHireDuration.Content = booking.getHireDuration().ToString() + " days";

            invoice.ShowDialog();
            this.Close();
        }

        //Enables the user to progress to the next part of the new booking 
        private void btnNewBooking_Click(object sender, RoutedEventArgs e)
        {
            if (dtpArrival.SelectedDate.ToString() == "" || dtpDeparture.SelectedDate.ToString() == "")
            {
                MessageBox.Show("Please select a date range.");
            }
            else
            {
                //Get the arrival and departure date;
                booking.Arrival_date = dtpArrival.SelectedDate.GetValueOrDefault();
                booking.Departure_date = dtpDeparture.SelectedDate.GetValueOrDefault();

                //Enable buttons add guest button and disable this
                btnAdd.IsEnabled = true;
                btnNewBooking.IsEnabled = false;

                //Convert the date to sql format and insert the booking details into the database
                data.DBConnect();
                data.InsertBooking(booking.Arrival_date.ToString("yyyy-MM-dd"), booking.Departure_date.ToString("yyyy-MM-dd"), c.CustomerRef);
            }
        }


        //Returns the user to the main window and closes this
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        //Enables the user to add extras to their booking
        private void btnAddExtras_Click(object sender, RoutedEventArgs e)
        {
            //Create new 'Add extras' window and pass in the booking
            AddExtras ex = new AddExtras(booking);

            booking.HireStart = ex.dtpHireStart.SelectedDate.GetValueOrDefault();
            booking.HireEnd = ex.dtpHireStart.SelectedDate.GetValueOrDefault();

            //Manipulate which controls will be enables via the checked checkboxes
            if (ckbBreakfast.IsChecked == true)
            {
                ex.txtBreakDesc.IsEnabled = true;
            }
            if (ckbDinner.IsChecked == true)
            {
                ex.txtDinDesc.IsEnabled = true;
            }
            if (ckbCar.IsChecked == true)
            {
                ex.txtDriverName.IsEnabled = true;
                ex.dtpHireStart.IsEnabled = true;
                ex.dtpHireEnd.IsEnabled = true;
            }
            //Show the 'Add Extras' window
            ex.ShowDialog();
        }
    }
}
