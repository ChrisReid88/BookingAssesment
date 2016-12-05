using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    public class Customer
    {
        private string name;
        private string address;
        private int customerRef;

        public string Name
        {
            get { return name; }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Please enter the customer name.");
                }
                name = value;
            }

        }

        public string Address
        {
            get { return address; }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Please enter the customer address.");
                }
                address = value;
            }

        }

        public int CustomerRef
        {
            get { return customerRef; }
            set { customerRef = value; }
        }
    }
}

