using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
   public class Extras
    {
        private int breakfast;
        private int dinner;
        private int carHire;

        public int Breakfast
        {
            get { return breakfast; }
            set { breakfast = value; }
        }
        public int Dinner
        {
            get { return dinner; }
            set { dinner = value; }
        }
        public int CarHire
        {
            get { return carHire; }
            set { carHire = value; }
        }

        public int AddBreakfast()
        {
            return Breakfast = 5;
        }
        public int AddDinner()
        {
            return Dinner= 15;
        }
        public int AddCarHire()
        {
            return CarHire = 50;
        }
    }
}

