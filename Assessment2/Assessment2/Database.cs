﻿using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Assessment2
{
    class Database
    {

        private MySqlConnection conn;


        //Constructor
        public void DBConnect()
        {
            Connect();
        }

        //Initialize values
        private void Connect()
        {
            // con = new MySqlConnection(
            //"server=localhost;database=40202859;uid=root;password=;");

            //string DBdetails = null;

            try
            {
                string DBdetails = "server=mysqlhost3;database=40202859;uid=40202859;pwd=3siqucadore;";
                conn = new MySqlConnection(DBdetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:

                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public void Insert()
        {
            string query = "Select * FROM guest";

            //open connections
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
    }
}
