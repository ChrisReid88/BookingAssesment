using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    class Guest
    {
        private string name;
        private int age;
        private string passportNo;
        

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string PassportNo
        {
            get { return passportNo; }
            set { passportNo = value; }
        }

        public Guest()
        {
        }

        public Guest(string name)
        {
            Name = name;
        }
    }
}
