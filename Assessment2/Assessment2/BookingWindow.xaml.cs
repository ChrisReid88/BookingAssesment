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

       
        //Guest guest = new Guest();
        Booking booking = new Booking();
        Guest guest = new Guest();

        public BookingWindow()
        {
            InitializeComponent();
        }



        private void btnAdd_Click(object sender, RoutedEventArgs e)
        { 
            GuestDetails gd = new GuestDetails();
            gd.ShowDialog();
            guest.Name = gd.txtGuestName.Text;
            guest.Age = int.Parse(gd.txtGuestAge.Text);
            guest.PassportNo = gd.txtGuestPpNumber.Text;
            lstGuest.Items.Add(guest.Name + guest.Age + guest.PassportNo);

            
        }
    }
}
