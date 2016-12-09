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
    /// Interaction logic for Extras.xaml
    /// </summary>
    public partial class AddExtras : Window
    {
        //Create connection to database and declare booking b
        private Booking b;
        Database data = new Database();

        //Reference booking
        public AddExtras(Booking booking)
        {
            InitializeComponent();
            this.b = booking;
        }

        //Cancel button simply closes this window
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Adds extras to the database
        private void btnAddExtra_Click(object sender, RoutedEventArgs e)
        {
            //Sets the date from the selected dates on the datapicker
            b.HireStart= dtpHireStart.SelectedDate.GetValueOrDefault();
            b.HireEnd = dtpHireEnd.SelectedDate.GetValueOrDefault();

            //Inserts the values into the database
            data.DBConnect();
            data.InsertExtras(txtBreakDesc.Text, txtDinDesc.Text, txtDriverName.Text, b.HireStart.ToString("yyyy-MM-dd"), b.HireEnd.ToString("yyyy-MM-dd"), b.BookingRef);

            //closes 'Add Extras' window
            this.Close();
        }
    }
}
