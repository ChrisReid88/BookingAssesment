using System;
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

        private MySqlConnection con;


        //Constructor
        public void DBConnect()
        {
            Connect();
        }

        //Initialize values
        private void Connect()
        {
            con = new MySqlConnection(
"server=localhost;database=40202859;uid=root;password=;");


            //string DBdetails = "server=localhost;database=40202859;uid=root;password=;";
            //conn = new MySqlConnection(DBdetails);
        }

        private bool OpenConnection()
        {
            try
            {
                con.Open();
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
                con.Close();
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
            string query = "INSERT INTO customer (name) VALUES('John Smith')";

            //open connections
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, con);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
    }
}
