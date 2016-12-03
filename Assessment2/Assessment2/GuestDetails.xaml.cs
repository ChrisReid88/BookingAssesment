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

        public GuestDetails(Guest guest, BindingList<Guest> bindingguest, Customer c)
        {
            InitializeComponent();

            this.guest = guest;
            this.bindingguest = bindingguest;
            this.c = c;
        }
        private void btnGuestAdd_Click(object sender, RoutedEventArgs e)
        {

            guest.Name = txtGuestName.Text;
            guest.Age = int.Parse(txtGuestAge.Text);
            guest.PassportNo = txtGuestPpNumber.Text;
            bindingguest.Add(guest);
            db.DBConnect();
            db.InsertGuest(guest.Name, guest.Age, guest.PassportNo,c.CustomerRefNo);
            this.Close();

        }
    }
}
