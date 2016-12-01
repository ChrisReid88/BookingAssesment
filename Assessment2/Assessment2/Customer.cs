using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int CustomerRefNo { get; set; }

        public void getCustRefNo()
        {
            CustomerRefNo++;
        }
    }
}

