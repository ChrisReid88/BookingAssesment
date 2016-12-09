using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Customer.cs
* 
*This class is used for creating the customers 
*
* Written by Chris Reid 1/12/16
*/


namespace Assessment2
{
    public class Customer
    {
        private string name;
        private string address;
        private int customerRef;

        //Property for manipulating customer name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        //Property for manipulating their address
        public string Address
        {
            get { return address; }
            set { address = value; }

        }

        //Property for manipulating the customer reference
        public int CustomerRef
        {
            get { return customerRef; }
            set { customerRef = value; }
        }
    }
}

