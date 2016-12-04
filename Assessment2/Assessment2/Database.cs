using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Assessment2
{
    public class Database
    {

        private MySqlConnection conn;


        public void DBConnect()
        {
            Connect();
        }

        private void Connect()
        {
            try
            {
                string DBdetails = "server=127.0.0.1;database=40202859;uid=root;pwd=;";
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
        public void InsertGuest(string name, int age, string passportNo)
        {
            string query = "INSERT INTO `guest` (`passportNo`, `guestName`, `age`) VALUES ('" + passportNo + "','" + name + "','" + age + "');";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        public void InsertCustomer(string name, string address)
        {
            string query = "INSERT INTO `customer`(`name`, `address`) VALUES ('" + name + "','" + address + "');";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public void InsertBooking(DateTime arrival, DateTime departure)
        {
            string query = "INSERT INTO `booking`(`arrival`, `departure`) VALUES ('" + arrival + "','" + departure + "');";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
    }
}
