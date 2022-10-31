using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Waiter : Person
    {
        public int ServiceLevel { get; set; }
        public Waiter()
        {
            Random rnd = new Random();
            ServiceLevel = rnd.Next(0, 6);
        }
    }
}
