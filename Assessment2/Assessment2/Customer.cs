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
            set { name = value; }

        }

        public string Address
        {
            get { return address; }
            set { address = value; }

        }

        public int CustomerRef
        {
            get { return customerRef; }
            set { customerRef = value; }
        }
    }
}

