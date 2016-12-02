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
    /// Interaction logic for GuestDetails.xaml
    /// </summary>
    public partial class GuestDetails : Window
    {
        public GuestDetails()
        {
            InitializeComponent();


        }
        //Guest g = new Guest();
        
        private void btnGuestAdd_Click(object sender, RoutedEventArgs e)
        {
           
            //g.Name = txtGuestName.Text;
            //g.Age = int.Parse(txtGuestAge.Text);
            //g.PassportNo = txtGuestPpNumber.Text;
            
            this.Close();
            
        }
    }
}
