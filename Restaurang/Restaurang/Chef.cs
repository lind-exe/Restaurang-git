using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Chef : Person
    {
        public Queue<Food> WorkOrder = new Queue<Food>();
        public int Skills { get; set; }
        public bool Cooking { get; set; }
        public bool FinishedCooking { get; set; }
        public int CookingTime { get; set; }


        public Chef()
        {
            Random rnd = new Random();
            Skills = rnd.Next(1, 6);
        }
    }
}
