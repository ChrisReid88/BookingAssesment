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
    class SingletonDBConnect
    {
        /*
             * This class implements a logger using the Singleton pattern to ensure only one instance is created.
             * 
             */

        //Private properties
        private static SingletonDBConnect instance;
        /*
        * This holds a refence to the ONLY Logger object
        * Note the use of static to ensure that only one reference to the one Logger object is held 
        */
        //Constructors
        private SingletonDBConnect() { }
        /*
        * By declaring this constructor as private it cannot be called when 
        */


        /*
         * Properties
         */

        public static SingletonDBConnect Instance
            {
            get
            {
                if (instance == null)
           
                {
                    instance = new SingletonDBConnect();
                }
                return instance;
            }
        }
        public void Connect(Database db)
        {
          // db.Connect();
        }
    }
}