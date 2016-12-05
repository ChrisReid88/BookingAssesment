﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for EditGuest.xaml
    /// </summary>
    public partial class EditGuest : Window
    {
        Database data = new Database();
        private Guest guest;
        private BindingList<Guest> bindingguest;

        public EditGuest(Guest guest, BindingList<Guest> bindingguest)
        {
            InitializeComponent();
            this.guest = guest;
            this.bindingguest = bindingguest;
        }

        private void btnAmend_Click(object sender, RoutedEventArgs e)
        {
            data.DBConnect();
            data.EditGuest(txtEditName.Text, Int32.Parse(txtEditAge.Text), txtEditPp.Text);
            guest.Name = txtEditName.Text;
            guest.Age = int.Parse(txtEditAge.Text);
            guest.PassportNo = txtEditPp.Text;
            
            bindingguest.Add(guest);
            this.Close();
        }
    }
}
