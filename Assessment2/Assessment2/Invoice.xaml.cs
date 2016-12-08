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
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class Invoice : Window
    {

        private Customer c;
        private Guest guest;
        private Booking booking;

        public Invoice(Customer c, Guest guest, Booking booking)
        {
            InitializeComponent();
            this.c = c;
            this.booking = booking;
            this.guest = guest;
        }

        private void btnCloseInvoice_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
