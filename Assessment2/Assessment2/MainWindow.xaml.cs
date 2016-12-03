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
                BookingWindow bw = new BookingWindow(c);
                c.Name = txtCustName.Text;
                c.Address = txtCustAddress.Text;
                c.CustomerRefNo = c.getCustRefNo();
                bw.lblCustName.Content = txtCustName.Text;
                bw.lblCustAddress.Content = txtCustAddress.Text;
                bw.lblCustRef.Content = c.getCustRefNo();
                bw.Show();

                data.DBConnect();
                data.InsertCustomer(c.Name, c.Address);

                this.Hide();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }

        }
    }
}
