﻿using System;
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
        private int agecost;
        

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
        public int agePrice()
        {
            if (age < 17)
            {
                agecost = 30;
            }
            else
            {
                agecost = 50;
            }
            return agecost;
        }
    }
}
