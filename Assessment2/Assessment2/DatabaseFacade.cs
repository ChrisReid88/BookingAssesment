using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.ComponentModel;

/* DatabaseFacade.cs
* 
This class will be used for hiding complicated 
 * methods from other.
*
* Written by Chris Reid 1/12/16
 * Last Modified 10/12/2016
*/

namespace Assessment2
{
    public class DatabaseFacade
    {
        //properties for facade
        private Customer customer;
        private Guest guest;
        private Booking booking;

        //declaring open connection property
        private MySqlConnection conn;

        public DatabaseFacade()
        {
            customer = new Customer();
            booking = new Booking();
            guest = new Guest();
        }

        //Method to take private connect
        public void DBConnect()
        {
            Connect();
        }

        //Connection string assigned to database connection
        private void Connect()
        {
            try
            {
                //change to pwd=1234
                string DBdetails = "server=127.0.0.1;database=40202859;uid=root;pwd=;";
                conn = new MySqlConnection(DBdetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //Method for testing if connection is open
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
        //For testing if connection is closed
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

        //Method for inserting guest to database
        public void InsertGuest(string name, int age, string passportNo, int bookRef)
        {
            //Return the highest (last entered) booking reference
            string bookingRef = "SELECT MAX(bookingRef) FROM booking";
            MySqlDataReader sdr;

            //If connection is open, carryout the query and store value in bookRef
            if (this.OpenConnection() == true)
            {
                MySqlCommand comm = new MySqlCommand(bookingRef, conn);
                sdr = comm.ExecuteReader();
                while (sdr.Read())
                    bookRef = Int32.Parse(sdr.GetString(0));
                //when finished reading, close the data reader and the connection
                sdr.Close();
                this.CloseConnection();
            }

            //Inserts the values into the guest table
            string query = "INSERT INTO `guest` VALUES ('" + passportNo + "','" + name + "'," + age + "," + bookRef + ");";

            //If connection is open, execute
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Insert into customer
        public void InsertCustomer(string name, string address)
        {
            //mysql statement to insert customer name and address. customerRef auto-increment by database
            string query = "INSERT INTO `customer`(`name`, `address`) VALUES ('" + name + "','" + address + "');";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Insert booking to database
        public void InsertBooking(string arrival, string departure, int customerref)
        {
            //find the last entered customer ref from the customer table
            string custRef = "SELECT MAX(customerRef) FROM customer";

            MySqlDataReader sdr;
            
            //execute query
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

            //insert results into booking table. (copying and pasting so using query variable for non query)
            string query = "INSERT INTO `booking` VALUES (bookingRef,'" + arrival + "','" + departure + "'," + customerref + ");";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //binding list to store all guests from one booking
        public BindingList<Guest> SetGuest(int bookingRef)
        {
            //query for returning wanted guests
            string query = "SELECT guestName, age, passportNo FROM guest WHERE bookingRef=" + bookingRef + ";";
            MySqlDataReader sdr;
            BindingList<Guest> guest = new BindingList<Guest>();
            if (this.OpenConnection() == true)
            {
                MySqlCommand comm = new MySqlCommand(query, conn);
                sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    //store the results in the guest
                    Guest g = new Guest();
                    g.Name = sdr.GetString(0);
                    g.Age = Int32.Parse(sdr.GetString(1));
                    g.PassportNo = sdr.GetString(2);
                    //add each guest to the bindinglist
                    guest.Add(g);

                }
                sdr.Close();
                this.CloseConnection();
            }
            return guest;

        }

        //Edit guest method
        public void EditGuest(string name, int age, string passportNo)
        {
            //Update row in guest table
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

        //Delete guest from database
        public void DeleteGuest(string passportNo)
        {
            //delet guest from database based on passport number
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
        //Set customer is used to return the values from the database to enable adding them to textboxes/labels
        public Customer SetCustomer(int customerRef)
        {
            string query = "SELECT customerRef, name, address FROM customer WHERE customerRef='" + customerRef + "';";
            MySqlDataReader sdr;
            

            if (this.OpenConnection() == true)
            {
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.CommandText = query;
                sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    //store them to the customer properties
                    customer.CustomerRef = Int32.Parse(sdr.GetString(0));
                    customer.Name = sdr.GetString(1);
                    customer.Address = sdr.GetString(2);
                }
                sdr.Close();
                this.CloseConnection();
            }
            return customer;
        }

        //edit customer method
        public void EditCust(string name, string address, int customerRef)
        {
            //updates customer data using the customerRef
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
        //Used to return booking values that will be added to labels and textboxes, to later be amended
        public Booking SetBooking(int bookingRef)
        {
            string query = "SELECT bookingRef, arrival, departure, customerRef FROM booking WHERE bookingRef=" + bookingRef + ";";
            MySqlDataReader sdr;
            //new booking to store the query results
            Booking booking = new Booking();

            if (this.OpenConnection() == true)
            {
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.CommandText = query;
                sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    //store to booking properties
                    booking.BookingRef = Int32.Parse(sdr.GetString(0));
                    booking.Arrival_date = Convert.ToDateTime(sdr.GetString(1));
                    booking.Departure_date = Convert.ToDateTime(sdr.GetString(2));
                    booking.CustomerRef = Int32.Parse(sdr.GetString(3));

                }
                //close both data reader and connection
                sdr.Close();
                this.CloseConnection();
            }
            //return the whole booking
            return booking;
        }

        //Used to amend booking values
        public void EditBooking(string arrival, string departure)
        {
            //Update the booking dates
            string query = "UPDATE booking SET arrival='" + arrival + "',departure='" + departure + "';";

            if (this.OpenConnection() == true)
            {
                //execute
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Delete a booking
        public void DeleteBooking(int bookingRef)
        {
            Remove a booking based on bookingRef
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
                //close data reader an connection to database
                sdr.Close();
                this.CloseConnection();
            }
        }

        //Delete a customer
        public void DeleteCustomer(int customerRef)
        {
            //remove from customer table
            string query2 = "DELETE FROM customer WHERE customerRef='" + customerRef + "';";

            if (this.OpenConnection() == true)
            {
                MySqlDataReader sdr;
                MySqlCommand comm = new MySqlCommand(query2, conn);
                sdr = comm.ExecuteReader();
                //needed for a delete?
                while (sdr.Read())
                {
                    customerRef = Int32.Parse(sdr.GetString(2));
                }
                //close data reader and connection
                sdr.Close();
                this.CloseConnection();
            }
        }

        //Insert into the extras table
        public void InsertExtras(string bdesc, string ddesc, string hireName, string start, string end, int bookingRef)
        {
            //find last added bookingRe
            string bookRef = "SELECT MAX(bookingRef) FROM booking";
            MySqlDataReader sdr;

            if (this.OpenConnection() == true)
            {
                //carry out the query
                MySqlCommand comm = new MySqlCommand(bookRef, conn);
                sdr = comm.ExecuteReader();
                while (sdr.Read())
                    bookingRef = Int32.Parse(sdr.GetString(0));
                //close data reader and connection
                sdr.Close();
                this.CloseConnection();
            }

            //insert extras to table based on result from the select bookingRef query
            string query = "INSERT INTO `extras` VALUES ('extraid','" + bdesc + "','" + ddesc + "','" + hireName + "','" + start + "','" + end + "'," + bookingRef + ");";

            if (this.OpenConnection() == true)
            {
                //execute
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Pull extra records from database
        public Extras SetExtras(int bookingRef)
        {
            //Select the  extra records based on the bookingRef entered
            string query = "SELECT bDesc, dDesc, carHireName,hireStart,HireEnd FROM extras WHERE bookingRef='" + bookingRef + "';";
            MySqlDataReader sdr;
            
            //new extra to store results
            Extras ex = new Extras();

            if (this.OpenConnection() == true)
            {
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.CommandText = query;
                sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    //Store the results of the query in ex
                    ex.BDesc = sdr.GetString(0);
                    ex.DDesc = sdr.GetString(1);
                    ex.HireName = sdr.GetString(2);
                    ex.HireStart = Convert.ToDateTime(sdr.GetString(3));
                    ex.HireEnd = Convert.ToDateTime(sdr.GetString(4));
                }
                //Close data reader and connection
                sdr.Close();
                this.CloseConnection();
            }
            //return the extras
            return ex;
        }

        //method to enable extras to be amended
        public void EditExtras(string breakdesc, string dindesc, string name, string start, string end, int bookingRef)
        {
            //update extras from booking based on foreign key bookingRef
            string query = "UPDATE extras SET bDesc='" + breakdesc + "',dDesc='" + dindesc + "',carHireName='" + name + "',hireStart='" + start + "',HireEnd='" + end + "' WHERE bookingRef=" + bookingRef + ";";

            if (this.OpenConnection() == true)
            {
                //execute the query and close connection
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
    }
}

