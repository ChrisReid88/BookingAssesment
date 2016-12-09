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
using System.ComponentModel;

namespace Assessment2
{
    /// <summary>
    /// Interaction logic for GuestDetails.xaml
    /// </summary>
    public partial class GuestDetails : Window
    {
        private Customer c;
        private Guest guest;
        private BindingList<Guest> bindingguest;
        Database db = new Database();
        private Booking booking;


        //Passing references
        public GuestDetails(Guest guest, BindingList<Guest> bindingguest, Customer c, Booking booking)
        {
            InitializeComponent();
            this.guest = guest;
            this.bindingguest = bindingguest;
            this.c = c;
            this.booking = booking;
        }

        //Adds guest to binding list/listbox and database
        private void btnGuestAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Takes values from textbox and assigns them to appropriate guest property
                db.DBConnect();
                guest.Name = txtGuestName.Text;
                guest.Age = int.Parse(txtGuestAge.Text);
                guest.PassportNo = txtGuestPpNumber.Text;

                //Inserts guest properties to database and binding list
                db.InsertGuest(guest.Name, guest.Age, guest.PassportNo, booking.BookingRef);
                bindingguest.Add(guest);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnGuestCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
