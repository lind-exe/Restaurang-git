using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Guest : Person
    {
        public Food FoodChoice { get; set; }
        public double AmountOfMoney { get; set; }

        public Guest()
        {
            Random rnd = new Random();
            AmountOfMoney = rnd.Next(100, 2000);
        } 
    }
}
