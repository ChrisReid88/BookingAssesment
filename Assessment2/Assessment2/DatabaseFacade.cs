using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.ComponentModel;

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
                MessageBox.Show(ex.Message);
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
        public void InsertBooking(string arrival, string departure, int customerref)
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
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        public BindingList<Guest> SetGuest(int bookingRef)
        {
            string query = "SELECT guestName, age, passportNo FROM guest WHERE bookingRef=" + bookingRef + ";";
            MySqlDataReader sdr;
            BindingList<Guest> guest = new BindingList<Guest>();
            if (this.OpenConnection() == true)
            {
                MySqlCommand comm = new MySqlCommand(query, conn);
                sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    Guest g = new Guest();
                    g.Name = sdr.GetString(0);
                    g.Age = Int32.Parse(sdr.GetString(1));
                    g.PassportNo = sdr.GetString(2);
                    guest.Add(g);

                }

                sdr.Close();
                this.CloseConnection();
            }
            return guest;

        }
        public void EditGuest(string name, int age, string passportNo)
        {
            string query2 = "UPDATE guest SET guestName='" + name + "',age=" + age + ",passportNo='" + passportNo + "' WHERE passportNo='" + passportNo + "';";

            if (this.OpenConnection() == true)
            {
                MySqlDataReader sdr;
                MySqlCommand comm = new MySqlCommand(query2, conn);
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
        public void DeleteGuest(string passportNo)
        {
            string query2 = "DELETE FROM guest WHERE passportNo='" + passportNo + "';";

            if (this.OpenConnection() == true)
            {
                MySqlDataReader sdr;
                MySqlCommand comm = new MySqlCommand(query2, conn);
                sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    passportNo = sdr.GetString(2);
                }
                sdr.Close();
                this.CloseConnection();
            }
        }
        public Customer SetCustomer(int customerRef)
        {
            string query = "SELECT customerRef, name, address FROM customer WHERE customerRef='" + customerRef + "';";
            MySqlDataReader sdr;
            Customer customer = new Customer();

            if (this.OpenConnection() == true)
            {
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.CommandText = query;
                sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    customer.CustomerRef = Int32.Parse(sdr.GetString(0));
                    customer.Name = sdr.GetString(1);
                    customer.Address = sdr.GetString(2);
                }
                sdr.Close();
                this.CloseConnection();
            }
            return customer;
        }
        public void EditCust(string name, string address, int customerRef)
        {
            string query2 = "UPDATE customer SET name='" + name + "',address='" + address + "',customerRef=" + customerRef + " WHERE customerRef=" + customerRef + ";";
            MySqlDataReader sdr2;

            if (this.OpenConnection() == true)
            {

                MySqlCommand comm = new MySqlCommand(query2, conn);
                sdr2 = comm.ExecuteReader();
                while (sdr2.Read())
                {
                    customerRef = Int32.Parse(sdr2.GetString(0));
                    name = sdr2.GetString(1);
                    address = sdr2.GetString(2);
                }
                sdr2.Close();
                this.CloseConnection();
            }
        }
        public Booking SetBooking(int bookingRef)
        {
            string query = "SELECT bookingRef, arrival, departure, customerRef FROM booking WHERE bookingRef=" + bookingRef + ";";
            MySqlDataReader sdr;
            Booking booking = new Booking();

            if (this.OpenConnection() == true)
            {
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.CommandText = query;
                sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    booking.BookingRef = Int32.Parse(sdr.GetString(0));
                    booking.Arrival_date = Convert.ToDateTime(sdr.GetString(1));
                    booking.Departure_date = Convert.ToDateTime(sdr.GetString(2));
                    booking.CustomerRef = Int32.Parse(sdr.GetString(3));

                }
                sdr.Close();
                this.CloseConnection();
            }
            return booking;
        }
        public void EditBooking(string arrival, string departure)
        {
            string query = "UPDATE booking SET arrival='" + arrival + "',departure='" + departure + "';";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        public void DeleteBooking(int bookingRef)
        {
            string query2 = "DELETE FROM booking WHERE bookingRef='" + bookingRef + "';";

            if (this.OpenConnection() == true)
            {
                MySqlDataReader sdr;
                MySqlCommand comm = new MySqlCommand(query2, conn);
                sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    bookingRef = Int32.Parse(sdr.GetString(2));
                }
                sdr.Close();
                this.CloseConnection();
            }
        }
        public void DeleteCustomer(int customerRef)
        {
            string query2 = "DELETE FROM customer WHERE customerRef='" + customerRef + "';";

            if (this.OpenConnection() == true)
            {
                MySqlDataReader sdr;
                MySqlCommand comm = new MySqlCommand(query2, conn);
                sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    customerRef = Int32.Parse(sdr.GetString(2));
                }
                sdr.Close();
                this.CloseConnection();
            }
        }
        public void InsertExtras(string bdesc, string ddesc, string hireName, string start, string end, int bookingRef)
        {
            string bookRef = "SELECT MAX(bookingRef) FROM booking";
            MySqlDataReader sdr;

            if (this.OpenConnection() == true)
            {
                MySqlCommand comm = new MySqlCommand(bookRef, conn);
                sdr = comm.ExecuteReader();
                while (sdr.Read())
                    bookingRef = Int32.Parse(sdr.GetString(0));
                sdr.Close();
                this.CloseConnection();
            }
            string query = "INSERT INTO `extras` VALUES ('extraid','" + bdesc + "','" + ddesc + "','" + hireName + "','" + start + "','" + end + "'," + bookingRef + ");";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        public Extras SetExtras(int bookingRef)
        {
            string query = "SELECT bDesc, dDesc, carHireName,hireStart,HireEnd FROM extras WHERE bookingRef='" + bookingRef + "';";
            MySqlDataReader sdr;
            Extras ex = new Extras();

            if (this.OpenConnection() == true)
            {
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.CommandText = query;
                sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    ex.BDesc = sdr.GetString(0);
                    ex.DDesc = sdr.GetString(1);
                    ex.HireName = sdr.GetString(2);
                    ex.HireStart = Convert.ToDateTime(sdr.GetString(3));
                    ex.HireEnd = Convert.ToDateTime(sdr.GetString(4));
                }
                sdr.Close();
                this.CloseConnection();
            }
            return ex;
        }
        public void EditExtras(string breakdesc, string dindesc, string name, string start, string end, int bookingRef)
        {
            string query = "UPDATE extras SET bDesc='" + breakdesc + "',dDesc='" + dindesc + "',carHireName='" + name + "',hireStart='" + start + "',HireEnd='" + end + "' WHERE bookingRef=" + bookingRef + ";";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
    }
}

