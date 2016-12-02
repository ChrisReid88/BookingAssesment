﻿using System;
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
        public MainWindow()
        {
            InitializeComponent();
        }
        Customer c = new Customer();
        BookingWindow bw = new BookingWindow();

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                c.Name = txtCustName.Text;
                c.Address = txtCustAddress.Text;
                bw.lblCustName.Content = txtCustName.Text;
                bw.lblCustAddress.Content = txtCustAddress.Text;
                bw.lblCustRef.Content = c.getCustRefNo();
                bw.Show();
                this.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }

        }
    }
}
