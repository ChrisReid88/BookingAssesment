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
        private int customerRefNo;

        //testing git
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

        public int CustomerRefNo
        {
            get { return customerRefNo; }
            set { customerRefNo = value; }
        }

        public int getCustRefNo()
        {
            CustomerRefNo = 0;
            CustomerRefNo++;
            return customerRefNo;
        }
    }
}

