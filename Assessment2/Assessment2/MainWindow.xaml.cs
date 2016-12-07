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
        Customer c2 = new Customer();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BookingWindow bw = new BookingWindow(c, data);
                c.Name = txtCustName.Text;
                c.Address = txtCustAddress.Text;
                bw.lblCustName.Content = txtCustName.Text;
                bw.lblCustAddress.Content = txtCustAddress.Text;

                bw.Show();
                this.Hide();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void btnEditCust_Click(object sender, RoutedEventArgs e)
        {

            EditCustomer ec = new EditCustomer(c);
            data.DBConnect();
            ec.txtEditCustRef.Text = txtEditCustP.Text;

           // data.SetCust(c2.Name, c2.Address, c2.CustomerRef);
            //c2.Name = ec.txtEditCustName.Text;
           // c.Address = ec.txtEditCustAddress.Text;


            ec.ShowDialog();
        }
    }
}
