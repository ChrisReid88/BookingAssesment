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
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Window
    {
        private Customer c;
        Database data = new Database();

        public EditCustomer(Customer c)
        {
            InitializeComponent();
            this.c = c;
            //data.SetCust(Int32.Parse(txtEditCustRef.Text));     
        }

        private void btnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            data.DBConnect();
            data.EditCust(txtEditCustName.Text, txtEditCustAddress.Text, Int32.Parse(txtEditCustRef.Text));
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
