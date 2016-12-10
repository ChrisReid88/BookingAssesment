using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Extras.cs
* 
*This class is used for creating the extras which
 * will be used by the booking
*
* Written by Chris Reid 1/12/16
 * Last modified 10/12/2016
*/

namespace Assessment2
{
   public class Extras
    {
        private int breakfast;
        private int dinner;
        private int carHire;
        private string bDesc;
        private string dDesc;
        private string hireName;
        private DateTime hireStart;
        private DateTime hireEnd;

       //Property for manipulating the breakfast price
        public int Breakfast
        {
            get { return breakfast; }
            set { breakfast = value; }
        }

        //Property for manipulating the dinner price
        public int Dinner
        {
            get { return dinner; }
            set { dinner = value; }
        }

        //Property for manipulating the car hire
        public int CarHire
        {
            get { return carHire; }
            set { carHire = value; }
        }

        //Property for manipulating the breakfast description
        public string BDesc
        {
            get { return bDesc; }
            set { bDesc = value; }
        }


        //Property for manipulating the dinner description
        public string DDesc
        {
            get { return dDesc; }
            set { dDesc = value; }
        }

        //Property for manipulating the name of person hiring the car
        public string HireName
        {
            get { return hireName; }
            set { hireName = value; }
        }

        //Property for manipulating the date the hire starts
        public DateTime HireStart
        {
            get { return hireStart; }
            set { hireStart = value; }
        }

        //Property for manipulating the end of the car hire
        public DateTime HireEnd
        {
            get { return hireEnd; }
            set { hireEnd = value; }
        }

       //Get the duration of car hire
        public int getHireDuration()
        {
            double carHire = (hireEnd - hireStart).TotalDays;
            return Convert.ToInt32(carHire);
        }
    }
}

