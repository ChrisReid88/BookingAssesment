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
                string DBdetails = "server=127.0.0.1;database=40202859;uid=root;pwd=password;";
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
        public void InsertGuest(string name, int age, string passportNo, int bookRef)
        {
            string bookingRef = "SELECT MAX(bookingRef) FROM booking";
            MySqlDataReader sdr;


            if (this.OpenConnection() == true)
            {
                MySqlCommand comm = new MySqlCommand(bookingRef, conn);
                comm.CommandText = bookingRef;
                sdr = comm.ExecuteReader();
                while (sdr.Read())
                    bookRef = Int32.Parse(sdr.GetString(0));
                sdr.Close();
                this.CloseConnection();
            }

            string query = "INSERT INTO `guest` VALUES ('" + passportNo + "','" + name + "'," + age + "," + bookRef + ");";

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

        public void InsertBooking(DateTime arrival, DateTime departure, int customerref)
        {
            string custRef = "SELECT MAX(customerRef) FROM customer";
            MySqlDataReader sdr;


            if (this.OpenConnection() == true)
            {
                MySqlCommand comm = new MySqlCommand(custRef, conn);
                comm.CommandText = custRef;
                sdr = comm.ExecuteReader();
                while (sdr.Read())
                    customerref = Int32.Parse(sdr.GetString(0));
                sdr.Close();
                this.CloseConnection();
            }

            string query = "INSERT INTO `booking` VALUES (bookingRef,'" + arrival + "','" + departure + "'," + customerref + ");";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        public void EditGuest(string name, int age, string passportNo)
        {
            string query = "SELECT guestName, age, passportNo FROM guest WHERE passportNo='" + passportNo + "';";
            MySqlDataReader sdr;

            if (this.OpenConnection() == true)
            {
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.CommandText = query;
                sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    name = sdr.GetString(0);
                    age = Int32.Parse(sdr.GetString(1));
                    passportNo = sdr.GetString(2);
                }
                sdr.Close();
                this.CloseConnection();
            }


        }
    }
}
