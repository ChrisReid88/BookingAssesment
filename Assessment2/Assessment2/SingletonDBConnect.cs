using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Controls;
using System.Windows;

namespace Assessment2
{
    class Singleton
    {

        private MySqlConnection conn;
        private static Singleton instance;

        private Singleton() {  }

        public static Singleton Instance
            {
            get
            {
                if (instance == null)
           
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
        private void Connect()
        {
                string DBdetails = "server=127.0.0.1;database=40202859;uid=root;pwd=;";
                conn = new MySqlConnection(DBdetails);
        }
    }
}