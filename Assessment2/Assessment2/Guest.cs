using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Guests.cs
* 
*This class is used for creating the extras which
 * will be used by the booking
*
* Written by Chris Reid 1/12/16
*/

namespace Assessment2
{
    public class Guest
    {
        private string name;
        private int age;
        private string passportNo;
        private int agecost;
        private int noOfGuests;

        //Proterty for manipulating the string to be taken from the list box
        public string selected { get; set; }

        //Proterty for manipulating guest name
        public string Name
        {
            get { return name; }
            set
            {
                if (Name != String.Empty || Name != null)
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Name cannot be null or empty string");
                }
            }
        }

        //Proterty for manipulating guests age
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        //Proterty for manipulating passport number
        public string PassportNo
        {
            get { return passportNo; }
            set
            {
                if (passportNo!= String.Empty || Name != null)
                {
                    passportNo = value;
                }
                else
                {
                    throw new ArgumentException("Name cannot be null or empty string");
                }
            }
        }
        //Proterty for manipulating the amount of guests staying
        public int NoOfGuests
        {
            get { return noOfGuests; }
            set { noOfGuests = value; }
        }

        //Method to return the price for the different age groups
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

        //Override guest ToString()  to this
        public override string ToString()
        {
            return this.Name + "|" + this.Age + "|" + this.PassportNo;
        }
    }
}
