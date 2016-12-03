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
        private Guest guest;
        private BindingList<Guest> bindingguest;

        public GuestDetails(Guest guest, BindingList<Guest> bindingguest)
        {
            InitializeComponent();

            this.guest = guest;
            this.bindingguest = bindingguest;
        }
        private void btnGuestAdd_Click(object sender, RoutedEventArgs e)
        {
            guest.Name = txtGuestName.Text;
            guest.Age = int.Parse(txtGuestAge.Text);
            guest.PassportNo = txtGuestPpNumber.Text;
            bindingguest.Add(guest);
            this.Close();

        }
    }
}
