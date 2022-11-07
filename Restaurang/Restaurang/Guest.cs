using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Guest : Person
    {
        public Queue<Food> FoodChoice = new Queue<Food>();
        public double AmountOfMoney { get; set; }
        public int Satisfaction { get; set; }



        public Guest()
        {
            Random rnd = new Random();
            AmountOfMoney = rnd.Next(100, 2000);

        } 

    }
}
